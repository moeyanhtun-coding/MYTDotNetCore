using Microsoft.AspNetCore.Mvc;

namespace MYTDotNetCore.MvcApp3.Controllers;

public class BlogController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}