namespace UpsBookingApp.Client.Models
{
    public class Workspace
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }           // 1–100
        public string Floor { get; set; } = "";       // "1st Floor", "2nd Floor"
        public string Department { get; set; } = "";
        public bool IsAvailable { get; set; } = true;
    }

}

