using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.NLayer.DataAccess.Db;
using MYTDotNetCore.NLayer.DataAccess.Model;
using System.Data.SqlClient;

namespace MYTDotNetCore.NLayer.DataAccess.Db
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
