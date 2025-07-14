using Microsoft.AspNetCore.Mvc;
using UpsBookingApp.Client.Models;
using UPSBookingApp.Data;

namespace UpsBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("add-desk")]
        public async Task<IActionResult> AddDesk([FromBody] Desk desk)
        {
            _context.Desks.Add(desk);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete-desk/{id}")]
        public async Task<IActionResult> DeleteDesk(int id)
        {
            var desk = await _context.Desks.FindAsync(id);
            if (desk == null) return NotFound();

            var bookings = _context.Bookings.Where(b => b.DeskId == id);
            _context.Bookings.RemoveRange(bookings); // remove linked bookings
            _context.Desks.Remove(desk);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }

}
