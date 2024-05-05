using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MYTDotNetCore.WebRestApi.Models;

namespace MYTDotNetCore.WebRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        private readonly SqlConnection _connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "SELECT * FROM Tbl_Blog";
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query,_connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            _connection.Close();

            //List<BlogModel> lst = new List<BlogModel>();
            //foreach ( DataRow dr in dt.Rows)
            //{
            //    BlogModel blog = new BlogModel();
            //    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);
            //    lst.Add(blog);
            //}
            //return Ok(lst);

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();

            return Ok(lst);

        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id) 
        {
            string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            _connection.Close();
            if(dt.Rows.Count == 0)
            {
                return NotFound("Data Not Found");
            }

            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
               BlogId = Convert.ToInt32(dr["BlogId"]),
               BlogTitle = Convert.ToString(dr["BlogTitle"]),
               BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
               BlogContent = Convert.ToString(dr["BlogContent"])
            };
            return Ok(item);
            
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog) 
        { 
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query,_connection);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            _connection.Close();

            string message = result > 0 ? "Blog Create Success" : "Blog Create Fail";
            return Ok(message); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog) 
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle
        ,[BlogAuthor] = @BlogAuthor
        ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            blog.BlogId = id;

            int result = cmd.ExecuteNonQuery();
            _connection.Close();

            string message = result > 0 ? "Blog Update Success" : "Blog Update Fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog) 
        { 
            string condition = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                condition += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                condition += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                condition += "[BlogContent] = @BlogContent, ";
            }
            condition = condition.Substring(0, condition.Length -2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition}
 WHERE BlogId = @BlogId";

            _connection.Open();
            SqlCommand cmd = new SqlCommand(query,_connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }
            blog.BlogId = id;

            int result = cmd.ExecuteNonQuery();

            _connection.Close();
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id) 
        {
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query,_connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            _connection.Close();
            string message = result > 0 ? "Delete Success" : "Delete Fail";

            return Ok(message);
            
        }
        
    }
}
