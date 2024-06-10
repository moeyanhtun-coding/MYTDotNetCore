using Microsoft.Identity.Client;

namespace MYTDotNetCore.MinimalApi.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }

    public class BlogRequestModel
    {
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
}
