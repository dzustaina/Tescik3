namespace TicketApp.Models
{
    public class BookingRequestModel
    {
        public int UserId { get; set; }
        public int ShowtimeId { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
