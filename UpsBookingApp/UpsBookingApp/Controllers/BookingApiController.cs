using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpsBookingApp.Client.Models;
using UPSBookingApp.Data;

[ApiController]
[Route("api/[controller]")]
public class BookingApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("desks")]
    public async Task<IActionResult> GetDesks() =>
        Ok(await _context.Desks.ToListAsync());

    //[HttpGet("workspace")]
    //public async Task<IActionResult> GetWorkSpaceData() =>
    //   Ok(await _context.Workspaces.ToListAsync());

    [HttpGet("bookings")]
    public async Task<IActionResult> GetBookings() =>
        Ok(await _context.Bookings.ToListAsync());

    [HttpPost("book")]
    public async Task<IActionResult> BookDesk([FromBody] Booking booking)
    {
        var desk = await _context.Desks.FirstOrDefaultAsync(d => d.Id == booking.DeskId && d.IsAvailable);
        if (desk == null) return BadRequest("Desk unavailable");
        booking.BookingType = "MeetingRoom";
        _context.Bookings.Add(booking);
        desk.IsAvailable = false;
        await _context.SaveChangesAsync();
        return Ok(booking);
    }

    [HttpPost("cancel/{deskId}")]
    public async Task<IActionResult> CancelBooking(int deskId)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.DeskId == deskId);
        if (booking == null) return NotFound();

        _context.Bookings.Remove(booking);
        var desk = await _context.Desks.FirstOrDefaultAsync(d => d.Id == deskId);
        if (desk != null) desk.IsAvailable = true;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("validate/{userId}")]
    public async Task<IActionResult> ValidateUser(string userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost("workspace/book")]
    public async Task<IActionResult> BookWorkspaceSeat([FromBody] Booking booking)
    {
        // Optional: Validate
        if (booking.StartTime >= booking.EndTime)
            return BadRequest("Invalid time range.");

        var overlappingBooking = await _context.Bookings
            .AnyAsync(b =>
                b.DeskId == booking.DeskId &&
                b.StartTime < booking.EndTime &&
                b.EndTime > booking.StartTime);

        if (overlappingBooking)
            return Conflict("Seat already booked for the selected time.");

        booking.BookingType = "Workspace"; // Optional
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return Ok(booking);
    }

}
