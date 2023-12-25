using Domain.Dtos.Outcoming;
using Infrastructure.Services.OutcomingService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OutcomingController : ControllerBase
{
    private readonly IOutcomingService _outcomingService;
    public OutcomingController(IOutcomingService outcomingService)
    {
        _outcomingService = outcomingService;
    }

    [HttpGet("GetOutcomingFullInfo")]
    public async Task<IActionResult> GetOutcomingFullInfo()
    {
        var result = await _outcomingService.GetOutcomingFullInfo();
        return Ok(result);
    }

    [HttpGet("GetOutcoming")]
    public async Task<IActionResult> GetOutcoming()
    {
        var result = await _outcomingService.GetOutcoming();
        return Ok(result);
    }

    [HttpGet("GetOutcomingById")]
    public async Task<IActionResult> GetOutcomingById(int id)
    {
        var result = await _outcomingService.GetOutcomingById(id);
        return Ok(result);
    }

    [HttpPost("AddOutcoming")]
    public async Task<IActionResult> AddOutcoming([FromQuery]AddOutcomingDto outcoming)
    {
        var result = await _outcomingService.AddOutcoming(outcoming);
        return Ok(result);
    }

    [HttpPut("UpdateOutcoming")]
    public async Task<IActionResult> UpdateOutcoming([FromQuery] AddOutcomingDto outcoming)
    {
        var result = await _outcomingService.UpdateOutcoming(outcoming);
        return Ok(result);
    }

    [HttpDelete("DeleteOutcoming")]
    public async Task<IActionResult> DeleteOutcoming(int id)
    {
        var result = await _outcomingService.DeleteOutcoming(id);
        return Ok(result);
    }
}
