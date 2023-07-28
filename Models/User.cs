using System;
using System.Collections.Generic;

namespace TicketApp.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Firstname { get; set; } = null!;
    public string? FirstName { get; internal set; }
    public string Lastname { get; set; } = null!;
    public string? LastName { get; internal set; }
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Isadmin { get; set; }

    public bool? Isregistered { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
