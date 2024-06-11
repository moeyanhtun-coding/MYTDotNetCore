using MYTDotNetCore.WebApi.DepedencyInjection.Models;

namespace MYTDotNetCore.WebApi.DepedencyInjection
{
    public static class MapperService
    {
        public static TblBlog Change(this BlogModel requestModel)
        {
            var model = new TblBlog()
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent,
            };
            return model;
        }

        public static BlogModel Change(this TblBlog responseModel)
        {
            var model = new BlogModel()
            {
                BlogTitle = responseModel.BlogTitle,
                BlogAuthor = responseModel.BlogAuthor,
                BlogContent = responseModel.BlogContent,
            };
            return model;
        }
    }
}
