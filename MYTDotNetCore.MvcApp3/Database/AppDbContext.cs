using Microsoft.EntityFrameworkCore;

namespace MYTDotNetCore.MvcApp3.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<TblBlogs> Blogs { get; set; }
}