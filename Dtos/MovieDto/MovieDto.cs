using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shop_api.Dtos
{
  public class MovieDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string Backdrop { get; set; }
    public string Description { get; set; }
    public string ReleaseDate { get; set; }
    public decimal Rating { get; set; }
    [JsonIgnore]
    public ICollection<MovieGenre> Genres { get; set; }

  }
}