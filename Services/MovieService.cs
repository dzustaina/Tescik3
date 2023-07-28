using System.Collections.Generic;
using System.Linq;
using System.Net;
using TicketApp.Models;

namespace TicketApp.Services
{
    public class MovieService
    {
        private readonly MovieAppContext _dbContext;

        public MovieService(MovieAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }
        public Movie? GetMovieById(int? id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.Movieid == id);
        }

        public Movie AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return movie;
        }
        public void UpdateMovie(int id, Movie updatedMovie)
        {
            var film = _dbContext.Movies.FirstOrDefault(m => m.Movieid == id);
            if (film != null)
            {
                film.Title = updatedMovie.Title;
                film.Description = updatedMovie.Description;
                film.Poster = updatedMovie.Poster;
                film.Duration = updatedMovie.Duration;
                // Dodaj pozostałe pola, które chcesz zaktualizować
                _dbContext.SaveChanges();
            }
        }
        public void DeleteMovie(int Movieid)
        {
            var movie = _dbContext.Movies.Find(Movieid);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }
    }

    
}
