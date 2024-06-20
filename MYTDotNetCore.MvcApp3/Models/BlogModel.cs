namespace MYTDotNetCore.MvcApp3.Models;

public class BlogModel
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}

public class BlogList
{
    public List<BlogModel> lst { get; set; }
}
