//using System.Text;
//using Microsoft.AspNetCore.Mvc;
//using MYTDotNetCore.MvcAPP2.Models;
//using Newtonsoft.Json;
//using static System.Net.Mime.MediaTypeNames;

//namespace MYTDotNetCore.MvcAPP2.Controllers;

//public class BlogHttpClientController : Controller
//{
//    private readonly HttpClient _httpClient;

//    public BlogHttpClientController(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//    }

//    [ActionName("Index")]
//    public async Task<IActionResult> BlogIndexAsync(int pageNo = 1, int pageSize = 10)
//    {
//        BlogResponseModel model = new BlogResponseModel();
//        HttpResponseMessage response = await _httpClient.GetAsync($"api/blog/{pageNo}/{pageSize}");
//        if (response.IsSuccessStatusCode)
//        {
//            var jsonStr = await response.Content.ReadAsStringAsync();
//            model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr)!;
//        }
//        return View("BlogIndex", model);
//    }

//    [ActionName("Create")]
//    public IActionResult BlogCreate()
//    {
//        return View("BlogCreate");
//    }

//    [HttpPost]
//    [ActionName("Save")]
//    public async Task<IActionResult> BlogSave(BlogModel blog)
//    {
//        var content = new StringContent(
//            JsonConvert.SerializeObject(blog),
//            Encoding.UTF8,
//            Application.Json
//        );
//        await _httpClient.PostAsync("api/blog", content);
//        return Redirect("/Blog");
//    }

//    [ActionName("Edit")]
//    public async Task<IActionResult> BlogEdit(int id)
//    {
//        HttpResponseMessage response = await _httpClient.GetAsync($"api/blog/{id}");
//        if (!response.IsSuccessStatusCode)
//            return Redirect("/Blog");
//        var jsonStr = await response.Content.ReadAsStringAsync();
//        BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
//        return View("BlogEdit", model);
//    }

//    [ActionName("Update")]
//    public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
//    {
//        var content = new StringContent(
//            JsonConvert.SerializeObject(blog),
//            Encoding.UTF8,
//            Application.Json
//        );
//        await _httpClient.PatchAsync($"api/blog/{id}", content);
//        return Redirect("/Blog");
//    }

//    [ActionName("Delete")]
//    public async Task<IActionResult> BlogDelete(int id)
//    {
//        await _httpClient.DeleteAsync($"api/blog/{id}");
//        return Redirect("/blog");
//    }
//}
