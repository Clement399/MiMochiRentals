using Microsoft.EntityFrameworkCore;
using MiMochiRentals.Models;
using System.Security.Principal;

namespace MiMochiRentals.DBContext
{
    public class MMContext : DbContext
    {
        public MMContext(DbContextOptions<MMContext> options) : base(options)
        {
        }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemType> Types { get; set; }
        public DbSet<Order> Orders { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var projectRoot = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..");
                var dbPath = Path.Combine(projectRoot, "MiMochiDatabase.db");
                optionsBuilder.UseSqlite("Data Source=MiMochiDatabase.db");
            }
        }*/
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            
            mb.Entity<Item>().HasIndex(u => u.itemId).IsUnique();
            mb.Entity<ItemType>().HasIndex(u => u.code).IsUnique();
            mb.Entity<Order>().HasIndex(u => u.receiptNo).IsUnique();

            //130 for full set

            //seed orders
            mb.Entity<Order>().HasData(SeedOrders.GetOrders());
            mb.Entity<Item>().HasData(SeedItems.GetItems());

            //TODAY :: 12/11/2025 use navigation properties?
            mb.Entity<Item>()
                .HasOne<ItemType>()
                .WithMany()
                .HasForeignKey(i => i.ItemTypeCode)
                .HasPrincipalKey(t => t.code)
                .OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Order>()
                 .HasMany<Item>(o => o.items)
                 .WithOne()
                 .HasForeignKey(i => i.orderID)  // FK in Item table
                 .OnDelete(DeleteBehavior.Cascade); ;

            //item seeding : wedding : 13 items


            //seed data
            // Hardcode data inside for each entity
            //to order, entity is picked from this entity table
            mb.Entity<ItemType>().HasData(new ItemType
            {
                //birthdays
                //baby shark
                name = "baby-shark",
                type = "circle-board",
                code = "bbs-cb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                //birthdays
                //baby shark
                name = "baby-shark",
                type = "dessert-table",
                code = "bbs-dt-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 1,
                bond = 1,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });


            //Minecraft
            mb.Entity<ItemType>().HasData(new ItemType
            {
                //birthdays
                //minecraft
                name = "minecraft",
                type = "circle-board",
                code = "mc-cb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                //birthdays
                //minecraft
                name = "minecraft",
                type = "dessert-table",
                code = "mc-dt-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 1,
                bond = 1,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });


            //background boards : 60 50 50 full set 140
            //Cocomelon
            mb.Entity<ItemType>().HasData(new ItemType
            {
                //birthdays
                //baby shark
                name = "cocomelon",
                type = "circle-board",
                code = "cm-cb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                //birthdays
                //cocomelon
                name = "cocomelon",
                type = "dessert-table",
                code = "cm-dt-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 1,
                bond = 1,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            //theme boards
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "cocomelon",
                type = "theme-board",
                code = "cm-tb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 60,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "cocomelon",
                type = "theme-board",
                code = "cm-tb-002",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "cocomelon",
                type = "theme-board",
                code = "cm-tb-003",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });


            // --- BLUEY ---
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "bluey",
                type = "circle-board",
                code = "blu-cb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "bluey",
                type = "dessert-table",
                code = "blu-dt-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 100,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });


            //background boards : 60 50 50 full set 140
            //Peppa pig
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "peppa-pig",
                type = "circle-board",
                code = "pep-cb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "peppa-pig",
                type = "dessert-table",
                code = "pep-dt-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 1,
                bond = 1,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            //theme boards
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "peppa-pig",
                type = "theme-board",
                code = "pep-tb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 60,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "peppa-pig",
                type = "theme-board",
                code = "pep-tb-002",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "peppa-pig", // name should be genre
                type = "theme-board",
                code = "pep-tb-003",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });



            // --- SPIDERMAN ---
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "spidey",
                type = "circle-board",
                code = "spi-cb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "spi",
                type = "dessert-table",
                code = "spi-dt-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 1,
                bond = 1,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });


            // --- My Little Pony ---
            //theme boards
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "my-little-pony",
                type = "theme-board",
                code = "mlp-tb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 60,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "my-little-pony",
                type = "theme-board",
                code = "mlp-tb-002",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "my-little-pony",
                type = "theme-board",
                code = "mlp-tb-003",
                genre = "birthday",
                totalQuantity = 1,
                price = 100,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "my-little-pony",
                type = "rainbow-arc",
                code = "mlp-ra-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 60,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "my-little-pony",
                type = "rainbow-arc",
                code = "mlp-ra-002",
                genre = "birthday",
                totalQuantity = 1,
                price = 60,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "my-little-pony",
                type = "rainbow-arc",
                code = "mlp-ra-003",
                genre = "birthday",
                totalQuantity = 1,
                price = 120,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            

            //FROZEN
            //theme boards
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "frozen",
                type = "theme-board",
                code = "frz-tb-001",
                genre = "birthday",
                totalQuantity = 1,
                price = 60,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "frozen",
                type = "theme-board",
                code = "frz-tb-002",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "frozen",
                type = "theme-board",
                code = "frz-tb-003",
                genre = "birthday",
                totalQuantity = 1,
                price = 50,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });

            //***** === WEDDINGS === *****
            //Items : tables, chairs, gazebo, chaffing dish
            //      : flower arch, full set , floral background
            //      : carpet, dessert table, wooden rack
            //      : steel rack

            // === tables ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "table-blue",
                type = "table",
                code = "w-table-blue-001",
                genre = "wedding",
                totalQuantity = 2,
                price = 10,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "table-white",
                type = "table",
                code = "w-table-white-001",
                genre = "wedding",
                totalQuantity = 2,
                price = 10,
                bond = 50,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });

            // === chairs ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "chair",
                type = "chair",
                code = "w-chair-001",
                genre = "wedding",
                totalQuantity = 100,
                price = 3,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });

            // === tent ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "tent",
                type = "tent",
                code = "w-tent-001",
                genre = "wedding",
                totalQuantity = 3,
                price = 60,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });

            // === chaffing dish (can pan) ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "chaffing-dish",
                type = "chaffing dish",
                code = "w-chaffing-001",
                genre = "wedding",
                totalQuantity = 10,
                price = 10,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });

            // === Full Set ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "wedding-fullset",
                type = "fullset",
                code = "w-set-001",
                genre = "wedding",
                isSet = true,
                totalQuantity = 1,
                price = 900,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });

            // === Dessert Table ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "dessert-table",
                type = "dessert-table",
                code = "w-dessert-001",
                genre = "wedding",
                totalQuantity = 1,
                price = 100,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });

            // === Floral Arch ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "floral-arch",
                type = "floral-arch",
                code = "w-floralArch-001",
                genre = "wedding",
                totalQuantity = 1,
                price = 160,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });
            // === Floral Background ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "floral-background",
                type = "floral-background",
                code = "w-background-001",
                genre = "wedding",
                totalQuantity = 2,
                price = 120,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });


            // === Wooden Arch ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "wooden-arch",
                type = "wooden-arch",
                code = "w-woodenArch-001",
                genre = "wedding",
                totalQuantity = 1,
                price = 100,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });


            // === Steel Arch ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "steel-arch",
                type = "steel-arch",
                code = "w-steelArch-001",
                genre = "wedding",
                totalQuantity = 3,
                price = 70,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });

            // === Carpet ===
            mb.Entity<ItemType>().HasData(new ItemType
            {
                name = "carpet",
                type = "carpet",
                code = "w-carpet-001",
                genre = "wedding",
                totalQuantity = 1,
                price = 80,
                bond = 100,
                sHeight = 1,
                sLength = 1,
                sWidth = 1
            });


            // 2x rainbow archs backdrop
            // one tall one short
            // 1.8m, 2m
            // 60 per one, 120 for two
            // 100
        }
    }
}
