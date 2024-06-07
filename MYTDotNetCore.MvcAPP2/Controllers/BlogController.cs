using Microsoft.AspNetCore.Mvc;

namespace MYTDotNetCore.MvcAPP2.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndexAsync()
        {
           var response = await _HttpClient.GetAsync($"api/blog")
            return View();
        }
    }
}
