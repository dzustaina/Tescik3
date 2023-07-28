using System;
using System.Collections.Generic;

namespace TicketApp.Models;

public partial class Movie
{
    public int Movieid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Poster { get; set; }

    public TimeSpan? Duration { get; set; }

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
