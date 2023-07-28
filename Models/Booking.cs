using System;
using System.Collections.Generic;

namespace TicketApp.Models;

public partial class Booking
{
    public int Bookingid { get; set; }

    public int? Userid { get; set; }

    public int? Showtimeid { get; set; }

    public int? Numofseats { get; set; }

    public bool? Iscancelled { get; set; }

    public virtual Showtime? Showtime { get; set; }

    public virtual User? User { get; set; }
}
