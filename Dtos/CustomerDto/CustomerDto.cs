using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shop_api.Dtos
{
  public class CustomerDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    // [JsonIgnore]
    public ICollection<Order> Orders { get; set; }
  }
}