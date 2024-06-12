using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sql;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MYTDotNetCore.RestApi.Db;
using MYTDotNetCore.RestApi.Models;
using Newtonsoft.Json;

namespace MYTDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly ILogger<BlogController> _logger;
    private readonly AppDbContext _context;

    public BlogController(ILogger<BlogController> logger = null)
    {
        _context = new AppDbContext();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Read()
    {
        var lst = _context.Blogs.OrderByDescending(x => x.BlogId).ToList();
        _logger.LogInformation(JsonConvert.SerializeObject(lst, Formatting.Indented));
        _logger.LogInformation(lst.Count().ToString(), Formatting.Indented);
        return Ok(lst);
    }

    [HttpGet("{pageNo}/{pageSize}")]
    public IActionResult GetBlog(int pageNo, int pageSize)
    {
        var lst = _context.Blogs.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

        int rowCount = _context.Blogs.Count();
        int pageCount = rowCount / pageSize;
        if (rowCount % pageSize > 0)
        {
            pageCount++;
        }
        if (pageNo > pageCount)
            return BadRequest(new { message = "Invalid Page No" });
        BlogResponseModel model = new();
        model.Data = lst;
        model.PageSize = pageSize;
        model.PageNo = pageNo;
        model.PageCount = pageCount;

        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("no data found");
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateBlog([FromBody] BlogModel blog)
    {
        if (blog == null || !ModelState.IsValid)
        {
            return BadRequest("Invalid blog data.");
        }

        _context.Blogs.Add(blog);
        int result = _context.SaveChanges();
        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        return Ok(message);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, BlogModel blog)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("Data Not Found");
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        _context.Blogs.Update(item);
        int result = _context.SaveChanges();
        var message = result > 0 ? "Updated Success" : "Updated Fail";
        return Ok(message);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, BlogModel blog)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("Data Not Found");
        }

        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            item.BlogTitle = blog.BlogTitle;
        }
        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            item.BlogAuthor = blog.BlogAuthor;
        }
        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            item.BlogContent = blog.BlogContent;
        }
        _context.Blogs.Update(item);
        int result = _context.SaveChanges();
        var message = result > 0 ? "Updated Success" : "Updated Fail";
        return Ok(message);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("No Dtat Found");
        }

        _context.Blogs.Remove(item);
        int result = _context.SaveChanges();
        var message = result > 0 ? "Deleted Success" : "Deleted Fail";
        return Ok(message);
    }
}
