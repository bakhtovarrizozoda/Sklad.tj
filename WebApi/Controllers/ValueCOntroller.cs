using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;
[Route("controller")]
public class ValueCOntroller : Controller
{
    private DataContext _context;

    public ValueCOntroller(DataContext dbct)
    {
        _context = dbct;
    }
    // GET
    [HttpGet("create-db")]
    public IActionResult Index()
    {
        _context.Database.EnsureCreated();
        return Ok();
    }
}