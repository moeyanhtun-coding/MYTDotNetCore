using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MYTDotNetCore.Shared2;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;
using MYTDotNetCore.WebApi.DepedencyInjection.Feature.Blog;
using MYTDotNetCore.WebApi.DepedencyInjection.Models.BlogModel;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Controllers;

[Route("apiV1/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly BL_Blog _bL_Blog;
    private readonly AppDbContext _context;

    public BlogController(AppDbContext context, BL_Blog bL_Blog)
    {
        _context = context;
        _bL_Blog = bL_Blog;
    }

    [HttpGet("{pageNo}/{pageSize}")]
    public async Task<IActionResult> GetBlogListAsync(int pageNo, int pageSize)
    {
        var response = new BlogListResponseModel();
        try
        {
            response = await _bL_Blog.GetBlogListAsync(pageNo, pageSize);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync(BlogModel blogModel)
    {
        try
        {
            int result = await _bL_Blog.CreateBlogAsync(blogModel);
            var message = (result > 0) ? "Creating Successful" : "Creating Fail";
            return Ok(message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogAsync(int id)
    {
        try
        {
            var item = await _bL_Blog.GetBlogAsync(id);
            if (item == null)
                return NotFound("No Item Found");
            return Ok(item);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateBlogAsync(int id, BlogModel blogModel)
    {
        try
        {
            var result = await _bL_Blog.UpdateBlogAsync(id, blogModel);
            var message = result > 0 ? "Updating Successful" : "Updating Fail";
            return Ok(message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogAsync(int id)
    {
        try
        {
            var result = await _bL_Blog.DeleteBlogAsync(id);
            var message = result > 0 ? "Deleting Successful" : "Deleting Fail";
            return Ok(message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
