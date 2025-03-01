using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonMVC.Models

{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
       // public User User { get; set; } //forign key
        public List<OrderDetails> OrderDetails { get; set; }

    }
}
