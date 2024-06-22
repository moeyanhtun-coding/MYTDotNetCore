using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MYTDotNetCore.EFCoreAuto.EfCoreDataModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LogEvent> LogEvents { get; set; }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblCanvasBarChart> TblCanvasBarCharts { get; set; }

    public virtual DbSet<TblColumnChart> TblColumnCharts { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblDashedLineChart> TblDashedLineCharts { get; set; }

    public virtual DbSet<TblLogEvent> TblLogEvents { get; set; }

    public virtual DbSet<TblPizza> TblPizzas { get; set; }

    public virtual DbSet<TblPizzaExtra> TblPizzaExtras { get; set; }

    public virtual DbSet<TblPizzaOrder> TblPizzaOrders { get; set; }

    public virtual DbSet<TblPizzaOrderDetail> TblPizzaOrderDetails { get; set; }

    public virtual DbSet<TblRadarChart> TblRadarCharts { get; set; }

    public virtual DbSet<TblRangeBarChart> TblRangeBarCharts { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MYTDotNetCore;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogEvent>(entity =>
        {
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogContent).HasMaxLength(50);
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCanvasBarChart>(entity =>
        {
            entity.ToTable("Tbl_CanvasBarChart");

            entity.Property(e => e.Labels)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblColumnChart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tbl_StackColumn100");

            entity.ToTable("Tbl_ColumnChart");

            entity.Property(e => e.Categories)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("Tbl_Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblDashedLineChart>(entity =>
        {
            entity.HasKey(e => e.PageStatistics).HasName("PK_Tbl_DashedLineChart1");

            entity.ToTable("Tbl_DashedLineChart");

            entity.Property(e => e.CreatedDate)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblLogEvent>(entity =>
        {
            entity.ToTable("Tbl_LogEvents");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPizza>(entity =>
        {
            entity.HasKey(e => e.PizzaId);

            entity.ToTable("Tbl_Pizza");

            entity.Property(e => e.Pizza)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaExtra>(entity =>
        {
            entity.HasKey(e => e.PizzaExtraId);

            entity.ToTable("Tbl_PizzaExtra");

            entity.Property(e => e.PizzaExtraName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaOrder>(entity =>
        {
            entity.HasKey(e => e.PizzaOrderId);

            entity.ToTable("Tbl_PizzaOrder");

            entity.Property(e => e.PizzaOrderInvoiceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaOrderDetail>(entity =>
        {
            entity.HasKey(e => e.PizzaOrderDetailId).HasName("PK_Tbl_PizzaOrderDetails");

            entity.ToTable("Tbl_PizzaOrderDetail");

            entity.Property(e => e.PizzaOrderInvoiceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblRadarChart>(entity =>
        {
            entity.ToTable("Tbl_RadarChart");

            entity.Property(e => e.Month)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblRangeBarChart>(entity =>
        {
            entity.ToTable("Tbl_RangeBarChart");

            entity.Property(e => e.Labels)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("Tbl_User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
