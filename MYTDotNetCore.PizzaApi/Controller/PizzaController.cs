using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.PizzaApi.Db;
using MYTDotNetCore.PizzaApi.Models;

namespace MYTDotNetCore.PizzaApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly AddDbContext _addDbContext;

    public PizzaController()
    {
        _addDbContext = new AddDbContext();
    }

    [HttpGet("Pizza")]
    public async Task<IActionResult> GetPizzaAsync()
    {
        var lst = await _addDbContext.Pizzas.ToListAsync();
        return Ok(lst);
    }

    [HttpGet("PizzaExtra")]
    public async Task<IActionResult> GetPizzaExtraAsync()
    {
        var lst = await _addDbContext.PizzaExtra.ToListAsync();
        return Ok(lst);
    }

    [HttpPost("PizzaOrder")]
    public async Task<IActionResult> GetPizzaOrderAsync(OrderRequest orderRequest)
    {
        var itemPizza = await _addDbContext.Pizzas.FirstOrDefaultAsync(x =>
            x.Id == orderRequest.PizzaId
        );
        var total = itemPizza.Price;
        if (orderRequest.PizzaExtraId.Length > 0)
        {
            var lstExtra = await _addDbContext
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

        await _addDbContext.PizzaOrder.AddAsync(pizzaOrderModel);
        await _addDbContext.PizzaOrderDetail.AddRangeAsync(pizzaOrderDetails);
        await _addDbContext.SaveChangesAsync();

        OrderResponse orderResponse = new OrderResponse()
        {
           InvoiceNo = invoice,
           Message = "Thank You for your order! Enjoy your pizza",
           TotalAmount = total
        };
        return Ok(orderResponse);
     }
}
