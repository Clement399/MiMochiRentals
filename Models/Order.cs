using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiMochiRentals.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int orderID {  get; set; } //primary key

        //[Required][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //receiptNo will be same as orderID, just with prefix 'Rec-001200' in front
        //public int receiptNo { get; set; }
        [Required] public int customerID {  get; set; } //links to customer table
        public List<Item> items { get; set; } = new();

        //start date and end date is already included inside item

        public int orderVal { get; set; }
        public int bond {  get; set; }
        public bool paid {  get; set; }

        public string payment { get; set; } = "pending";

        //to check whether bond is returned
        public bool bondReturned { get; set; }

        
        private void addItem(Item item)
        {
            items.Add(item);
        }
        private void removeItem(Item item) 
        {
            items.Remove(item);
        }
    
    
    }
}

