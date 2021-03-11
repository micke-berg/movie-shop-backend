using System.Text.Json.Serialization;

namespace shop_api.Dtos
{
  public class MovieGenreDto
  {
    public int MovieId { get; set; }
    [JsonIgnore]
    public Movie Movie { get; set; }
    public int GenreId { get; set; }
    [JsonIgnore]
    public Genre Genre { get; set; }
  }
}