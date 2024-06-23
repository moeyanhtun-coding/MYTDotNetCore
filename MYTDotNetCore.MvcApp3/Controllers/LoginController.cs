using Microsoft.AspNetCore.Mvc;

namespace MYTDotNetCore.MvcApp3.Controllers;

public class LoginController : Controller
{
    [ActionName("Index")]
    public IActionResult LoginIndex()
    {
        return View("LoginIndex");
    }
}
