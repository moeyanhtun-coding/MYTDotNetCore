using System.ComponentModel.DataAnnotations;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Models.CustomerModel
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public string MobileNo { get; set; }
    }
}
