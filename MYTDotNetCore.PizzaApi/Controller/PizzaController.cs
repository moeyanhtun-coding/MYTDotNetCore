using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.PizzaApi.Db;
using MYTDotNetCore.PizzaApi.Models;
using MYTDotNetCore.Shared2;

namespace MYTDotNetCore.PizzaApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly AppDbContext _appDbContext;
    private readonly DapperService _dapperService;

    public PizzaController()
    {
        _appDbContext = new AppDbContext();
        _dapperService = new DapperService(
            ConnectionStrings.SqlConnectionStringBuilder.ConnectionString
        );
    }

    [HttpGet("Pizza")]
    public async Task<IActionResult> GetPizzaAsync()
    {
        var lst = await _appDbContext.Pizzas.ToListAsync();
        return Ok(lst);
    }

    [HttpGet("PizzaExtra")]
    public async Task<IActionResult> GetPizzaExtraAsync()
    {
        var lst = await _appDbContext.PizzaExtra.ToListAsync();
        return Ok(lst);
    }

    [HttpGet("PizzaOrderDetail/{invoice}")]
    public async Task<IActionResult> GetPizzaOrderDetailAsync(string invoice)
    {
        //var order = await _addDbContext.PizzaOrder.FirstOrDefaultAsync(x=> x.PizzaOrderInvoiceNo == invoice);

        //var orderDetail = await _addDbContext.PizzaOrderDetail.Where(x=> x.PizzaOrderInvoiceNo == order.PizzaOrderInvoiceNo).ToListAsync();
        //var model = new InvoiceDetail()
        //{
        //    Order = order,
        //    OrderDetail = orderDetail
        //};

        var order = _dapperService.QueryFirstOrDefault<PizzaOrders>(
            Queries.PizzaQueries.pizzaOrderQuery,
            new { PizzaOrderInvoiceNo = invoice }
        );

        if (order is null)
            return NotFound("Invoice Not Found");

        var orderDetail = _dapperService.Query<PizzaOrderDetails>(
            Queries.PizzaQueries.pizzaOrderDetailQuery,
            new { PizzaOrderInvoiceNo = order.PizzaOrderInvoiceNo }
        );

        var model = new InvoiceDetail() { Order = order, OrderDetail = orderDetail };
        return Ok(model);
    }

    [HttpPost("PizzaOrder")]
    public async Task<IActionResult> GetPizzaOrderAsync(OrderRequest orderRequest)
    {
        var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x =>
            x.Id == orderRequest.PizzaId
        );
        var total = itemPizza!.Price;
        if (orderRequest.PizzaExtraId.Length > 0)
        {
            var lstExtra = await _appDbContext
                .PizzaExtra.Where(x => orderRequest.PizzaExtraId.Contains(x.Id))
                .ToListAsync();

            total += lstExtra.Sum(x => x.Price);
        }

        var invoice = DateTime.Now.ToString("yyMMddHHmmss");

        PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
        {
            PizzaId = orderRequest.PizzaId,
            PizzaOrderInvoiceNo = invoice,
            TotalAmount = total
        };

        List<PizzaOrderDetailModel> pizzaOrderDetails = orderRequest
            .PizzaExtraId.Select(extraId => new PizzaOrderDetailModel()
            {
                PizzaExtraId = extraId,
                PizzaOrderInvoiceNo = invoice,
            })
            .ToList();

        await _appDbContext.PizzaOrder.AddAsync(pizzaOrderModel);
        await _appDbContext.PizzaOrderDetail.AddRangeAsync(pizzaOrderDetails);
        await _appDbContext.SaveChangesAsync();

        OrderResponse orderResponse = new OrderResponse()
        {
            InvoiceNo = invoice,
            Message = "Thank You for your order! Enjoy your pizza",
            TotalAmount = total
        };
        return Ok(orderResponse);
    }
}
