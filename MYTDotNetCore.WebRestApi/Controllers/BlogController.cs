﻿using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.WebRestApi.Db;
using MYTDotNetCore.WebRestApi.Models;

namespace MYTDotNetCore.WebRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("no data found");
            }
            return Ok(item);
        }

        [HttpPost]

        public IActionResult Create(BlogModel blog) {
            _context.Blogs.Add(blog);
            int result = _context.SaveChanges();
            var message = result > 0 ? "Created Success" : "Created Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id , BlogModel blog) {
           var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) {
                return NotFound("Data Not Found");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor= blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
          
            _context.Blogs.Update(item);
            int result = _context.SaveChanges();
            var message = result > 0 ? "Updated Success" : "Updated Fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog){
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("Data Not Found");
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle)) 
            {
                item.BlogTitle = blog.BlogTitle;
            }     
            if (!string.IsNullOrEmpty(blog.BlogAuthor)) 
            {
                item.BlogAuthor = blog.BlogAuthor;
            }     
            if (!string.IsNullOrEmpty(blog.BlogContent)) 
            {
                item.BlogContent = blog.BlogContent;
            }
            _context.Blogs.Update(item);
            int result = _context.SaveChanges();
            var message = result > 0 ? "Updated Success" : "Updated Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) {
                return NotFound("No Dtat Found");           
                    }

            _context.Blogs.Remove(item);
            int result = _context.SaveChanges();
            var message = result > 0 ? "Deleted Success" : "Deleted Fail";
            return Ok(message);

        }
    }
}
