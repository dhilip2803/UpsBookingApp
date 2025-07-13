using Microsoft.AspNetCore.Mvc;

namespace UpsBookingApp.Controllers
{
    public class BookingApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
