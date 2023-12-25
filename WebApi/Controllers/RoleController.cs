using Infrastructure.Services.RoleService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos.Role;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("GetRole")]
    public async Task<IActionResult> GetRole()
    {
        var result = await _roleService.GetRole();
        return Ok(result);
    }

    [HttpGet("GetRoleById")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var result = await _roleService.GetRoleById(id);
        return Ok(result);
    }

    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRole([FromQuery]AddRoleDto role)
    {
        var result = await _roleService.AddRole(role);
        return Ok(result);
    }

    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole([FromQuery]AddRoleDto role)
    {
        var result = await _roleService.UpdateRole(role);
        return Ok(result);
    }

    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var result = await _roleService.DeleteRole(id);
        return Ok(result);
    }
}
