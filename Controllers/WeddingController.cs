using Microsoft.AspNetCore.Mvc;

namespace MiMochiRentals.Controllers
{
    [Route("api/[controller]")]
    public class WeddingController : Controller
    {
        [HttpGet]
        public IActionResult Page()
        {
            Console.WriteLine("Changing page to wedding");
            return View("../Home/Weddings");
        }
    }
}
