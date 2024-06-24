using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.MvcApp3.Database;
using MYTDotNetCore.MvcApp3.Models;

namespace MYTDotNetCore.MvcApp3.Controllers;

public class LoginController : Controller
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    [ActionName("Index")]
    public IActionResult LoginIndex()
    {
        return View("LoginIndex");
    }

    [HttpPost]
    [ActionName("Index")]
    public async Task<IActionResult> LoginIndex(UserModel reqModel)
    {
        var model = new LoginModel();
        var item = await _context.Users.FirstOrDefaultAsync(x =>
            x.UserName == reqModel.UserName && x.Password == reqModel.Password
        );
        if (item is null)
            return Redirect("/login");

        string sessionId = Guid.NewGuid().ToString();
        DateTime sessionExpire = DateTime.Now.AddMinutes(1);
        CookieOptions cookie = new CookieOptions();
        cookie.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Append("UserId", item.UserID, cookie);
        Response.Cookies.Append("SessionId", sessionId, cookie);

        await _context.Login.AddAsync(
            new TblLogin
            {
                UserID = item.UserID,
                SessionID = sessionId,
                SessionExpired = sessionExpire,
            }
        );
        await _context.SaveChangesAsync();

        return Redirect("/Home");
    }
}
