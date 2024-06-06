using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.MvcApp.Db;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Controllers
{
    public class BlogPaginationController : Controller
    {
        private readonly AppDbContext _db;

        public BlogPaginationController(AppDbContext db)
        {
            _db = db;
        }

        [ActionName("Index")]
        public IActionResult BlogIndex(int pageNo = 1, int pageSize = 10)
        {
            var lst = _db.Blogs.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            int rowCount = _db.Blogs.Count();
            int pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
            {
                pageCount++;
            }
            if (pageNo > pageCount)
            {
                return Redirect("/Blog");
            }
            BlogResponseModel model = new();
            model.Data = lst;
            model.PageSize = pageSize;
            model.PageNo = pageNo;
            model.PageCount = pageCount;

            return View("BlogIndex",model);
        }
    }
}
 