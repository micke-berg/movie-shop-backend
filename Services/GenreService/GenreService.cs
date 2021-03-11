using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Dtos;
using shop_api.Models;

namespace shop_api.Services.GenreService
{
  public class GenreService : IGenreService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public GenreService(IMapper mapper, DataContext context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GenreDto>>> GetGenres()
    {
      ServiceResponse<List<GenreDto>> serviceResponse = new ServiceResponse<List<GenreDto>>();
      List<Genre> dbGenre = await _context.Genres
      .Include(mg => mg.Movies)
      .ThenInclude(m => m.Movie)
      .ToListAsync();
      serviceResponse.Data = (dbGenre.Select(g => _mapper.Map<GenreDto>(g))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GenreDto>> GetGenreById(int id)
    {
      ServiceResponse<GenreDto> serviceResponse = new ServiceResponse<GenreDto>();
      try 
      {
        Genre dbGenre = await _context.Genres
        .Include(mg => mg.Movies)
        // .ThenInclude(m => m.Movie)
        .FirstOrDefaultAsync(g => g.Id == id);
        serviceResponse.Data = _mapper.Map<GenreDto>(dbGenre);
      }
            catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GenreDto>>> CreateGenre(GenreDto newGenre)
    {
      ServiceResponse<List<GenreDto>> serviceResponse = new ServiceResponse<List<GenreDto>>();
      Genre genre = _mapper.Map<Genre>(newGenre);
      await _context.Genres.AddAsync(genre);
      await _context.SaveChangesAsync();
      serviceResponse.Data = (_context.Genres.Select(g => _mapper.Map<GenreDto>(g))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GenreDto>>> DeleteGenre(int id)
    {
      ServiceResponse<List<GenreDto>> serviceResponse = new ServiceResponse<List<GenreDto>>();
      try
      {
        Genre genre = await _context.Genres.FirstAsync(g => g.Id == id);
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();

        serviceResponse.Data = (_context.Genres.Select(g => _mapper.Map<GenreDto>(g))).ToList();
      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

  }
}