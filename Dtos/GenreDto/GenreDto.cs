using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shop_api.Dtos
{
  public class GenreDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<MovieGenre> Movies { get; set; }
  }
}