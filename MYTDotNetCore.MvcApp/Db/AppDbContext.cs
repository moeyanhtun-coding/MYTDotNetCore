using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //}
        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<DashedLineChartModel> PageStatistics { get; set; }
        public DbSet<ApexChartRadarChartModel> ApexChartRadarChart { get; set; }
        public DbSet<ApexChartColumnChartModel> ApexChartColumnChart { get; set; }
        public DbSet<CanvasBarChartModel> CanvasBarChartModels { get; set; }
        public DbSet<CanvasRangeBarChartModel> CanvasRangeBarChartModels { get;set; }
    }
}
