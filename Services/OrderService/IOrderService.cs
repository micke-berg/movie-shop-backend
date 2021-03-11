using System.Collections.Generic;
using System.Threading.Tasks;
using shop_api.Dtos;
using shop_api.Models;

namespace shop_api.Services.OrderService
{
  public interface IOrderService
  {
    Task<ServiceResponse<List<OrderDto>>> GetAllOrders();
    Task<ServiceResponse<OrderDto>> GetOrderById(int id);
    Task<ServiceResponse<List<OrderDto>>> CreateOrder(OrderDto newOrder);
    Task<ServiceResponse<List<OrderDto>>> DeleteOrder(int id);
  }
}