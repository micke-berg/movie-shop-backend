
using System.Collections.Generic;
using System.Text.Json.Serialization;
using shop_api.Models;

public class OrderItem
{
  public int Quantity { get; set; }
  public int MovieId { get; set; }
  public Movie Movie { get; set; }
  public int OrderId { get; set; }
  public Order Orders { get; set; }
}

