using System;
using System.Collections.Generic;

public class Order
{
  public int Id { get; set; }
  public DateTime Created { get; set; }
  public double TotalPrice { get; set; }
  public string PaymentType { get; set; }
  public string Email { get; set; }
  public int CustomerId { get; set; }
  public Customer Customer { get; set; }
  public ICollection<OrderItem> OrderItems { get; set; }
}