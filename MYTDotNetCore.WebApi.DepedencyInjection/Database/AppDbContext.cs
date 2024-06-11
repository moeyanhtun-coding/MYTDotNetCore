using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.WebApi.DepedencyInjection.Models;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<TblBlog> Blogs { get; set; }
    }
}
