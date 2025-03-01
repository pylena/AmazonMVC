using System.ComponentModel.DataAnnotations;

namespace AmazonMVC.Models
{
    
        public class OrderViewModel
        {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid User ID.")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please select at least one product.")]

        public List<int> SelectedProductIDs { get; set; } = new List<int>();
        [Required(ErrorMessage = "Please enter quantities for the selected products.")]

        public List<int> Quantities { get; set; } = new List<int>();
            public List<Product> Products { get; set; } = new List<Product>();
        }
    }


