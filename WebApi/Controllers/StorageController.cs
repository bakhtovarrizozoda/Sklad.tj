using Domain.Dtos.Storage;
using Infrastructure.Services.StorageService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StorageController : ControllerBase
{
    private readonly IStorageService _storageService;
    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet("GetStorageFullInfo")]
    public async Task<IActionResult> GetStorageFullInfo()
    {
        var result = await _storageService.GetStorageFullInfo();
        return Ok(result);
    }

    [HttpGet("GetStorage")]
    public async Task<IActionResult> GetStorage()
    {
        var result = await _storageService.GetStorage();
        return Ok(result);
    }

    [HttpGet("GetStorageById")]
    public async Task<IActionResult> GetStorageById(int id)
    {
        var result = await _storageService.GetStorageById(id);
        return Ok(result);
    }

    [HttpPost("AddStorege")]
    public async Task<IActionResult> AddStorage([FromQuery]AddStorageDto storage)
    {
        var result = await _storageService.AddStorage(storage);
        return Ok(result);
    }

    [HttpPut("UpdateStorage")]
    public async Task<IActionResult> UpdateStorage([FromQuery]AddStorageDto storage)
    {
        var result = await _storageService.UpdateStorage(storage);
        return Ok(result);
    }

    [HttpDelete("DeleteStorege")]
    public async Task<IActionResult> DeleteStorage(int id)
    {
        var result = await _storageService.DeleteStorage(id);
        return Ok(result);
    }
}
