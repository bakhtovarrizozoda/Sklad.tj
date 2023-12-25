using System.Net;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.UserService;

public class UserService : IUserService
{
    private readonly DataContext _contextUser;
    private readonly IMapper _mapper;
    public UserService(DataContext context, IMapper mapper)
    {
        _contextUser = context;
        _mapper = mapper;
    }

    public async Task<List<GetUserFullInfoDto>> GetUserFullInfo()
    {
        var result = await (from u in _contextUser.Users
        join p in _contextUser.Positions on u.PositionId equals p.Id
        join r in _contextUser.Roles on u.RoleId equals r.Id into userpositionrole
        from upr in userpositionrole.DefaultIfEmpty()
        select new GetUserFullInfoDto()
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Phone = u.Phone,
            PositionName = p.PositionName,
            PositionId = p.Id,
            RolName = upr.RolName,
            RoleId = upr.Id
        }).ToListAsync();
        return result;
    }
    

    public async Task<Response<GetUserDto>> AddUser(AddUserDto user)
    {
        try
        {
            var model = _mapper.Map<User>(user);
            await _contextUser.Users.AddAsync(model);
            await _contextUser.SaveChangesAsync();
            var result = _mapper.Map<GetUserDto>(model);
            return new Response<GetUserDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetUserDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteUser(int id)
    {
        try
        {
            var model = await _contextUser.Users.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _contextUser.Users.Remove(model);
            await _contextUser.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }

    }

    public async Task<Response<List<GetUserDto>>> GetUser()
    {
        try
        {
            var model = await _contextUser.Users.ToListAsync();
            var result = _mapper.Map<List<GetUserDto>>(model);
            return new Response<List<GetUserDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetUserDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetUserDto>> GetUserById(int id)
    {
        try
        {
            var model = await _contextUser.Users.FindAsync(id);
            if (model == null) return new Response<GetUserDto>(new GetUserDto());
            var result = _mapper.Map<GetUserDto>(model);
            return new Response<GetUserDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetUserDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }



    public async Task<Response<GetUserDto>> UpdateUser(AddUserDto user)
    {
        try
        {
            var model = await _contextUser.Users.FindAsync(user.Id);
            _mapper.Map(user, model);
            _contextUser.Entry(model).State = EntityState.Modified;
            await _contextUser.SaveChangesAsync();
            var result = _mapper.Map<GetUserDto>(model);
            return new Response<GetUserDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetUserDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
