using System.Collections.Generic;
using System.Text.Json.Serialization;
using shop_api.Models;

namespace shop_api.Dtos
{
  public class OrderItemDto
  {
  public int Quantity { get; set; }
  public int MovieId { get; set; }
  public Movie Movies { get; set; }
  public int OrderId { get; set; }
  // public Order Orders { get; set; }
  }
}