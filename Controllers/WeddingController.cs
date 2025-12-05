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
        [HttpGet ("tables")]
        public IActionResult tables()
        {
            Console.WriteLine("Rent tables page");
            return View("tablesChairs");
        }
        [HttpGet("arch")]
        public IActionResult arch()
        {
            Console.WriteLine("Rent flower arc page");
            return View("floralArch");
        }
        [HttpGet("backlash")]
        public IActionResult backlash()
        {
            Console.WriteLine("Rent floral backboard page");
            return View("floralBacklash");
        }
        [HttpGet("tent")]
        public IActionResult tent()
        {
            Console.WriteLine("Rent tent page");
            return View("Tent");
        }
        [HttpGet("desserttable")]
        public IActionResult dessertTable()
        {
            Console.WriteLine("Rent dessert tables page");
            return View("dessertTable");
        }
        [HttpGet("chaffing")]
        public IActionResult chaffing()
        {
            Console.WriteLine("Rent chaffing dishes page");
            return View("catering");
        }
    }
}
