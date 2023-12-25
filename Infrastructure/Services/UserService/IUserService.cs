using Domain.Dtos.User;
using Domain.Wrapper;

namespace Infrastructure.Services.UserService;

public interface IUserService
{
    public Task<List<GetUserFullInfoDto>> GetUserFullInfo();
    public Task<Response<List<GetUserDto>>> GetUser();
    public Task<Response<GetUserDto>> GetUserById(int id);
    public Task<Response<GetUserDto>> AddUser(AddUserDto user);
    public Task<Response<GetUserDto>> UpdateUser(AddUserDto user);
    public Task<Response<bool>> DeleteUser(int id);
}
