using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Models;
using MYTDotNetCore.Shared;

namespace MYTDotNetCore.MvcApp.Controllers
{
    public class BlogDapperController : Controller
    {
        private readonly DapperService _dapperService;

        public BlogDapperController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public IActionResult Index()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>("Select * From Tbl_Blog");
            return View(lst);
        }
    }
}
