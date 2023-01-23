using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts)
        : base(opts)
    { 
        
    }

    public DbSet<Movie> Movies { get; set; }
}
