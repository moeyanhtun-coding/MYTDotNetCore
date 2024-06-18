using MYTDotNetCore.MinimalApi.Models;

namespace MYTDotNetCore.MinimalApi;

    public static class ChangeModel
    {
        public static TblBlog Change(this BlogRequestModel model)
        {
            return new TblBlog
            {
                BlogTitle = model.BlogTitle,
                BlogAuthor = model.BlogAuthor,
                BlogContent = model.BlogContent,
            };
        }
    }

