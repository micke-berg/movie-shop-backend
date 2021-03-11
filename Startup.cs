using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using shop_api.Data;
using shop_api.Services.CustomerService;
using shop_api.Services.GenreService;
using shop_api.Services.MovieService;
using shop_api.Services.OrderService;

namespace shop_api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    private string corsPolicyName = "myCorsConfig";
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers().AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      });
      services.AddDbContext<DataContext>();
      services.AddControllers();
      services.AddAutoMapper(typeof(Startup));
      services.AddScoped<ICustomerService, CustomerService>();
      services.AddScoped<IOrderService, OrderService>();
      services.AddScoped<IMovieService, MovieService>();
      services.AddScoped<IGenreService, GenreService>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "shop_api", Version = "v1" });
      });
      services.AddCors(options =>
      {
        options.AddPolicy(corsPolicyName, builder =>
        {
          // builder
          // .WithOrigins("https://localhost:3001", "https://localhost:3000")
          // .WithMethods("*");

          builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "shop_api v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(corsPolicyName);

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
