using Domain.Dtos.Role;
using Domain.Wrapper;

namespace Infrastructure.Services.RoleService;

public interface IRoleService
{
    public Task<Response<List<GetRoleDto>>> GetRole();
    public Task<Response<GetRoleDto>> GetRoleById(int id);
    public Task<Response<GetRoleDto>> AddRole(AddRoleDto role);
    public Task<Response<GetRoleDto>> UpdateRole(AddRoleDto role);
    public Task<Response<bool>> DeleteRole(int id);
}
