using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Db;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Controllers;

public class BlogAjaxController : Controller
{
    private readonly AppDbContext _context;

    public BlogAjaxController()
    {
        _context = new AppDbContext();
    }

    [ActionName("Index")]
    public IActionResult BlogIndex()
    {
        List<BlogModel> lst = _context.Blogs.ToList();
        return View("BlogIndex", lst);
    }

    [ActionName("Edit")]
    public IActionResult BlogEdit(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }
        return View("BlogEdit", item);
    }

    [ActionName("Create")]
    public IActionResult BlogCreate()
    {
        return View("BlogCreate");
    }

    [HttpPost]
    [ActionName("Save")]
    public IActionResult BlogSave(BlogModel blog)
    {
        _context.Blogs.Add(blog);
        int result = _context.SaveChanges();
        string message = result > 0 ? "Creating Successful." : "Creating Failed";
        BlogMessageResponseModel model = new BlogMessageResponseModel()
        {
            IsSuccess = result > 0,
            Message = message
        };
        return Json(model);
    }

    [HttpPost]
    [ActionName("Update")]
    public IActionResult BlogUpdate(int id, BlogModel blog)
    {
        BlogMessageResponseModel model = new BlogMessageResponseModel();
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            model.IsSuccess = false;
            model.Message = "Data Not Found";
            return Json(model);
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;
        int result = _context.SaveChanges();
        string message = result > 0 ? "Updating Successful." : "Updating Failed";

        model.IsSuccess = result > 0;
        model.Message = message;
        return Json(model);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult BlogDelete(BlogModel blog)
    {
        BlogMessageResponseModel model = new BlogMessageResponseModel();
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == blog.BlogId);
        if (item is null)
        {
            model.IsSuccess = false;
            model.Message = "Data Not Found";
            return Json(model);
        }
        _context.Blogs.Remove(item);
        int result = _context.SaveChanges();
        string message = result > 0 ? "Deleting Successful." : "Deleting Failed";

        model.IsSuccess = result > 0;
        model.Message = message;
        return Json(model);
    }
}
