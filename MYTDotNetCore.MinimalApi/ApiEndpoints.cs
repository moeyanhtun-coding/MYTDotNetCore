using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using MYTDotNetCore.MinimalApi.Models;
using Newtonsoft.Json;
using Serilog;

namespace MYTDotNetCore.MinimalApi
{
    public static class ApiEndpoints
    {
        private static string EndPoint = "/api/blog";

        public static void MapApiEndpoints(this WebApplication app)
        {
            app.MapGet(EndPoint, GetBlogs).WithName("GetBlogs").WithOpenApi();
            app.MapGet(EndPoint + "/{pageNo}/{pageSize}", GetBlogsWithPagination)
                .WithName("GetBlogsWithPagination")
                .WithOpenApi();
            app.MapGet(EndPoint + "/{id}", GetBlog).WithName("GetBlog").WithOpenApi();
            app.MapPost(EndPoint, CreateBlog).WithName("CreateBlog").WithOpenApi();
            app.MapPatch(EndPoint + "/{id}", UpdateBlog).WithName("UpdateBlog").WithOpenApi();
            app.MapDelete(EndPoint + "/{id}", DeleteBlog).WithName("DeleteBlog").WithOpenApi();
        }

        private static IResult GetBlogs(AppDbContext _db)
        {
            List<TblBlog> lst = _db.Blogs.AsNoTracking().ToList();
            return Results.Ok(lst);
        }

        private static IResult GetBlogsWithPagination(AppDbContext _db, int pageNo, int pageSize)
        {
            int rowCount = _db.Blogs.Count();
            int pageCount = rowCount / pageSize;

            if (rowCount % pageSize > 0)
                pageCount++;

            if (pageNo > pageCount)
                return Results.BadRequest(new { Message = "Invalid PageNo." });

            List<TblBlog> lst = _db.Blogs.Pagination(pageNo, pageSize).ToList();
            Log.Information(JsonConvert.SerializeObject(lst));

            return Results.Ok(lst);
        }

        private static IResult CreateBlog(AppDbContext _db, BlogModel blog)
        {
            _db.Blogs.Add(blog.Change());
            int result = _db.SaveChanges();

            var message = result > 0 ? "Creating Successful" : "Creating fail";

            return Results.Ok(message);
        }

        private static IResult GetBlog(AppDbContext _db, int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
                return Results.BadRequest(new { Message = "Item Not Found!!" });

            return Results.Ok(item);
        }

        private static IResult UpdateBlog(AppDbContext _db, int id, BlogModel blog)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id)!;

            if (item is null)
                return Results.BadRequest(new { Message = "Item Not Found!!" });

            if (!string.IsNullOrEmpty(blog.BlogTitle))
                item.BlogTitle = blog.BlogTitle;

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
                item.BlogAuthor = blog.BlogAuthor;

            if (!string.IsNullOrEmpty(blog.BlogContent))
                item.BlogContent = blog.BlogContent;

            _db.Blogs.Update(item);
            int result = _db.SaveChanges();
            var message = result > 0 ? "Updating Successful" : "Updating fail";
            return Results.Ok(message);
        }

        private static IResult DeleteBlog(AppDbContext _db, int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id)!;

            if (item is null)
                return Results.BadRequest(new { Message = "Item Not Found!!" });

            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();

            var message = result > 0 ? "Deleting Successful" : "Deleting fail";

            return Results.Ok(message);
        }
    }
}
