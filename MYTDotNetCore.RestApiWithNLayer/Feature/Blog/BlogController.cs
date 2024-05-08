using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.RestApiWithNLayer.Models;

namespace MYTDotNetCore.RestApiWithNLayer.Feature.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bl_blog;

        public BlogController()
        {
            _bl_blog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _bl_blog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = _bl_blog.GetBlog(id);
            if(item is null)
            {
                return NotFound("Data not found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel requestModel)
        {
           int result = _bl_blog.CreateBlog(requestModel);
           string message = result > 0 ? "Blog Create Success" : "Blog Create Fail";
           return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id , BlogModel requestModel)
        {
            int result = _bl_blog.UpdateBlog(id, requestModel);
            string message = result > 0 ? "Update Blog Success" : "Update Blog Fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel requestModel)
        {
            int result = _bl_blog.PatchBlog(id, requestModel);
            string message = result > 0 ? "Update Blog Success" : "Update Blog Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            int result = _bl_blog.DeleteBlog(id);
            string message = result > 0 ? "Delete Blog Success" : "Delete Blog Fail";
            return Ok(message);
        }
    }
}
