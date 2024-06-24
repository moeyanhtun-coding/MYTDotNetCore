namespace MYTDotNetCore.MvcApp3.Middleware;

public class CookieMiddleware
{
    private readonly RequestDelegate _next;

    public CookieMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string url = context.Request.Path.ToString().ToLower();
        if (url == "/login" || url == "/login/index")
        {
            goto Results;
        }
        string userName = context.Request.Cookies["UserName"]!;
        if (string.IsNullOrEmpty(userName))
        {
            context.Response.Redirect("/login");
        }
        Results:
        await _next(context);
    }
}
