using System.ComponentModel.DataAnnotations;

namespace MiMochiRentals.Models
{
    public class Order
    {
        [Key]
        [Required] public string orderID {  get; set; } //primary key

        [Required] public string receiptNo { get; set; }
        [Required] public string customerID {  get; set; } //links to customer table
        public List<Item> items { get; set; } = new();

        //start date and end date is already included inside item

        public int orderVal { get; set; }
        public int bond {  get; set; }
        public bool paid {  get; set; }

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

