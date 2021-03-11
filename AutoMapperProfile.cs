using AutoMapper;
using shop_api.Dtos;
using System.Linq;

public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<Movie, MovieDto>();
    CreateMap<MovieDto, Movie>();

    CreateMap<Genre, GenreDto>();
    CreateMap<GenreDto, Genre>();

    CreateMap<OrderItem, OrderItemDto>();
    CreateMap<OrderItemDto, OrderItem>();

    CreateMap<Customer, CustomerDto>();
    CreateMap<CustomerDto, Customer>();

    CreateMap<Order, OrderDto>();
    CreateMap<OrderDto, Order>();
  }
}