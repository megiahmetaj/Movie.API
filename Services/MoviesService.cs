using Movie.API.Data;
using Movie.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Movie.API.Services;

public class MoviesService
{
    private readonly AppDbContext _context;

    public MoviesService(AppDbContext context)
    {
        _context = context;
    }

    public List<Models.Movie> GetAllMovies()
    {
        
        return _context.Movies.AsNoTracking().ToList();
    }

    public Models.Movie? GetMovieById(int id)
    {
        return _context.Movies.Find(id);
    }

    public Models.Movie AddMovie(Models.Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return movie;
    }

    public Models.Movie UpdateMovie(Models.Movie movie)
    {
        var existing = _context.Movies.Find(movie.Id);
        if (existing == null) return null;
    
        existing.Title = movie.Title;
        existing.Genre = movie.Genre;
        existing.Director = movie.Director;
        existing.Year = movie.Year;
        existing.Rating = movie.Rating;
        existing.Duration = movie.Duration;
        existing.PosterUrl = movie.PosterUrl;
    
        _context.SaveChanges();
        return existing;
    }

    public void DeleteMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}