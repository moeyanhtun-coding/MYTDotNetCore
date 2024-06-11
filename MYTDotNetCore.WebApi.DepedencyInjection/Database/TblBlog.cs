using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Models
{
    [Table("Tbl_Blog")]
    public class TblBlog
    {
        [Key]
        public string BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
}
