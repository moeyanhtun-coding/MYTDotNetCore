//using System.Text;
//using Microsoft.AspNetCore.Mvc;
//using MYTDotNetCore.MvcAPP2.Models;
//using Newtonsoft.Json;
//using RestSharp;
//using static System.Net.Mime.MediaTypeNames;

//namespace MYTDotNetCore.MvcAPP2.Controllers;

//public class BlogController : Controller
//{
//    private readonly RestClient _restClient;
//    private readonly string _blogEndPoint = "/api/blog";

//    public BlogController(RestClient httpClient)
//    {
//        _restClient = httpClient;
//    }

//    [ActionName("Index")]
//    public async Task<IActionResult> BlogIndexAsync(int pageNo = 1, int pageSize = 10)
//    {
//        BlogResponseModel model = new BlogResponseModel();
//        RestRequest restRequest = new RestRequest(
//            $"{_blogEndPoint}/{pageNo}/{pageSize}",
//            Method.Get
//        );
//        var response = await _restClient.ExecuteAsync(restRequest);
//        if (response.IsSuccessStatusCode)
//        {
//            var jsonStr = response.Content;
//            model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr!)!;
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
//        RestRequest restRequest = new(_blogEndPoint, Method.Post);
//        restRequest.AddJsonBody(blog);
//        var response = await _restClient.ExecuteAsync(restRequest);
//        if (!response.IsSuccessStatusCode)
//            return Redirect("/Blog");
//        return Redirect("/Blog");
//    }

//    [ActionName("Edit")]
//    public async Task<IActionResult> BlogEdit(int id)
//    {
//        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Get);
//        var response = await _restClient.ExecuteAsync(restRequest);
//        if (!response.IsSuccessStatusCode)
//            return Redirect("/Blog");
//        var jsonStr = response.Content;
//        BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonStr!)!;
//        return View("BlogEdit", model);
//    }

//    [ActionName("Update")]
//    public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
//    {
//        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Put);
//        restRequest.AddJsonBody(blog);
//        var response = await _restClient.PutAsync(restRequest);
//        if (!response.IsSuccessStatusCode)
//            throw new Exception("Update Fail");
//        return Redirect("/Blog");
//    }

//    [ActionName("Delete")]
//    public async Task<IActionResult> BlogDelete(int id)
//    {
//        RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Delete);
//        var response = await _restClient.DeleteAsync(request);
//        if (!response.IsSuccessStatusCode)
//            throw new Exception("Delete Fail.");
//        return Redirect("/blog");
//    }
//}
