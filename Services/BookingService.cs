using System.Collections.Generic;
using System.Linq;
using TicketApp.Models;

namespace TicketApp.Services
{
    public class BookingService
    {
        private readonly MovieAppContext _context;

        public BookingService(MovieAppContext context)
        {
            _context = context;
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking? GetBookingById(int id)
        {
            return _context.Bookings.FirstOrDefault(booking => booking.Bookingid == id);
        }

        public Booking AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        public void UpdateBooking(int id, Booking updatedBooking)
        {
            var booking = _context.Bookings.FirstOrDefault(booking => booking.Bookingid == id);
            if (booking != null)
            {
                // Update properties of the booking object with values from updatedBooking
                booking.Userid = updatedBooking.Userid;
                booking.Showtimeid = updatedBooking.Showtimeid;
                booking.Numofseats = updatedBooking.Numofseats;
                booking.Iscancelled = updatedBooking.Iscancelled;

                _context.SaveChanges();
            }
        }

        public void DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}
