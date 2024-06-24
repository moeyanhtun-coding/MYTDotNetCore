using System.ComponentModel.DataAnnotations;

namespace MYTDotNetCore.MvcApp3.Models
{
    public class UserModel
    {
        public string UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
