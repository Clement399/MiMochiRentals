using MiMochiRentals.DBContext;

namespace MiMochiRentals.Controllers
{
    public class OrderService
    {
        private readonly MMContext _context;
        public OrderService(MMContext context) { _context = context; }
        public async Task UpdateOrder(int OrderID, string NewStatus)
        {
            try
            {
                var order = await _context.Orders.FindAsync(OrderID);
                if (order != null) { 
                    order.payment = NewStatus;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
