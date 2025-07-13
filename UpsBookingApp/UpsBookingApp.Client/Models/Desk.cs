namespace UPSBookingApp.Client.Models;

public class Desk
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;

    public string Floor { get; set; } = string.Empty;
}