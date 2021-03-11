using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Dtos;
using shop_api.Models;
using shop_api.Services.MovieService;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
  private readonly IMovieService _movieService;

  public MovieController(IMovieService movieService)
  {
    _movieService = movieService;
  }

  [HttpGet]
  public async Task<ActionResult> GetMovies()
  {
    return Ok(await _movieService.GetMovies());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Movie>> GetMovie(int id)
  {
    return Ok(await _movieService.GetMovieById(id));
  }

  [HttpPost]
  public async Task<IActionResult> CreateMovie(MovieDto newMovie)
  {
    return Ok(await _movieService.CreateMovie(newMovie));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteMovie(int id)
  {
    ServiceResponse<List<MovieDto>> response = await _movieService.DeleteMovie(id);
    if (response.Data == null)
    {
      return NotFound(response);
    }
    return Ok(response);
  }
}
