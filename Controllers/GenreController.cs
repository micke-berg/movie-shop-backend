using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Dtos;
using shop_api.Models;
using shop_api.Services.GenreService;

[Route("[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
  private readonly IGenreService _genreService;

  public GenreController(IGenreService genreService)
  {
    _genreService = genreService;
  }

  [HttpGet]
  public async Task<ActionResult> GetGenres()
  {
    return Ok(await _genreService.GetGenres());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Genre>> GetGenre(int id)
  {
    return Ok(await _genreService.GetGenreById(id));
  }

  [HttpPost]
  public async Task<IActionResult> CreateGenre(GenreDto newGenre)
  {
    return Ok(await _genreService.CreateGenre(newGenre));
  }

  // [HttpDelete("{id}")]
  // public async Task<IActionResult> DeleteGenre(int id)
  // {
  //   ServiceResponse<List<GenreDto>> response = await _genreService.DeleteGenre(id);
  //   if (response.Data == null)
  //   {
  //     return NotFound(response);
  //   }
  //   return Ok(response);
  // }
}
