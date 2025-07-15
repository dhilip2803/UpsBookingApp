using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpsBookingApp.Client.Models;
using UPSBookingApp.Data;

namespace UpsBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspaceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkspaceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() => Ok(await _context.Workspaces.ToListAsync());

        [HttpPost("book")]
        public async Task<IActionResult> BookSeat([FromBody] Booking booking)
        {
            var workspace = await _context.Workspaces.FirstOrDefaultAsync(w => w.Id == booking.DeskId && w.IsAvailable);
            if (workspace == null) return BadRequest("Seat not available");

            var overlap = await _context.Bookings.AnyAsync(b =>
                b.DeskId == booking.DeskId &&
                b.StartTime < booking.EndTime &&
                b.EndTime > booking.StartTime);

            if (overlap) return Conflict("Seat already booked");

            booking.BookingType = "Workspace";
            _context.Bookings.Add(booking);
            workspace.IsAvailable = false;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetSeats()
        {
            _context.Workspaces.RemoveRange(_context.Workspaces);
            await _context.SaveChangesAsync();

            var newSeats = new List<Workspace>();
            for (int i = 1; i <= 100; i++)
            {
                newSeats.Add(new Workspace
                {
                    SeatNumber = i,
                    Floor = i <= 50 ? "1st Floor" : "2nd Floor",
                    Department = "General",
                    IsAvailable = true
                });
            }

            await _context.Workspaces.AddRangeAsync(newSeats);
            await _context.SaveChangesAsync();
            return Ok("Reset done");
        }
    }

}
