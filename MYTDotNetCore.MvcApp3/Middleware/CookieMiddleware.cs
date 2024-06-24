using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.MvcApp3.Database;

namespace MYTDotNetCore.MvcApp3.Middleware;

public class CookieMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppDbContext _context;

    public CookieMiddleware(RequestDelegate next, AppDbContext context)
    {
        _next = next;
        _context = context;
    }

    //public async Task InvokeAsync(HttpContext context)
    //{
    //    string url = context.Request.Path.ToString().ToLower();
    //    if (url == "/login" || url == "/login/index" || url == "/signup/index" || url == "/signup")
    //    {
    //        goto Results;
    //    }
    //    string userName = context.Request.Cookies["UserName"]!;
    //    if (string.IsNullOrEmpty(userName))
    //    {
    //        context.Response.Redirect("/login");
    //    }
    //    Results:
    //    await _next(context);
    //}

    public async Task InvokeAsync(HttpContext context)
    {
        string url = context.Request.Path.ToString().ToLower();
        if (url == "/login" || url == "/login/index" || url == "/signup/index" || url == "/signup")
        {
            goto Results;
        }

        var cookies = context.Request.Cookies;
        if (cookies["UserId"] is null || cookies["SessionId"] is null)
        {
            context.Response.Redirect("/login");
            goto Results;
        }

        string userId = cookies["UserId"]!.ToString();
        string sessionId = cookies["SessionId"]!.ToString();

        var login = await _context.Login.FirstOrDefaultAsync(x =>
            x.SessionID == sessionId && x.UserID == userId
        );

        if (login is null)
        {
            context.Response.Redirect("/login");
            goto Results;
        }

        if (DateTime.Now > login.SessionExpired)
        {
            context.Response.Redirect("/login");
            goto Results;
        }
        Results:
        await _next(context);
    }
}
