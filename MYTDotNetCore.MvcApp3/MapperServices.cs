using MYTDotNetCore.MvcApp3.Database;
using MYTDotNetCore.MvcApp3.Models;

namespace MYTDotNetCore.MvcApp3;

public static class MapperServices
{
    public static TblBlogs Change(this BlogModel requestModel)
    {
        var model = new TblBlogs()
        {
            BlogId = requestModel.BlogId,
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent
        };
        return model;
    }

    public static BlogModel Change(this TblBlogs requestModel)
    {
        var model = new BlogModel()
        {
            BlogId = requestModel.BlogId,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent,
            BlogTitle = requestModel.BlogTitle
        };
        return model;
    }
}