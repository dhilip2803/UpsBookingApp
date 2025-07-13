namespace UpsBookingApp.Client.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int DeskId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
