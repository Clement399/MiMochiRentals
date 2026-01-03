using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiMochiRentals.DBContext;
using MiMochiRentals.Models;
using System.Linq;

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
                //notFound is the type (404) then the afterwards is the message
                return NotFound("it is not found");

            return itemType;
        }
        //eager loading -- specify related data to be included in query ( .Include)
        [HttpGet("ItemizedOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersWithItems()
        {
            var Orders = new List<Order>();
            try
            {
                Orders = await _context.Orders.Include(o => o.items).ToListAsync();
            }catch(Exception ex)
            {
                return BadRequest("not connected to database");
            }
            if (Orders.Count>0) {
                return Ok(Orders);
            }
            else
            {
                return Ok(Orders);
            }
        }
        //Lazy loading -- saves time and not load the each item of order in database
        //ef core does not load related data
        [HttpGet("Orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var Orders = new List<Order>();
            try
            {
                Orders = await _context.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("not connected to database");
            }
            if (Orders.Count>0)
            {
                return Ok(Orders);
            }
            else
            {
                return Ok(Orders);
            }
        }


        [HttpPost("newOrder")]
        public async Task<IActionResult> NewOrder([FromBody] Order order)
        {
            Console.WriteLine("Trying to add order");
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                //Additionals, to make it clearer

                Console.WriteLine("Adding order -- : ORD000"+ order.orderID);
                foreach (Item i in order.items)
                {
                    Console.WriteLine("Adding item : "+ i.ItemTypeCode +" Period :"+ i.startDate +" to "+ i.endDate);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Order not saved to database");
            }
            var message = new
            {
                Message = "Order Added",
                InternalOrderId = order.orderID
            };
            return Ok(message);
        } 
        /*
        public string GenerateOrderID(MMContext db)
        {
            var maxId = db.Orders
                .OrderByDescending(o => o.orderID)
                .Select(o => o.orderID)
                .FirstOrDefault();

            if (maxId == null)
                return "ORD001";W

            int number = int.Parse(maxId.Substring(3)) + 1;
            return $"ORD{number:D3}";  // ORD001, ORD002, etc.
        }*/



        [HttpPost("processOrder")]
        public void CreateOrder(MMContext db, [FromBody] Order order2)
        {
            // Usage
            var order = new Order
            {  // Generate custom ID
                customerID = 1
            };

            db.Orders.Add(order);
            db.SaveChanges();
            foreach (Item item in order.items)
            {
                AddItem(db, item);
                db.SaveChanges(); //save changes
            }
            //save to database
            db.SaveChanges();
        }

        public void AddItem(MMContext db, Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        [HttpGet("renting/{Code}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsRentingAsync(string Code)
        {
            Console.WriteLine("Finding times "+ Code +" is rented");
            List<Item> rentedItems = await _context.Items.Where(i => i.ItemTypeCode == Code).ToListAsync();
            int j = 1;
            foreach (Item item in rentedItems)
            {

                Console.WriteLine(j.ToString() +": "+item.itemId+" + "+item.quantity);
                j++;
            }
            if (!rentedItems.Any())
            {
                return new List<Item>();
            }
            return Ok(rentedItems);
        }
        [HttpGet("renting")]
        public async Task<ActionResult<IEnumerable<Item>>> GetRentedItems()
        {

            Console.WriteLine("Finding times and items is rented");
            List<Item> allRented = await _context.Items.ToListAsync();

            if (!allRented.Any())
            {
                return NotFound($"No rented items found");
            }
            return Ok(allRented);
        }
        [HttpPost("saveItem")]
        public async Task<IActionResult> AddToRent([FromBody] Item item)
        {
            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Item :"+ item +" added");
        }
        [HttpPost("saveOrder")]
        //Not needed, as items will be directly added
        public async Task<IActionResult> AddToRentOrder([FromBody] Order order, MMContext db)
        {
            try
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                foreach (Item i in order.items)
                {
                    Console.WriteLine("Adding item : "+ i.ItemTypeCode +" Period :"+ i.startDate +" to "+ i.endDate);
                    
                    //await AddToRent(i, db);
                }
            }catch (Exception ex)
            {
                return BadRequest("Order saving failed : "+ex.Message);
            }
            return Ok("Order saved");
        }
    }
}
