using Azure;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.WebApi.DepedencyInjection.Models;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Feature.Blog;

public class BL_Blog
{
    private readonly DA_Blog _dA_blog;

    public BL_Blog(DA_Blog dA_blog)
    {
        this._dA_blog = dA_blog;
    }

    public async Task<BlogListResponseModel> GetBlogListAsync(int pageNo, int pageSize)
    {
        var response = new BlogListResponseModel();
        try
        {
            response = await _dA_blog.GetBlogListAsync(pageNo, pageSize);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        return response;
    }

    public async Task<BlogResponseModel> GetBlogAsync(int id)
    {
        try
        {
            var item = await _dA_blog.GetBlogAsync(id);
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task<int> CreateBlogAsync(BlogModel blogModel)
    {
        try
        {
            int result = await _dA_blog.CreateBlogAsync(blogModel);
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
            int result = await _dA_blog.UpdateBlogAsync(id, blogModel);
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
            var result = await _dA_blog.DeleteBlogAsync(id);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
