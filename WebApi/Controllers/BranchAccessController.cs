using Domain.Dtos.BranchAccess;
using Infrastructure.Services.BranchAccessService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BranchAccessController : ControllerBase
{
    private readonly IBranchAccessService _branchAccessService;
    public BranchAccessController(IBranchAccessService branchAccessService)
    {
        _branchAccessService = branchAccessService;
    }

    [HttpGet("GetBranchAccessFullInfo")]
    public async Task<IActionResult> GetBranchAccessFullInfo()
    {
        var result = await _branchAccessService.GetBranchAccessFullInfo();
        return Ok(result);
    }

    [HttpGet("GetBranchAccess")]
    public async Task<IActionResult> GetBranchAccess()
    {
        var result = await _branchAccessService.GetBranchAccess();
        return Ok(result);
    }

    [HttpGet("GetBranchAccessById")]
    public async Task<IActionResult> GetBranchAccessById(int id)
    {
        var result = await _branchAccessService.GetBranchAccessById(id);
        return Ok(result);
    }

    [HttpPost("AddBranchAccess")]
    public async Task<IActionResult> AddBranchAccess([FromQuery]AddBranchAccessDto branchAccess)
    {
        var result = await _branchAccessService.AddBranchAccess(branchAccess);
        return Ok(result);
    }

    [HttpPut("UpdateBranchAccess")]
    public async Task<IActionResult> UpdateBranchAccess([FromQuery]AddBranchAccessDto branchAccess)
    {
        var result = await _branchAccessService.UpdateBranchAccess(branchAccess);
        return Ok(result);
    }

    [HttpDelete("DeleteBranchAccess")]
    public async Task<IActionResult> DeleteBranchAccess(int id)
    {
        var result = _branchAccessService.DeleteBranchAccess(id);
        return Ok(result);
    }
}