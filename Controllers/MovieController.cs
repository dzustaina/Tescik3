using Microsoft.AspNetCore.Mvc;
using TicketApp.Models;
using TicketApp.Services;

namespace TicketApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{Movieid}")]
        public IActionResult GetMovie(int Movieid)
        {
            var movie = _movieService.GetMovieById(Movieid);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }

            var addedMovie = _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = addedMovie.Movieid }, addedMovie);
        }

        [HttpPut("{Movieid}")]
        public IActionResult UpdateMovie(int Movieid, Movie updatedMovie)
        {
            var movie = _movieService.GetMovieById(Movieid);
            if (movie == null)
            {
                return NotFound();
            }

            _movieService.UpdateMovie(Movieid, updatedMovie);
            return NoContent();
        }

        [HttpDelete("{Movieid}")]
        public IActionResult DeleteFilm(int Movieid)
        {
            var movie = _movieService.GetMovieById(Movieid);
            if (movie == null)
            {
                return NotFound();
            }

            _movieService.DeleteMovie(Movieid);
            return NoContent();
        }
    }
}
