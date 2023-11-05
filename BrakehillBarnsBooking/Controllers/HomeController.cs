using BrakehillBarnsBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrakehillBarnsBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Booking(BookingModel model)
        {

            return View("Confirmation", model);
        }

        public IActionResult Confirmation(BookingModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
