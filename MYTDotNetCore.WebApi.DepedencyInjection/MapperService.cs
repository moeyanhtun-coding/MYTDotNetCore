using MYTDotNetCore.WebApi.DepedencyInjection.Models;

namespace MYTDotNetCore.WebApi.DepedencyInjection
{
    public static class MapperService
    {
        public static BlogModel Change(this TblBlog requestModel)
        {
            var model = new BlogModel()
            {
                BlogId = Ulid.NewUlid().ToString(),
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent,
            };
            return model;
        }

        public static BlogRequestModel Chage(this TblBlog requestModel)
        {
            var model = new BlogRequestModel()
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent,
            };
            return model;
        }
    }
}
