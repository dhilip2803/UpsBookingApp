namespace UpsBookingApp.Client.Models
{
    public class WorkspaceBooking
    {
        public int Id { get; set; }
        public int WorkspaceId { get; set; }   // Maps to the seat
        public string UserName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Workspace? Workspace { get; set; } // Navigation
    }

}
