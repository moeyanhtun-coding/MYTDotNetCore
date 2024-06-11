using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;
using MYTDotNetCore.WebApi.DepedencyInjection.Models;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Feature.Blog;

public class DA_Blog
{
    private readonly AppDbContext _context;

    public DA_Blog(AppDbContext context)
    {
        _context = context;
    }

    public async Task<BlogListResponseModel> GetBlogListAsync(int pageNo = 1, int pageSize = 10)
    {
        var response = new BlogListResponseModel();
        try
        {
            var query = _context.Blogs.AsNoTracking();
            int totalCount = query.Count();
            int pageCount = totalCount / pageSize;
            if (totalCount % pageSize > 0)
            {
                pageCount++;
            }
            var lst = await query.Pagination(pageNo, pageSize).ToListAsync();
            if (lst is null)
                throw new Exception("No Data Found");
            response = new BlogListResponseModel() { DataList = lst };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        return response;
    }

    public async Task<BlogResponseModel> GetBlogAsync(int id)
    {
        var response = new BlogResponseModel();
        try
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                response.responseMessage = "No Item Found!";
                goto result;
            }
            response.responseMessage = "Item Found!";
            response.blog = item!.Change();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        result:
        return response;
    }

    public async Task<int> CreateBlogAsync(BlogModel blogModel)
    {
        try
        {
            await _context.Blogs.AddAsync(blogModel.Change());
            var result = _context.SaveChanges();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task<int> UpdateBlogAsync(int id, BlogModel blogModel)
    {
        try
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
                return 0;
            if (!string.IsNullOrEmpty(blogModel.BlogTitle))
                item.BlogTitle = blogModel.BlogTitle;
            if (!string.IsNullOrEmpty(blogModel.BlogAuthor))
                item.BlogAuthor = blogModel.BlogAuthor;
            if (!string.IsNullOrEmpty(blogModel.BlogContent))
                item.BlogContent = blogModel.BlogContent;
            var result = _context.SaveChanges();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task<int> DeleteBlogAsync(int id)
    {
        try
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id)!;
            if (item is null)
                return 0;
            _context.Blogs.Remove(item);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
