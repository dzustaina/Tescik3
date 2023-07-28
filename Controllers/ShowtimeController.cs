using Microsoft.AspNetCore.Mvc;
using TicketApp.Models;
using TicketApp.Services;

namespace TicketApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowtimeController : ControllerBase
    {
        private readonly ShowtimeService _showtimeService;

        public ShowtimeController(ShowtimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        [HttpGet]
        public IActionResult GetShowtimes()
        {
            var showtimes = _showtimeService.GetAllShowtimes();
            return Ok(showtimes);
        }

        [HttpGet("{Showtimeid}")]
        public IActionResult GetShowtime(int id)
        {
            var showtime = _showtimeService.GetShowtimeById(id);
            if (showtime == null)
            {
                return NotFound();
            }

            return Ok(showtime);
        }

        [HttpPost]
        public IActionResult AddShowtime(Showtime showtime)
        {
            if (showtime == null)
            {
                return BadRequest();
            }

            var addedShowtime = _showtimeService.AddShowtime(showtime);
            return CreatedAtAction(nameof(GetShowtime), new { id = addedShowtime.Showtimeid }, addedShowtime);
        }

        [HttpPut("{Showtimeid}")]
        public IActionResult UpdateShowtime(int id, Showtime updatedShowtime)
        {
            var showtime = _showtimeService.GetShowtimeById(id);
            if (showtime == null)
            {
                return NotFound();
            }

            _showtimeService.UpdateShowtime(id, updatedShowtime);
            return NoContent();
        }

        [HttpDelete("{Showtimeid}")]
        public IActionResult DeleteShowtime(int id)
        {
            var showtime = _showtimeService.GetShowtimeById(id);
            if (showtime == null)
            {
                return NotFound();
            }

            _showtimeService.DeleteShowtime(id);
            return NoContent();
        }
    }
}
