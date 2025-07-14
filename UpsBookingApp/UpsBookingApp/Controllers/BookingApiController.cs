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

    [HttpGet("bookings")]
    public async Task<IActionResult> GetBookings() =>
        Ok(await _context.Bookings.ToListAsync());

    [HttpPost("book")]
    public async Task<IActionResult> BookDesk([FromBody] Booking booking)
    {
        var desk = await _context.Desks.FirstOrDefaultAsync(d => d.Id == booking.DeskId && d.IsAvailable);
        if (desk == null) return BadRequest("Desk unavailable");

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
}
