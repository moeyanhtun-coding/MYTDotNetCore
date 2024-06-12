using Microsoft.Identity.Client;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;
using MYTDotNetCore.WebApi.DepedencyInjection.Models;
using MYTDotNetCore.WebApi.DepedencyInjection.Models.BlogModel;
using MYTDotNetCore.WebApi.DepedencyInjection.Models.CustomerModel;

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

        public static TblCustomer Change(this CustomerModel requestModel)
        {
            var model = new TblCustomer()
            {
                CustomerName = requestModel.CustomerName,
                CustomerCode = Guid.NewGuid().ToString(),
                MobileNo = requestModel.MobileNo,
            };
            return model;
        }

        public static CustomerModel Change(this TblCustomer responseModel)
        {
            var model = new CustomerModel()
            {
                CustomerName = responseModel.CustomerName,
                CustomerCode = responseModel.CustomerCode,
                MobileNo = responseModel.MobileNo,
            };
            return model;
        }
    }
}
