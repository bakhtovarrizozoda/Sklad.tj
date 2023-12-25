using Domain.Dtos.Account.LoginDto;
using Domain.Dtos.Account.RegisterDto;
using Infrastructure.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpGet("get-all-user")]
    public async Task<IActionResult> GetAllAccount()
    {
        var response = await _service.GetAllAccountAsync();
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromQuery]LoginRequestDto model)
    {
        var response = await _service.LoginAsync(model);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromQuery]RegisterRequestDto model)
    {
        var response = await _service.RegisterAsync(model);
        return Ok(response);
    }

    [HttpPut("unblocked")]
    public async Task<IActionResult> UnBlockedAsync(int id)
    {
        var response = await _service.UnBlockedAccountAsync(id);
        return Ok(response);
    }

    [HttpPut("blocked")]
    public async Task<IActionResult> BlockedAsync(int id)
    {
        var response = await _service.BlockedAccountAsync(id);
        return Ok(response);
    }
}
