using System;
using System.Collections.Generic;

namespace TicketApp.Models;

public partial class Showtime
{
    public int Showtimeid { get; set; }

    public int? Movieid { get; set; }

    public DateTime? Startdatetime { get; set; }
    public int AvailableSeats { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Movie? Movie { get; set; }
}
