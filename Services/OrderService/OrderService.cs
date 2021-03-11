using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using shop_api.Data;
using shop_api.Models;
using Microsoft.EntityFrameworkCore;
using shop_api.Dtos;
using shop_api.Services.OrderService;

public class OrderService : IOrderService
{
  private readonly IMapper _mapper;
  private readonly DataContext _context;
  public OrderService(IMapper mapper, DataContext context)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ServiceResponse<List<OrderDto>>> GetAllOrders()
  {
    ServiceResponse<List<OrderDto>> serviceResponse = new ServiceResponse<List<OrderDto>>();
    List<Order> dbOrders = await _context.Orders.Include(o => o.OrderItems).ToListAsync();
    serviceResponse.Data = (dbOrders.Select(c => _mapper.Map<OrderDto>(c))).ToList();
    return serviceResponse;
  }
  
  public async Task<ServiceResponse<OrderDto>> GetOrderById(int id)
  {
    ServiceResponse<OrderDto> serviceResponse = new ServiceResponse<OrderDto>();
    Order dbOrder = await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
    serviceResponse.Data = _mapper.Map<OrderDto>(dbOrder);
    return serviceResponse;
  }

  public async Task<ServiceResponse<List<OrderDto>>> CreateOrder(OrderDto newOrder)
  {
    ServiceResponse<List<OrderDto>> serviceResponse = new ServiceResponse<List<OrderDto>>();

    Order Order = _mapper.Map<Order>(newOrder);
    Order.Created = DateTime.Now;
    await _context.Orders.AddAsync(Order);
    await _context.SaveChangesAsync();
    serviceResponse.Data = (_context.Orders.Select(o => _mapper.Map<OrderDto>(o))).ToList();
    return  serviceResponse;
  }

  public async Task<ServiceResponse<List<OrderDto>>> DeleteOrder(int id)
  {
    ServiceResponse<List<OrderDto>> serviceResponse = new ServiceResponse<List<OrderDto>>();
    try
    {
      Order Order = await _context.Orders.FirstAsync(c => c.Id == id);
      _context.Orders.Remove(Order);
      await _context.SaveChangesAsync();

      serviceResponse.Data = (_context.Orders.Select(c => _mapper.Map<OrderDto>(c))).ToList();
    }
    catch (Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
  }
}
