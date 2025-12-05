using System.ComponentModel.DataAnnotations;

namespace MiMochiRentals.Models
{
    // A class for each item
    public class ItemType
    {
        
        [Required] public string name { get; set; } //baby-shark
        public string type { get; set; } //theme-board
        [Key]
        [Required] public string code { get; set; } //bbs-tb-001 (for the three tall boards)
        public string genre { get; set; } //wedding / birthday
        public bool isSet { get; set; } = false;
        public int totalQuantity { get; set; } //1
        public int price { get; set; } //50
        public int bond { get; set; } //50
        public double sHeight { get; set; } //150cm
        public double sWidth { get; set; } //70cm
        public double sLength { get; set; } //30cm
        public double weight { get; set; } //0.55kg

        override public string ToString()
        {
            return (code+" | "+type+" | "+ name);
        }
    }
}
