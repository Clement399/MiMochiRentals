using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiMochiRentals.DBContext;
using MiMochiRentals.Models;

namespace MiMochiRentals.Controllers
{
    [Route("items/[controller]")]
    public class ItemController : Controller
    {
        private readonly MMContext _context;
        public ItemController(MMContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ItemType>>> GetItemTypes()
        {
            return await _context.Types.ToListAsync();
        }
        // Get by code
        [HttpGet("{code}")]
        public async Task<ActionResult<ItemType>> GetItemType(string code)
        {
            var itemType = await _context.Types
                .FirstOrDefaultAsync(i => i.code == code);

            if (itemType == null)
                return NotFound();

            return itemType;
        }
    }
}
