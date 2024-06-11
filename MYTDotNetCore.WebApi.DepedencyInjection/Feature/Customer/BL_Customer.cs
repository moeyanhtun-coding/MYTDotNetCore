using MYTDotNetCore.WebApi.DepedencyInjection.Models.CustomerModel;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Feature.Customer
{
    public class BL_Customer
    {
        private readonly DA_Customer _dA_Customer;

        public BL_Customer(DA_Customer dA_Customer)
        {
            this._dA_Customer = dA_Customer;
        }

        public async Task<CustomerListResponseModel> GetCustomerListAsync(
            int pageNo = 1,
            int pageSize = 10
        )
        {
            var response = new CustomerListResponseModel();
            try
            {
                response = await _dA_Customer.GetCustomerListAsync(pageNo, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return response;
        }

        public async Task<CustomerResponseModel> GetCustomerAsync(int id)
        {
            try
            {
                var item = await _dA_Customer.GetCustomerAsync(id);
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<int> CreateCustomerAsync(CustomerModel customerModel)
        {
            try
            {
                int result = await _dA_Customer.CreateCustomerAsync(customerModel);
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
                int result = await _dA_Customer.UpdateCustomerAsync(id, customerModel);
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
                var result = await _dA_Customer.DeleteCustomerAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
