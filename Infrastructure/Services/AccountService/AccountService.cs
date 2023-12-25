using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Domain.Dtos.Account.AccountDto;
using Domain.Dtos.Account.LoginDto;
using Domain.Dtos.Account.RegisterDto;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.AccountService;

public class AccountService : IAccountService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private string secretKey;
    public AccountService(DataContext context, IConfiguration configuration, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
        secretKey = configuration.GetConnectionString("JwtKey") ?? Guid.NewGuid().ToString();
    }
    
    public async Task<Response<string>> BlockedAccountAsync(int id)
    {
        var users = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        if (users == null) return new Response<string>(HttpStatusCode.NotFound, "Account not found");
        users.IsBlocked = false;
        await _context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK, "Account successfully blocked");
    }

    public async Task<Response<List<GetAllAccountDto>>> GetAllAccountAsync()
    {
        try
        {
            var model = await _context.Accounts.ToListAsync();
            var result = _mapper.Map<List<GetAllAccountDto>>(model);
            return new Response<List<GetAllAccountDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetAllAccountDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<LoginResponseDto>> LoginAsync(LoginRequestDto model)
    {
        var users = await _context.Accounts.FirstOrDefaultAsync( x => 
        x.UserName.ToLower().Trim() == model.Username.ToLower().Trim());
        if (!BCrypt.Net.BCrypt.Verify(model.Password, users.HashPassword) || users == null)
        return new Response<LoginResponseDto>(HttpStatusCode.BadRequest, "Username or password is incorrect");
        else 
        return await GenerateJWT_Token(users);
    }

    private async Task<Response<LoginResponseDto>> GenerateJWT_Token(Account? users)
    {
        return await Task.Run(async () =>
        {
            var claims = new List<Claim>
            {
                new Claim("UserId",users.Id.ToString()),
                new Claim("UserName",users.UserName),
                new Claim("Email",users.Email),
                new Claim(ClaimTypes.MobilePhone,users.Phone)
            };


            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var createToken = jwtTokenHandler.CreateToken(tokenDescriptor);
            var writeToken = jwtTokenHandler.WriteToken(createToken);

            var response = new LoginResponseDto
            {
                JwtToken = writeToken
            };
            return new Response<LoginResponseDto>(System.Net.HttpStatusCode.OK, writeToken);
        });
    }

    public async Task<Response<RegisterRequestDto>> RegisterAsync(RegisterRequestDto model)
    {
        var user = await _context.Accounts.FirstOrDefaultAsync(x =>
            x.UserName.ToLower().Trim() == model.UserName.ToLower().Trim());
        if (user != null) return new Response<RegisterRequestDto>(HttpStatusCode.NotFound, "User already exist!");
        if (model.Password.Length < 4 || model.Password.Length > 45)
            return new Response<RegisterRequestDto>(HttpStatusCode.BadRequest,
                "The password length should be in the range from 4 to 45!");
        var newUser = new Account()
        {
            IsBlocked = false,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.UserName,
            HashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Phone = model.Phone
        };
        await _context.Accounts.AddAsync(newUser);
        var resultOfRegister = await _context.SaveChangesAsync();
        if (resultOfRegister == 0)
            return new Response<RegisterRequestDto>(HttpStatusCode.Unauthorized, "User not authorised!");
        return new Response<RegisterRequestDto>(HttpStatusCode.OK, "User successfully authorised");
    }

    public async Task<Response<string>> UnBlockedAccountAsync(int id)
    {
        var users = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        if (users == null) return new Response<string>(HttpStatusCode.NotFound, "User not found");
        users.IsBlocked = false;
        await _context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK, "User successfully unblocked");
    }
}