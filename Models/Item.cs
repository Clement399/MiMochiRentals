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
        public int orderID { get; set; } // Foreign key - matches Order.orderID

        // Navigation property -- we dont want this because we want a one way relation
        //[ForeignKey("orderID")]
        //public Order? Order { get; set; }

        public int quantity { get; set; } // 1
        public int price { get; set; } // 50
        public int bond { get; set; } // 50
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        [Range(1, 3)]
        public int startPeriod { get; set; } = 0; //1 - moring, 2- afternoon, 3- evening
        [Range(1, 3)]
        public int endPeriod { get; set; } = 0;
    }
}