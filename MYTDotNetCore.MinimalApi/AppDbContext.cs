using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.MinimalApi.Models;

namespace MYTDotNetCore.MinimalApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<TblBlog> Blogs { get; set; }
    }
}
