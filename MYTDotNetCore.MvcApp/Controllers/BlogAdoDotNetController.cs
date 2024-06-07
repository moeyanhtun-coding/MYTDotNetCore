using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Models;
using MYTDotNetCore.Shared;

namespace MYTDotNetCore.MvcApp.Controllers
{
    public class BlogAdoDotNetController : Controller
    {
        private readonly AdoDotNetService _adoDotNetService;

        public BlogAdoDotNetController(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }

        public IActionResult Index()
        {
            List<BlogModel> lst = _adoDotNetService.Query<BlogModel>("Select * From Tbl_Blog");
            return View(lst);
        }
    }
}
