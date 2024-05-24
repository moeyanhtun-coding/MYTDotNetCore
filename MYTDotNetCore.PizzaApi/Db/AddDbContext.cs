using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

public class PizzaOrders
{
    public int PizzaOrderId { get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public decimal TotalAmount { get; set; }

    [NotMapped]
    public string TotalAmountStr
    {
        get { return "$ " + TotalAmount; }
    }

    public int PizzaId { get; set; }
    public string Pizza { get; set; }
    public decimal Price { get; set; }

    [NotMapped]
    public string PriceStr
    {
        get { return "$ " + Price; }
    }
}

public class PizzaOrderDetails
{
    public int PizzaOrderDetailId { get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public int PizzaExtraId { get; set; }
    public string PizzaExtraName { get; set; }
    public decimal Price { get; set; }

    [NotMapped]
    public string PriceStr
    {
        get { return "$ " + Price; }
    }
}

public class InvoiceDetail
{
    public PizzaOrders Order { get; set; }
    public List<PizzaOrderDetails> OrderDetail { get; set; }
}
