using System.Collections.Generic;
using System.Linq;
using TicketApp.Models;

namespace TicketApp.Services
{
    public class ShowtimeService
    {
        private readonly MovieAppContext _dbContext;

        public ShowtimeService(MovieAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Showtime> GetAllShowtimes()
        {
            return _dbContext.Showtimes.ToList();
        }

        public Showtime? GetShowtimeById(int id)
        {
            return _dbContext.Showtimes.FirstOrDefault(showtime => showtime.Showtimeid == id);
        }

        public Showtime AddShowtime(Showtime showtime)
        {
            _dbContext.Showtimes.Add(showtime);
            _dbContext.SaveChanges();
            return showtime;
        }

        public void UpdateShowtime(int id, Showtime updatedShowtime)
        {
            var showtime = _dbContext.Showtimes.FirstOrDefault(show => show.Showtimeid == id);
            if (showtime != null)
            {
                // Update properties of the existing showtime based on updatedShowtime
                showtime.Movieid = updatedShowtime.Movieid;
                showtime.Startdatetime = updatedShowtime.Startdatetime;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteShowtime(int id)
        {
            var showtime = _dbContext.Showtimes.Find(id);
            if (showtime != null)
            {
                _dbContext.Showtimes.Remove(showtime);
                _dbContext.SaveChanges();
            }
        }
    }
}
