using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;
using MYTDotNetCore.WebApi.DepedencyInjection.Models.CustomerModel;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Feature.Customer
{
    public class DA_Customer
    {
        private readonly AppDbContext _context;

        public DA_Customer(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerListResponseModel> GetCustomerListAsync(
            int pageNo = 1,
            int pageSize = 10
        )
        {
            var response = new CustomerListResponseModel();
            try
            {
                var query = _context.Customers.AsNoTracking();
                int totalCount = query.Count();
                int pageCount = totalCount / pageSize;
                if (totalCount % pageSize > 0)
                {
                    pageCount++;
                }
                var lst = await query.Pagination(pageNo, pageSize).ToListAsync();
                if (lst is null)
                    throw new Exception("No Data Found");
                response = new CustomerListResponseModel() { DataList = lst };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return response;
        }

        public async Task<CustomerResponseModel> GetCustomerAsync(int id)
        {
            var response = new CustomerResponseModel();
            try
            {
                var item = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
                if (item is null)
                {
                    response.responseMessage = "No Item Found!";
                    goto result;
                }
                response.responseMessage = "Item Found!";
                response.customer = item!.Change();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            result:
            return response;
        }

        public async Task<int> CreateCustomerAsync(CustomerModel customerModel)
        {
            try
            {
                await _context.Customers.AddAsync(customerModel.Change());
                var result = _context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<int> UpdateCustomerAsync(int id, CustomerModel customerModel)
        {
            try
            {
                var item = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
                if (item is null)
                    return 0;
                if (!string.IsNullOrEmpty(customerModel.CustomerName))
                    item.CustomerName = customerModel.CustomerName;
                if (!string.IsNullOrEmpty(customerModel.CustomerCode))
                    item.CustomerCode = customerModel.CustomerCode;
                if (!string.IsNullOrEmpty(customerModel.MobileNo))
                    item.MobileNo = customerModel.MobileNo;
                var result = _context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            try
            {
                var item = _context.Customers.FirstOrDefault(x => x.CustomerID == id)!;
                if (item is null)
                    return 0;
                _context.Customers.Remove(item);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
