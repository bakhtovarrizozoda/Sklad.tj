using Domain.Dtos.Incoming;
using Infrastructure.Services.IncomingService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomingController : ControllerBase
{
    private readonly IIncomingService _incomingService;
    public IncomingController(IIncomingService incomingService)
    {
        _incomingService = incomingService;
    }

    [HttpGet("GetIncomingFullInfo")]
    public async Task<IActionResult> GetIncomingFullInfo()
    {
        var result = await _incomingService.GetIncomingFullInfo();
        return Ok(result);
    }

    [HttpGet("GetIncoming")]
    public async Task<IActionResult> GetIncoming()
    {
        var result = await _incomingService.GetIncoming();
        return Ok(result);
    }

    [HttpGet("GetIncomingById")]
    public async Task<IActionResult> GetIncomingById(int id)
    {
        var result = await _incomingService.GetIncomingById(id);
        return Ok(result);
    }

    [HttpPost("AddIncoming")]
    public async Task<IActionResult> AddIncoming(AddIncomingDto incoming)
    {
        var result = await _incomingService.AddIncoming(incoming);
        return Ok(result);
    }

    [HttpPut("UpdateIncoming")]
    public async Task<IActionResult> UpdateIncoming([FromQuery]AddIncomingDto incoming)
    {
        var result = await _incomingService.UpdateIncoming(incoming);
        return Ok(result);
    }

    [HttpDelete("DeleteIncoming")]
    public async Task<IActionResult> DeleteIncoming(int id)
    {
        var result = _incomingService.DeleteIncoming(id);
        return Ok(result);
    }
}
