using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Genre
{
  public int Id { get; set; }
  public string Name { get; set; }
  [JsonIgnore]
  public ICollection<MovieGenre> Movies { get; set; }
}
