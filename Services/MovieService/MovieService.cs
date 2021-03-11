using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Dtos;
using shop_api.Models;
using shop_api.Services.MovieService;

public class MovieService : IMovieService
{
  private readonly IMapper _mapper;
  private readonly DataContext _context;
  public MovieService(IMapper mapper, DataContext context)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ServiceResponse<List<MovieDto>>> GetMovies()
  {
    ServiceResponse<List<MovieDto>> serviceResponse = new ServiceResponse<List<MovieDto>>();
    List<Movie> dbMovies = await _context.Movies
    .Include(mg => mg.Genres)
    // .ThenInclude(x => x.Genre)
    .ToListAsync();
    serviceResponse.Data = (dbMovies.Select(m => _mapper.Map<MovieDto>(m))).ToList();
    return serviceResponse;
  }

  public async Task<ServiceResponse<MovieDto>> GetMovieById(int id)
  {
    ServiceResponse<MovieDto> serviceResponse = new ServiceResponse<MovieDto>();
    try 
    {
      Movie dbMovie = await _context.Movies
        .Include(mg => mg.Genres)
        // .ThenInclude(x => x.Genre)
        .FirstOrDefaultAsync(m => m.Id == id);
      serviceResponse.Data = _mapper.Map<MovieDto>(dbMovie);
    }
    catch (Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
  }

  public async Task<ServiceResponse<List<MovieDto>>> CreateMovie(MovieDto newMovie)
  {
    ServiceResponse<List<MovieDto>> serviceResponse = new ServiceResponse<List<MovieDto>>();
    Movie movie = _mapper.Map<Movie>(newMovie);
    await _context.Movies.AddAsync(movie);
    await _context.SaveChangesAsync();
    serviceResponse.Data = (_context.Movies.Select(m => _mapper.Map<MovieDto>(m))).ToList();
    return serviceResponse;
  }

  public async Task<ServiceResponse<List<MovieDto>>> DeleteMovie(int id)
  {
    ServiceResponse<List<MovieDto>> serviceResponse = new ServiceResponse<List<MovieDto>>();
    try
    {
      Movie movie = await _context.Movies.FirstAsync(m => m.Id == id);
      _context.Movies.Remove(movie);
      await _context.SaveChangesAsync();

      serviceResponse.Data = (_context.Movies.Select(m => _mapper.Map<MovieDto>(m))).ToList();
    }
    catch (Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
  }
}

// _context.Products.Include(p => 
// p.ProductCategories).ThenInclude(pc => 
// pc.Category)
