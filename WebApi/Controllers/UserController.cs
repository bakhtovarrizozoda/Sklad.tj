using Domain.Dtos.User;
using Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUserFullInfo")]
    public async Task<IActionResult> GetUserFullInfo()
    {
        var result = await _userService.GetUserFullInfo();
        return Ok(result);
    }
    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser()
    {
        var result = await _userService.GetUser();
        return Ok(result);
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _userService.GetUserById(id);
        return Ok(result);
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser([FromQuery]AddUserDto user)
    {
        var result = await _userService.AddUser(user);
        return Ok(result);
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromQuery]AddUserDto user)
    {
        var result = await _userService.UpdateUser(user);
        return Ok(result);
    }

    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser([FromQuery]int id)
    {
        var result = await _userService.DeleteUser(id);
        return Ok(result);
    }
}
