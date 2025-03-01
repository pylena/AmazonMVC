using System.ComponentModel.DataAnnotations;

namespace AmazonMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative please enter a vaild number.")]
        public int StockQuantity { get; set; }
    }
}
