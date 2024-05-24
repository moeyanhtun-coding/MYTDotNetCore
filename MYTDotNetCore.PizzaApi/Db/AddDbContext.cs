using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.PizzaApi.Models;
namespace MYTDotNetCore.PizzaApi.Db;

public class AddDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<PizzaModel> Pizzas { get; set; }
    public DbSet<PizzaExtraModel> PizzaExtra { get; set; }
    public DbSet<PizzaOrderModel> PizzaOrder { get; set; }
    public DbSet<PizzaOrderDetailModel> PizzaOrderDetail { get; set; }
}
public class OrderRequest
{
    public int PizzaId { get; set; }
    public int[] PizzaExtraId { set; get; }
}

public class OrderResponse
{
    public string Message { get; set; }
    public string InvoiceNo { get; set; }
    public decimal TotalAmount { get; set; }
}
