// See https://aka.ms/new-console-template for more information
using MYTDotNetCore.ConsoleAppHttpClientExample;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


Console.WriteLine("Hello, World!");

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7088/api/blog");

//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;

//    foreach (var blog in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(blog));
//        Console.WriteLine($"Content => "+ blog.BlogContent);
//    }
//}

HttpClientExample httpClientExample = new HttpClientExample();
httpClientExample.RunAsync().Wait();
Console.ReadLine();



      