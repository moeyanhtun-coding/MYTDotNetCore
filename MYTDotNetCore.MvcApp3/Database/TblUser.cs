using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYTDotNetCore.MvcApp3.Database;

[Table("Tbl_User1")]
public class TblUser
{
    [Key]
    public string UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
