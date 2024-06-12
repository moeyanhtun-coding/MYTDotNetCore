using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace MYTDotNetCore.BlazorServerApp
{
    [Table("Tbl_Customer")]
    public class TblCustomer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public string MobileNo { get; set; }
    }
}
