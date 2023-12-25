using Domain.Dtos.Branch;
using Infrastructure.Services.BranchService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService; 
    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet("GetBranchFullInfo")]
    public async Task<IActionResult> GetBranchFullInfo()
    {
        var result = await _branchService.GetBranchFullInfo();
        return Ok(result);
    }

    [HttpGet("GetBranch")]
    public async Task<IActionResult> GetBranch()
    {
        var result = await _branchService.GetBranch();
        return Ok(result);
    }

    [HttpGet("GetBranchById")]
    public async Task<IActionResult> GetBranchById(int id)
    {
        var result = await _branchService.GetBranchById(id);
        return Ok(result);
    }

    [HttpPost("AddBranch")]
    public async Task<IActionResult> AddBranch([FromQuery]AddBranchDto branch)
    {
        var result = await _branchService.AddBranch(branch);
        return Ok(result);
    }

    [HttpPut("UpdateBranch")]
    public async Task<IActionResult> UpdateBranch([FromQuery]AddBranchDto branch)
    {
        var result = await _branchService.UpdateBranch(branch);
        return Ok(result);
    }

    [HttpDelete("DeleteBranch")]
    public async Task<IActionResult> DeleteBranch(int id)
    {
        var result = _branchService.DeleteBranch(id);
        return Ok(result);
    }
}
