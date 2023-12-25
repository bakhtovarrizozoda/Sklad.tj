using Domain.Dtos.Account.AccountDto;
using Domain.Dtos.Account.LoginDto;
using Domain.Dtos.Account.RegisterDto;
using Domain.Wrapper;

namespace Infrastructure.Services.AccountService;

public interface IAccountService
{
    public Task<Response<List<GetAllAccountDto>>> GetAllAccountAsync();
    public Task<Response<string>> UnBlockedAccountAsync(int id);
    public Task<Response<string>> BlockedAccountAsync(int id);
    public Task<Response<LoginResponseDto>> LoginAsync(LoginRequestDto model);
    public Task<Response<RegisterRequestDto>> RegisterAsync(RegisterRequestDto model);
}
