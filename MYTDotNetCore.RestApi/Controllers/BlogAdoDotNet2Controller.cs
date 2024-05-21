using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MYTDotNetCore.RestApi.Models;
using MYTDotNetCore.Shared;

namespace MYTDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogAdoDotNet2Controller : ControllerBase
{
    private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(
        ConnectionStrings.SqlConnectionStringBuilder.ConnectionString
    );
    private readonly SqlConnection _connection = new SqlConnection(
        ConnectionStrings.SqlConnectionStringBuilder.ConnectionString
    );

    [HttpGet]
    public IActionResult GetBlog()
    {
        string query = "SELECT * FROM Tbl_Blog";
        var lst = _adoDotNetService.Query<BlogModel>(query);
        return Ok(lst);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(int id)
    {
        string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
        //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
        //parameters[0] = new AdoDotNetParameter("@BLogId", id);
        //var item = _adoDotNetService.Query<BlogModel>(query, parameters);
        var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(
            query,
            new AdoDotNetParameter("@BlogId", id)
        );
        if (item is null)
        {
            return NotFound("Not Found");
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateBlog(BlogModel blog)
    {
        string query =
            @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

        var result = _adoDotNetService.Execute(
            query,
            new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
            new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
            new AdoDotNetParameter("@BlogContent", blog.BlogContent)
        );

        string message = result > 0 ? "Blog Create Success" : "Blog Create Fail";
        return Ok(message);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBlog(int id, BlogModel blog)
    {
        string query =
            @"UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle
        ,[BlogAuthor] = @BlogAuthor
        ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

        var result = _adoDotNetService.Execute(
            query,
            new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
            new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
            new AdoDotNetParameter("@BlogContent", blog.BlogContent)
        );

        string message = result > 0 ? "Blog Update Success" : "Blog Update Fail";
        return Ok(message);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(int id, BlogModel blog)
    {
        List<AdoDotNetParameter> lst = new List<AdoDotNetParameter>();
        string condition = string.Empty;
        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            condition += "[BlogTitle] = @BlogTitle, ";
            lst.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
        }
        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            condition += "[BlogAuthor] = @BlogAuthor, ";
            lst.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
        }
        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            condition += "[BlogContent] = @BlogContent, ";
            lst.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
        }
        condition = condition.Substring(0, condition.Length - 2);

        string query =
            $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition}
 WHERE BlogId = @BlogId";

        lst.Add(new AdoDotNetParameter("@BlogId", id));

        int result = _adoDotNetService.Execute(query,lst.ToArray());
        string message = result > 0 ? "Update Success" : "Update Fail";
        return Ok(message);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(int id)
    {
        string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
        var result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));
        string message = result > 0 ? "Delete Success" : "Delete Fail";

        return Ok(message);
    }
}
