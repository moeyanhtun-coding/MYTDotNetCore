using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp3.Database;
using MYTDotNetCore.MvcApp3.Models;

namespace MYTDotNetCore.MvcApp3.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _context;

    public BlogController(AppDbContext context)
    {
        _context = context;
    }

    // GET
    [ActionName("Index")]
    public IActionResult BlogIndex()
    {
        var model = new BlogList();
        var lst = _context.Blogs.Select(x => x.Change()).ToList();
        model.lst = lst;
        return View("BlogIndex", model);
    }

    [ActionName("create")]
    public IActionResult BlogCreate()
    {
        return View("BlogCreate");
    }

    [HttpPost]
    [ActionName("save")]
    public IActionResult BlogSave(BlogModel model)
    {
        _context.Blogs.Add(model.Change());
        _context.SaveChanges();
        return Redirect("/blog");
    }

    [ActionName("delete")]
    public IActionResult BlogDelete(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id)!;
        _context.Blogs.Remove(item);
        _context.SaveChanges();
        return Redirect("/blog");
    }
}
