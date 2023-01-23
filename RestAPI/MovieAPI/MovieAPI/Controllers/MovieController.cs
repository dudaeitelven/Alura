using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.DTOs;
using MovieAPI.Models;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;


    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Add a movie into the database
    /// </summary>
    /// <param name="movieDto"> Object required to create a movie</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Success in creating the movie </response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddMovie([FromBody] CreateMovieDTO movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieById), new {title = movie.Id}, movie);
    }

    [HttpGet]
    public IEnumerable<ReadMovieDTO> GetMovies([FromQuery]int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies
            .FirstOrDefault(m => m.Id == id);

        if (movie == null) return NotFound();

        var movieDto = _mapper.Map<ReadMovieDTO>(movie);

        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDto)
    {
        var movie = _context.Movies
            .FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();

        _mapper.Map(movieDto, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePatch(int id, JsonPatchDocument<UpdateMovieDTO> patch)
    {
        var movie = _context.Movies
            .FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();

        var movieToUpdate = _mapper.Map<UpdateMovieDTO>(movie);
        patch.ApplyTo(movieToUpdate, ModelState);

        if (!TryValidateModel(movieToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies
            .FirstOrDefault(m => m.Id == id);
                if (movie == null) return NotFound();

        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }
}
