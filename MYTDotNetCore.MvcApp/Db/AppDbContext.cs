using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Db
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<DashedLineChartModel> PageStatistics { get; set; }
        public DbSet<ApexChartRadarChartModel> ApexChartRadarChart { get; set; }
    }
}
