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

        public void BookTickets(BookingRequestModel request)
        {
            var showtime = _context.Showtimes.FirstOrDefault(s => s.Showtimeid == request.ShowtimeId);
            var user = _context.Users.FirstOrDefault(u => u.Userid == request.UserId);

            if (showtime == null || user == null)
            {
                throw new Exception("Nieprawidłowy seans lub użytkownik.");
            }

            if (showtime.AvailableSeats < request.NumberOfTickets)
            {
                throw new Exception("Brak wystarczającej liczby wolnych miejsc.");
            }

            var booking = new Booking
            {
                Showtimeid = request.ShowtimeId,
                Userid = request.UserId,
                Numofseats = request.NumberOfTickets,
                BookingDate = DateTime.Now
            };

            showtime.AvailableSeats -= request.NumberOfTickets;

            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void CancelBooking(int bookingId)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Bookingid == bookingId) ?? throw new Exception("Nieprawidłowa rezerwacja.");
            var showtime = _context.Showtimes.FirstOrDefault(s => s.Showtimeid == booking.Showtimeid) ?? throw new Exception("Nieprawidłowy seans.");
            if (booking.Numofseats.HasValue)
            {
                showtime.AvailableSeats += booking.Numofseats.Value;
            }


            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
        
    


    }
}
