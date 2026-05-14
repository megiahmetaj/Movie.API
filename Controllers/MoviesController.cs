using Microsoft.AspNetCore.Mvc;
using Movie.API.Models;
using Movie.API.Services;

namespace Movie.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MoviesService _moviesService;

    public MoviesController(MoviesService moviesService)
    {
        _moviesService = moviesService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAllMovies()
    {
        var allMovies = _moviesService.GetAllMovies();
        return Ok(allMovies);
    }

    [HttpGet("GetById")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _moviesService.GetMovieById(id);
        return Ok(movie);
    }

    [HttpPost("AddNew")]
    public IActionResult CreateMovie([FromBody] Models.Movie payload)
    {
        var addedMovie = _moviesService.AddMovie(payload);
        return Ok(addedMovie);
    }

    [HttpPut("Update")]
    public IActionResult UpdateMovie([FromBody] Models.Movie payload)
    {
        var updatedMovie = _moviesService.UpdateMovie(payload);
        return Ok(updatedMovie);
    }

    [HttpDelete("Delete")]
    public IActionResult DeleteMovie(int id)
    {
        _moviesService.DeleteMovie(id);
        return Ok("Movie deleted");
    }
}