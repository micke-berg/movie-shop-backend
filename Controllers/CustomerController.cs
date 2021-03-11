using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop_api.Dtos;
using shop_api.Models;
using shop_api.Services.CustomerService;


[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
  private readonly ICustomerService _customerService;

  public CustomerController(ICustomerService customerService)
  {
    _customerService = customerService;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    return Ok(await _customerService.GetCustomers());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetSingleCustomer(int id)
  {
    return Ok(await _customerService.GetCustomerById(id));
  }

  [HttpPost]
  public async Task<IActionResult> AddCustomer(CustomerDto newCustomer)
  {
    return Ok(await _customerService.AddCustomer(newCustomer));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCustomer(int id)
  {
    ServiceResponse<List<CustomerDto>> response = await _customerService.DeleteCustomer(id);
    if (response.Data == null)
    {
      return NotFound(response);
    }
    return Ok(response);
  }
}
