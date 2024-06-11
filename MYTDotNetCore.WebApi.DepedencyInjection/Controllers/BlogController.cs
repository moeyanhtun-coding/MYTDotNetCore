using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.Shared2;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly AppDbContext _context;

    public BlogController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("BlogList/{pageNo}/{pageSize}")]
    public async Task<IActionResult> GetBlogList(int pageNo, int pageSize)
    {
        return Ok();
    }
}
