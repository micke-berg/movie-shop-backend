using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Dtos;
using shop_api.Models;

namespace shop_api.Services.CustomerService
{
  public class CustomerService : ICustomerService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public CustomerService(IMapper mapper, DataContext context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ServiceResponse<List<CustomerDto>>> GetCustomers()
    {
      ServiceResponse<List<CustomerDto>> serviceResponse = new ServiceResponse<List<CustomerDto>>();
      List<Customer> dbCustomers = await _context.Customers.ToListAsync();
      serviceResponse.Data = (dbCustomers.Select(c => _mapper.Map<CustomerDto>(c))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<CustomerDto>> GetCustomerById(int id)
    {
      ServiceResponse<CustomerDto> serviceResponse = new ServiceResponse<CustomerDto>();
      Customer dbCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
      serviceResponse.Data = _mapper.Map<CustomerDto>(dbCustomer);
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<CustomerDto>>> AddCustomer(CustomerDto newCustomer)
    {
      ServiceResponse<List<CustomerDto>> serviceResponse = new ServiceResponse<List<CustomerDto>>();
      Customer customer = _mapper.Map<Customer>(newCustomer);
      await _context.Customers.AddAsync(customer);
      await _context.SaveChangesAsync();
      serviceResponse.Data = (_context.Customers.Select(c => _mapper.Map<CustomerDto>(c))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<CustomerDto>>> DeleteCustomer(int id)
    {
      ServiceResponse<List<CustomerDto>> serviceResponse = new ServiceResponse<List<CustomerDto>>();
      try
      {
        Customer customer = await _context.Customers.FirstAsync(c => c.Id == id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        serviceResponse.Data = (_context.Customers.Select(c => _mapper.Map<CustomerDto>(c))).ToList();
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