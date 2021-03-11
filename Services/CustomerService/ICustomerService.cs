using System.Collections.Generic;
using System.Threading.Tasks;
using shop_api.Dtos;
using shop_api.Models;

namespace shop_api.Services.CustomerService
{
  public interface ICustomerService
  {
    Task<ServiceResponse<List<CustomerDto>>> GetCustomers();
    Task<ServiceResponse<CustomerDto>> GetCustomerById(int id);
    Task<ServiceResponse<List<CustomerDto>>> AddCustomer(CustomerDto newCustomer);
    Task<ServiceResponse<List<CustomerDto>>> DeleteCustomer(int id);
  }
}