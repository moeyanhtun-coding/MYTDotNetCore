using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYTDotNetCore.RestApi.Models;
using Refit;

namespace MYTDotNetCore.ConsoleAppRefitExamples;

public class RefitExample
{
    private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7114");

    public async Task RunAsync() 
    {
        await CreateAsync("refit title", "refit author", "refit content");
        await EditAsync(17);
        await PatchAsync(17, "refit update Patch Title", null, null);
        await EditAsync(17);
        await DeleteAsync(17);
        await EditAsync(17);
    }

    private async Task ReadAsync()
    {
        try
        {
            var lst = await _service.GetBlogs();
            foreach (var blog in lst)
            {
                Console.WriteLine("Blog ID => " + blog.BlogId);
                Console.WriteLine($"Blog Title => " + blog.BlogTitle);
                Console.WriteLine($"Blog Author => " + blog.BlogAuthor);
                Console.WriteLine($"Blog Content => " + blog.BlogContent);
                Console.WriteLine("===========================================");
            }
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task EditAsync(int id)
    {
        try
        {
            var item = await _service.GetBlog(id);
            Console.WriteLine("Blog ID => " + item.BlogId);
            Console.WriteLine($"Blog Title => " + item.BlogTitle);
            Console.WriteLine($"Blog Author => " + item.BlogAuthor);
            Console.WriteLine($"Blog Content => " + item.BlogContent);
            Console.WriteLine("===========================================");
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await _service.CreateBlog(blog);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            var message = await _service.UpdateBlog(id, blog);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task PatchAsync(int id, string? title, string? author, string? content)
    {
        try
        {
            BlogModel blog = new BlogModel();
            if (!string.IsNullOrEmpty(title))
            {
                blog.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                blog.BlogTitle = author;
            }
            if (!string.IsNullOrEmpty(content))
            {
                blog.BlogTitle = content;
            }
            var message = await _service.PatchBlog(id, blog);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        try
        {
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
