using Microsoft.EntityFrameworkCore;

namespace MYTDotNetCore.MvcApp3.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<TblBlogs> Blogs { get; set; }
    public DbSet<TblUser> Users { get; set; }
    public DbSet<TblLogin> Login { get; set; }
}
