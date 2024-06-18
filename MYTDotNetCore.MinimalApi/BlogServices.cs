namespace MYTDotNetCore.MinimalApi;

public class MinimalApi
{
    
    private static string EndPoint = "/api/blog";
    public static IEndpointRouteBuilder  MapMethod(this IEndpointRouteBuilder app)
    {
        app.MapGet(EndPoint, async (AppDbContext db))
    }
}