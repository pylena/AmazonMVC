using System.ComponentModel.DataAnnotations;

namespace AmazonMVC.Models
{
    public class OrderDetails
    {
        [Key]

        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Subtotal must be greater than zero.")]

        public decimal SubTotal { get; set; }
        // public int OrderID { get; set; } refernce 
        //public Order Order { get; set; }

        // public int ProductID { get; set; }
        //public Product Product { get; set; }


    }
}
