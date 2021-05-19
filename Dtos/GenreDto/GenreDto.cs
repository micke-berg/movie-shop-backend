using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shop_api.Dtos
{
  public class GenreDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<MovieGenre> Movies { get; set; }
  }
}