using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MYTDotNetCore.Shared2;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;
using MYTDotNetCore.WebApi.DepedencyInjection.Feature.Blog;
using MYTDotNetCore.WebApi.DepedencyInjection.Feature.Customer;
using MYTDotNetCore.WebApi.DepedencyInjection.Models.BlogModel;
using MYTDotNetCore.WebApi.DepedencyInjection.Models.CustomerModel;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly BL_Customer _bL_Customer;
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context, BL_Customer bL_Customer)
    {
        _context = context;
        _bL_Customer = bL_Customer;
    }

    [HttpGet("CustomerList/{pageNo}/{pageSize}")]
    public async Task<IActionResult> GetCustomerListAsync(int pageNo, int pageSize)
    {
        var response = new CustomerListResponseModel();
        try
        {
            response = await _bL_Customer.GetCustomerListAsync(pageNo, pageSize);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(CustomerModel customerModel)
    {
        try
        {
            int result = await _bL_Customer.CreateCustomerAsync(customerModel);
            var message = (result > 0) ? "Creating Successful" : "Creating Fail";
            return Ok(message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerAsync(int id)
    {
        try
        {
            var item = await _bL_Customer.GetCustomerAsync(id);
            if (item == null)
                return NotFound("No Item Found");
            return Ok(item);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    [HttpPatch("CustomerUpdate/{id}")]
    public async Task<IActionResult> UpdateCustomerAsync(int id, CustomerModel customerModel)
    {
        try
        {
            var result = await _bL_Customer.UpdateCustomerAsync(id, customerModel);
            var message = result > 0 ? "Updating Successful" : "Updating Fail";
            return Ok(message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomerAsync(int id)
    {
        try
        {
            var result = await _bL_Customer.DeleteCustomerAsync(id);
            var message = result > 0 ? "Deleting Successful" : "Deleting Fail";
            return Ok(message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
