using System.ComponentModel.DataAnnotations;

namespace MiMochiRentals.Models
{
    public class Item
    {
        [Key]
        [Required] public int itemId { get; set; }
        [Required] public string ItemTypeCode {  get; set; } //bbs-tb-001 (for the three tall boards)
        public int quantity {  get; set; } //1

        //price and quantity should be calculated, not inserted

        public int price {  get; set; } //50
        public int bond { get; set; } //50
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
