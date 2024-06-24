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

    public static TblUser Change(this UserModel requestModel)
    {
        var model = new TblUser()
        {
            UserID = Guid.NewGuid().ToString(),
            UserName = requestModel.UserName,
            Password = requestModel.Password,
        };
        return model;
    }

    public static TblLogin Change(
        this LoginModel requestModel,
        string UserId,
        string sessionId,
        DateTime sessionExpried
    )
    {
        var model = new TblLogin()
        {
            UserID = UserId,
            SessionID = sessionId,
            SessionExpired = sessionExpried,
        };
        return model;
    }
}
