using Microsoft.AspNetCore.Mvc;

namespace MiMochiRentals.Controllers
{
    [Route("api/[controller]")]
    public class BirthdayController : Controller
    {
        [HttpGet]
        public IActionResult Page()
        {
            Console.WriteLine("Changing page to birthday");
            return View("../Home/Birthdays");
        }
        [HttpGet ("babyShark")]
        public IActionResult babyShark()
        {
            Console.WriteLine("Childrens page : baby shark");
            return View();
        }

        [HttpGet("minecraft")]
        public IActionResult minecraft()
        {
            Console.WriteLine("Childrens page : minecraft");
            return View();
        }
        [HttpGet("cocomelon")]
        public IActionResult cocomelon()
        {
            Console.WriteLine("Childrens page : cocomelon");
            return View();
        }

        [HttpGet("peppa")]
        public IActionResult Peppa()
        {
            Console.WriteLine("Childrens page : peppa pig");
            return View("peppapig");
        }

        [HttpGet("bluey")]
        public IActionResult Bluey()
        {
            Console.WriteLine("Childrens page : bluey the dog");
            return View();
        }
        [HttpGet("frozen")]
        public IActionResult Frozen()
        {
            Console.WriteLine("Childrens page : elsa from Frozen");
            return View();
        }
        [HttpGet("pony")]
        public IActionResult Pony()
        {
            Console.WriteLine("Childrens page : myLittlePony");
            return View("myLittlePony");
        }
    

        [HttpGet("spiderman")]
        public IActionResult Spidey()
        {
            Console.WriteLine("Childrens page : spiderman");
            return View("spidey");
        }
    }
}
