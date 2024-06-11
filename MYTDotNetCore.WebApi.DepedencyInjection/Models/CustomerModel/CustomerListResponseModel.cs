using Microsoft.Identity.Client;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Models.CustomerModel
{
    public class CustomerListResponseModel
    {
        public List<TblCustomer> DataList { get; set; }
    }
}
