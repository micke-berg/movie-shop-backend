using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Movie
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
