using System.Collections.Generic;
using System.Threading.Tasks;
using shop_api.Dtos;
using shop_api.Models;

namespace shop_api.Services.MovieService
{
  public interface IMovieService
  {
    Task<ServiceResponse<List<MovieDto>>> GetMovies();
    Task<ServiceResponse<MovieDto>> GetMovieById(int id);
    Task<ServiceResponse<List<MovieDto>>> CreateMovie(MovieDto newMovie);
    Task<ServiceResponse<List<MovieDto>>> DeleteMovie(int id);
  }
}