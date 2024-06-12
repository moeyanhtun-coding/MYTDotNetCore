using Microsoft.EntityFrameworkCore;

namespace MYTDotNetCore.BlazorServerApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<TblBlog> Blogs { get; set; }
        public DbSet<TblCustomer> Customers { get; set; }
    }
}
