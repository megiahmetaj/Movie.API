using Microsoft.EntityFrameworkCore;
using Movie.API.Models;

namespace Movie.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Models.Movie> Movies { get; set; }
}
