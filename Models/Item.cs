using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiMochiRentals.Models
{
    public class Item
    {
        [Key]
        [Required]
        public int itemId { get; set; } // Auto-increment primary key

        [Required]
        public string ItemTypeCode { get; set; } // bbs-tb-001

        [Required]
        public string orderID { get; set; } // Foreign key - matches Order.orderID

        // Navigation property
        //[ForeignKey("orderID")]
        //public Order? Order { get; set; }

        public int quantity { get; set; } // 1
        public int price { get; set; } // 50
        public int bond { get; set; } // 50
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public enum Period
        {
            Morning,
            Evening,
            Afternoon
        }
    }
}