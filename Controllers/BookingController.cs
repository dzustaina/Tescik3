using Microsoft.AspNetCore.Mvc;
using TicketApp.Models;
using TicketApp.Services;

namespace TicketApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet("{Bookingid}")]
        public IActionResult GetBooking(int Bookingid)
        {
            var booking = _bookingService.GetBookingById(Bookingid);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            if (booking == null)
            {
                return BadRequest();
            }

            var addedBooking = _bookingService.AddBooking(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = addedBooking.Bookingid }, addedBooking);
        }

        [HttpPut("{Bookingid}")]
        public IActionResult UpdateBooking(int Bookingid, Booking updatedBooking)
        {
            var booking = _bookingService.GetBookingById(Bookingid);
            if (booking == null)
            {
                return NotFound();
            }

            _bookingService.UpdateBooking(Bookingid, updatedBooking);
            return NoContent();
        }

        [HttpDelete("{Bookingid}")]
        public IActionResult DeleteBooking(int Bookingid)
        {
            var booking = _bookingService.GetBookingById(Bookingid);
            if (booking == null)
            {
                return NotFound();
            }

            _bookingService.DeleteBooking(Bookingid);
            return NoContent();
        }

        
    }
}
