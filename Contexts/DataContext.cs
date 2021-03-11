using Microsoft.EntityFrameworkCore;
using shop_api.Models;

namespace shop_api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=DB/shop.db");
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<OrderItem>()
        .HasKey(od => new { od.MovieId, od.OrderId });

      modelBuilder.Entity<MovieGenre>()
        .HasKey(mg => new { mg.MovieId, mg.GenreId });
      modelBuilder.Entity<MovieGenre>()
        .HasOne(mg => mg.Movie)
        .WithMany(m => m.Genres)
        .HasForeignKey(mg => mg.MovieId);  
      modelBuilder.Entity<MovieGenre>()
        .HasOne(mg => mg.Genre)
        .WithMany(g => g.Movies)
        .HasForeignKey(mg => mg.GenreId);
    }
  }
}