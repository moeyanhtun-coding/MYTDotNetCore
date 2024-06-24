using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYTDotNetCore.MvcApp3.Database;

[Table("Tbl_Login")]
public class TblLogin
{
    [Key]
    public int Id { get; set; }
    public string UserID { get; set; }
    public string SessionID { get; set; }
    public DateTime SessionExpired { get; set; }
}
