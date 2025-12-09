using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiMochiRentals.Models;

namespace MiMochiRentals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("Birthday")]
        public IActionResult Birthdays()
        {
            return View();
        }
        //('api/wedding')
        [HttpGet ("Wedding")]
        public IActionResult Weddings()
        {
            return View();
        }
        [HttpGet("Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View("MainPage");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
