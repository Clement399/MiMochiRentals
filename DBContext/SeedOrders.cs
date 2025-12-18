using MiMochiRentals.Models;

namespace MiMochiRentals.DBContext
{
    public class SeedOrders
    {
        public static List<Order> GetOrders() { 
        return new List<Order>
        {
            new Order
            {
                orderID = 1,
                receiptNo = 1,
                customerID = 1,
                orderVal = 15000,
                bond = 5000,
                paid = true,
                bondReturned = false,
                items = new List<Item>()
    },
            new Order
            {
                orderID = 2,
                receiptNo = 2,
                customerID = 1,
                orderVal = 8500,
                bond = 3000,
                paid = true,
                bondReturned = true,
                items = new List<Item>()
},
            new Order
            {
                orderID = 3,
                receiptNo = 3,
                customerID = 3,
                orderVal = 22000,
                bond = 7500,
                paid = false,
                bondReturned = false,
                items = new List<Item>()
            },
            new Order
            {
                orderID = 4,
                receiptNo = 4,
                customerID = 2,
                orderVal = 12000,
                bond = 4000,
                paid = true,
                bondReturned = true,
                items = new List<Item>()
            },
            new Order
            {
                orderID = 5,
                receiptNo = 5,
                customerID = 3,
                orderVal = 18500,
                bond = 6000,
                paid = true,
                bondReturned = false,
                items = new List<Item>()
            }
        };
    }
    }
}
