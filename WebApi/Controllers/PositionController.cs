using Domain.Dtos.Position;
using Infrastructure.Services.PositionService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionService _positionService;
    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpGet("GetPosition")]
    public async Task<IActionResult> GetPosition()
    {
        var result = await _positionService.GetPosition();
        return Ok(result);
    }

    [HttpGet("GetPositionById")]
    public async Task<IActionResult> GetPositionById(int id)
    {
        var result = await _positionService.GetPositionById(id);
        return Ok(result);
    }

    [HttpPost("AddPosition")]
    public async Task<IActionResult> AddPosition([FromQuery]AddPositionDto position)
    {
        var result = await _positionService.AddPosition(position);
        return Ok(result);
    }

    [HttpPut("UpdatePosition")]
    public async Task<IActionResult> UpdatePosition([FromQuery]AddPositionDto position)
    {
        var result = await _positionService.UpdatePosition(position);
        return Ok(result);
    }

    [HttpDelete("DeletePosition")]
    public async Task<IActionResult> DeletePosition(int id)
    {
        var result = await _positionService.DeletePosition(id);
        return Ok(result);
    }
}
