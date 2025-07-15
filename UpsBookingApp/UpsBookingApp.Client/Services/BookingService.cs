using UpsBookingApp.Client.Models;

namespace UPSBookingApp.Client.Services;

public class BookingService
{

    public List<Booking> GetBookings()
    {
        return bookings;
    }
    private readonly List<Desk> desks = new()
{
    new Desk { Id = 1, Name = "Desk A1", Location = "Near Window", Description = "Near to Cafeteria", Capacity = 10, Floor = "Floor 1", IsAvailable = true },
    new Desk { Id = 2, Name = "Desk B2", Location = "Corner Spot", Description = "Beside ATS seatings", Capacity = 20, Floor = "Floor 1", IsAvailable = true },
    new Desk { Id = 3, Name = "Desk C3", Location = "Next to Pantry", Description = "Campus 30 beside pantry 1", Capacity = 15, Floor = "Floor 2", IsAvailable = true },
    new Desk { Id = 4, Name = "Desk D4", Location = "Quiet Zone", Description = "Near to game room", Capacity = 10, Floor = "Floor 2", IsAvailable = true }
};


    private readonly List<Booking> bookings = new();

    public List<Desk> GetDesks() => desks;

    public Booking? BookDesk(int deskId, string userName, DateTime start, DateTime end)
    {
        var desk = desks.FirstOrDefault(d => d.Id == deskId && d.IsAvailable);
        if (desk is null) return null;

        var booking = new Booking
        {
            Id = bookings.Count + 1,
            DeskId = deskId,
            UserName = userName,
            StartTime = start,
            EndTime = end
        };

        bookings.Add(booking);
        desk.IsAvailable = false;
        return booking;
    }

    public void CancelBooking(int deskId)
    {
        var desk = desks.FirstOrDefault(d => d.Id == deskId);
        if (desk is not null)
        {
            desk.IsAvailable = true;
        }

        var booking = bookings.FirstOrDefault(b => b.DeskId == deskId);
        if (booking is not null)
        {
            bookings.Remove(booking);
        }
    }

    public Desk? SuggestDesk(string floor)
    {
        return desks
            .Where(d => d.Floor == floor && d.IsAvailable)
            .OrderBy(d => d.Name) // sort if needed
            .FirstOrDefault();
    }

}
