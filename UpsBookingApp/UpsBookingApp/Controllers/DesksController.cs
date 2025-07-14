using Microsoft.AspNetCore.Mvc;

namespace UpsBookingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesksController : ControllerBase
    {
        //private readonly BookingDbContext _context;

        //public DesksController(BookingDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetDesks()
        //{
        //    var desks = await _context.Desks.ToListAsync();
        //    return Ok(desks);
        //}
    }

}
