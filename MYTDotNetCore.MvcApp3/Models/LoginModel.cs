using System.ComponentModel.DataAnnotations;

namespace MYTDotNetCore.MvcApp3.Models;

public class LoginModel
{
    public string UserID { get; set; }
    public string SessionID { get; set; }
    public DateTime SessionExpried { get; set; }
}
