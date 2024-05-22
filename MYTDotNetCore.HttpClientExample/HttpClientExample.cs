using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MYTDotNetCore.ConsoleAppHttpClientExample
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7088/")
        };
        private readonly string _blogEndPoint = "api/blog";

        public async Task RunAsync()
        {
            //await EditAsync(9);
            //await EditAsync(100);
            //await DeletAsync(7);
            //await CreateAsync("blog title", "blog author", " blog content");
            await PatchAsync(20, "this is update hello title", null, null);
            await ReadAsync();
        }

        private async Task ReadAsync()
        {
            var response = await _client.GetAsync(_blogEndPoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
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
            var response = await _client.GetAsync($"{_blogEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var blog = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;
                Console.WriteLine($"Blog Title => " + blog.BlogTitle);
                Console.WriteLine($"Blog Author => " + blog.BlogAuthor);
                Console.WriteLine($"Blog Content => " + blog.BlogContent);
                Console.WriteLine("===========================================");
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
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
            var blogJson = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);

            var response = await _client.PostAsync(_blogEndPoint, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
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
            var blogJson = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_blogEndPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
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

            var blogJson = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PatchAsync($"{_blogEndPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeletAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_blogEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
