using System.Collections.Generic;
using System.Threading.Tasks;
using shop_api.Dtos;
using shop_api.Models;

namespace shop_api.Services.GenreService
{
  public interface IGenreService
  {
    Task<ServiceResponse<List<GenreDto>>> GetGenres();
    Task<ServiceResponse<GenreDto>> GetGenreById(int id);
    Task<ServiceResponse<List<GenreDto>>> CreateGenre(GenreDto newGenre);
    Task<ServiceResponse<List<GenreDto>>> DeleteGenre(int id);
  }
}