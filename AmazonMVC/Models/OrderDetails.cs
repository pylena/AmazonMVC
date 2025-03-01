using System.ComponentModel.DataAnnotations;

namespace AmazonMVC.Models
{
    public class OrderDetails
    {
        [Key]

        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        // public int OrderID { get; set; } refernce 
        //public Order Order { get; set; }

        // public int ProductID { get; set; }
        //public Product Product { get; set; }


    }
}
