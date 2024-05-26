 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;

namespace MYTDotNetCore.ConsoleAppHttpClientExample;

internal class RestClientExample
{
    private readonly RestSharp.RestClient _client = new RestSharp.RestClient(
        new Uri("https://localhost:7088/")
    );
    private readonly string _blogEndPoint = "api/blog";

    public async Task RunAsync()
    {
        await CreateAsync(
            "blog rest client title",
            "blog rest client Author",
            "blog rest Client content"
        );
        await UpdateAsync(
            22,
            "blog rest client title",
            "blog rest client Author",
            "blog rest Client content"
        );
        await PatchAsync(19, "blog rest patch client title", null, null);
        await ReadAsync();
    }

    private async Task ReadAsync()
    {
        //RestRequest restRequest = new RestRequest(_blogEndPoint);
        //var response = await _clint.GetAsync(restRequest);

        RestRequest restRequest = new RestRequest(_blogEndPoint, Method.Get);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
            foreach (var blog in lst)
            {
                Console.WriteLine("Blog ID => " + blog.BlogId);
                Console.WriteLine($"Blog Title => " + blog.BlogTitle);
                Console.WriteLine($"Blog Author => " + blog.BlogAuthor);
                Console.WriteLine($"Blog Content => " + blog.BlogContent);
                Console.WriteLine("===========================================");
            }
        }
    }

    private async Task EditAsync(int id)
    {
        RestRequest restClient = new RestRequest($"{_blogEndPoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync(restClient);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            var blog = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;
            Console.WriteLine($"Blog Title => " + blog.BlogTitle);
            Console.WriteLine($"Blog Author => " + blog.BlogAuthor);
            Console.WriteLine($"Blog Content => " + blog.BlogContent);
            Console.WriteLine("===========================================");
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogDto blog = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        RestRequest restRequest = new RestRequest(_blogEndPoint, Method.Post);
        restRequest.AddJsonBody(blog);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            var message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            var message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        BlogDto blog = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Put);
        restRequest.AddJsonBody(blog);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task PatchAsync(int id, string? title, string? author, string? content)
    {
        BlogDto blog = new BlogDto();
        if (!string.IsNullOrEmpty(title))
        {
            blog.BlogTitle = title;
        }
        if (!string.IsNullOrEmpty(author))
        {
            blog.BlogAuthor = author;
        }
        if (!string.IsNullOrEmpty(content))
        {
            blog.BlogContent = content;
        }

        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Patch);
        restRequest.AddJsonBody(blog);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }
}
