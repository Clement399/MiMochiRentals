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
        public string GenerateOrderID(MMContext db)
        {
            var maxId = db.Orders
                .OrderByDescending(o => o.orderID)
                .Select(o => o.orderID)
                .FirstOrDefault();

            if (maxId == null)
                return "ORD001";

            int number = int.Parse(maxId.Substring(3)) + 1;
            return $"ORD{number:D3}";  // ORD001, ORD002, etc.
        }

        public void CreateOrder(MMContext db)
        {
            // Usage
            var order = new Order
            {
                orderID = GenerateOrderID(db),  // Generate custom ID
                receiptNo = "REC123",
                customerID = "CUST001"
            };

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}
