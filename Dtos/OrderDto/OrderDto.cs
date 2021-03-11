using System;
using System.Collections.Generic;

namespace shop_api.Dtos
{
  public class OrderDto
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public double TotalPrice { get; set; }
    public string PaymentType { get; set; }
    public string Email { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<OrderItemDto> OrderItems { get; set; }
  }
}
