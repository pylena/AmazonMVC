using System.ComponentModel.DataAnnotations;

namespace AmazonMVC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public ICollection<Order> Orders { get; }

        


    }
}
