using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.MinimalApi.Models;

namespace MYTDotNetCore.MinimalApi;

public static class BlogServices
{
    
    private static string EndPoint = "/api/blog";
    public static IEndpointRouteBuilder  MapBlogs(this IEndpointRouteBuilder app)
    {
        app.MapGet(EndPoint, async (AppDbContext db) =>
        {
            var lst = await db.Blogs.AsNoTracking().ToListAsync();
            return Results.Ok(lst);
        }).WithName("BlogList").WithOpenApi();
        
        app.MapGet(EndPoint + "/{id}", async (AppDbContext db, int id) =>
        {
            var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            return Results.Ok(item);
        }).WithName("BlogGet").WithOpenApi();
        
        app.MapPost(EndPoint, async (AppDbContext db, BlogRequestModel requestModel) =>
        {
            await db.Blogs.AddAsync(requestModel.Change());
            int result = await db.SaveChangesAsync();
            var message = result > 0 ? "Creating Successful!" : "Creating Fail!";
            return Results.Ok(message);
        }).WithName("BlogCreate").WithOpenApi();
        
        app.MapPatch(EndPoint + "/{id}", async (AppDbContext db, int id, BlogRequestModel requestModel) =>
        {
            var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
                item!.BlogTitle = requestModel.BlogTitle;
            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
                item!.BlogAuthor = requestModel.BlogAuthor;
            if (string.IsNullOrEmpty(requestModel.BlogContent))
                item!.BlogContent = requestModel.BlogContent;

            db.Blogs.Update(item!);
            int result = await db.SaveChangesAsync();
            var message = result > 0 ? "Updating Successful!" : "Updating Fail";
            return Results.Ok(message);
        }).WithName("BlogUpdate").WithOpenApi();

        app.MapDelete(EndPoint + "/{id}", async (AppDbContext db, int id) =>
        {
            var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            db.Blogs.Remove(item!);
            int result = await db.SaveChangesAsync();
            
            var message = result > 0 ? "Deleting Successful!" : "Deleting Fail!";
            return Results.Ok(message);
        }).WithName("BlogDelete").WithOpenApi();
        return app;
    }
}