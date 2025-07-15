namespace UpsBookingApp.Client.Models
{
    public enum WorkspaceStatus
    {
        Available,
        Selected,
        Reserved
    }

    public class Workspace
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int SeatNumber { get; set; }
        public WorkspaceStatus Status { get; set; }
        public string Floor { get; set; } = string.Empty;

        public string? Department { get; set; }

        public string? Location { get; set; }
    }
}
