using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Db;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController()
        {
            _context = new AppDbContext();
        }

        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _context.Blogs.ToList();
            return View("BlogIndex",lst);
        }
    }
}
