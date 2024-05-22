using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYTDotNetCore.WindowFormsApp.Models;

internal class BlogModel
{
    [Key]
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}
