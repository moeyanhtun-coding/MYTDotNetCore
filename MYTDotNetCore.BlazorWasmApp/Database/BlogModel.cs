namespace MYTDotNetCore.BlazorWasmApp.Database;

public class BlogModel
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}

public class ListBlogModel
{
    public ListBlogModel Blogs { get; set; }
}

public class ResponseModel
{
    public string responseMessage { get; set; }
}
