using MiMochiRentals.Models;

namespace MiMochiRentals.DBContext
{
    public class SeedItems
    {
        public static List<Item> GetItems()
        {
            return new List<Item>
    {
        // --- Order 1 (Total Val: 15000) ---
        new Item {
            itemId = 1, orderID = 1, ItemTypeCode = "w-set-001", // Wedding Full Set
            quantity = 1, price = 900, bond = 100,
            startDate = new DateTime(2025, 5, 10), endDate = new DateTime(2025, 5, 12),
            startPeriod = 1, endPeriod = 2
        },
        new Item {
            itemId = 2, orderID = 1, ItemTypeCode = "w-chair-001", // 50 extra chairs
            quantity = 50, price = 3, bond = 50,
            startDate = new DateTime(2025, 5, 10), endDate = new DateTime(2025, 5, 12),
            startPeriod = 1, endPeriod = 2
        },

        // --- Order 2 (Total Val: 8500) ---
        new Item {
            itemId = 3, orderID = 2, ItemTypeCode = "blu-cb-001", // Bluey Circle Board
            quantity = 1, price = 50, bond = 50,
            startDate = new DateTime(2025, 6, 1), endDate = new DateTime(2025, 6, 2),
            startPeriod = 2, endPeriod = 2
        },
        new Item {
            itemId = 4, orderID = 2, ItemTypeCode = "blu-dt-001", // Bluey Dessert Table
            quantity = 1, price = 100, bond = 100,
            startDate = new DateTime(2025, 6, 1), endDate = new DateTime(2025, 6, 2),
            startPeriod = 2, endPeriod = 2
        },

        // --- Order 3 (Total Val: 22000) ---
        new Item {
            itemId = 5, orderID = 3, ItemTypeCode = "w-tent-001", // 2 Wedding Tents
            quantity = 2, price = 60, bond = 100,
            startDate = new DateTime(2025, 7, 15), endDate = new DateTime(2025, 7, 17),
            startPeriod = 1, endPeriod = 1
        },
        new Item {
            itemId = 6, orderID = 3, ItemTypeCode = "w-floralArch-001", // Floral Arch
            quantity = 1, price = 160, bond = 100,
            startDate = new DateTime(2025, 7, 15), endDate = new DateTime(2025, 7, 17),
            startPeriod = 1, endPeriod = 1
        },

        // --- Order 4 (Total Val: 12000) ---
        new Item {
            itemId = 7, orderID = 4, ItemTypeCode = "mc-cb-001", // Minecraft Circle Board
            quantity = 1, price = 50, bond = 50,
            startDate = new DateTime(2025, 8, 20), endDate = new DateTime(2025, 8, 21),
            startPeriod = 1, endPeriod = 3
        },
        new Item {
            itemId = 8, orderID = 4, ItemTypeCode = "mc-dt-001", // Minecraft Dessert Table
            quantity = 1, price = 1, bond = 1,
            startDate = new DateTime(2025, 8, 20), endDate = new DateTime(2025, 8, 21),
            startPeriod = 1, endPeriod = 3
        },

        // --- Order 5 (Total Val: 18500) ---
        new Item {
            itemId = 9, orderID = 5, ItemTypeCode = "mlp-ra-003", // My Little Pony Rainbow Arc
            quantity = 1, price = 120, bond = 100,
            startDate = new DateTime(2025, 9, 05), endDate = new DateTime(2025, 9, 06),
            startPeriod = 1, endPeriod = 2
        },
        new Item {
            itemId = 10, orderID = 5, ItemTypeCode = "mlp-tb-001", // MLP Theme Board
            quantity = 1, price = 60, bond = 50,
            startDate = new DateTime(2025, 9, 05), endDate = new DateTime(2025, 9, 06),
            startPeriod = 1, endPeriod = 2
        }
    };
        }
    }
}
