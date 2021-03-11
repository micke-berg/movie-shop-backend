using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop_api.Models;
using shop_api.Services.OrderService;
using shop_api.Dtos;


[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
  private readonly IOrderService _orderService;

  public OrderController(IOrderService orderService)
  {
    _orderService = orderService;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    return Ok(await _orderService.GetAllOrders());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetSingle(int id)
  {
    return Ok(await _orderService.GetOrderById(id));
  }

  [HttpPost]
  public async Task<IActionResult> CreateOrder([FromBody] OrderDto newOrder)
  {
    string json = System.Text.Json.JsonSerializer.Serialize(newOrder);
    
    return Ok(await _orderService.CreateOrder(newOrder));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    ServiceResponse<List<OrderDto>> response = await _orderService.DeleteOrder(id);
    if (response.Data == null)
    {
      return NotFound(response);
    }
    return Ok(response);
  }
}
