using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp3.Models;

namespace MYTDotNetCore.MvcApp3.Controllers;

public class LoginController : Controller
{
    [ActionName("Index")]
    public IActionResult LoginIndex()
    {
        return View("LoginIndex");
    }

    [HttpPost]
    [ActionName("Index")]
    public IActionResult LoginIndex(LoginModel reqModel)
    {
        CookieOptions opt = new CookieOptions();
        opt.Expires = DateTime.Now.AddSeconds(10);
        Response.Cookies.Append("UserName", reqModel.UserName, opt);
        return Redirect("/Home");
    }
}
