using AmazonMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonMVC.Controllers
{
    public class ProductController : Controller
    {
        //   dummy data
        private static List<Product> products = new List<Product>
    {
        new Product { ProductID = 1, Name = "Laptop", Category = "Electronics", Price = 1000, StockQuantity = 50 },
        new Product { ProductID = 2, Name = "Phone", Category = "Electronics", Price = 500, StockQuantity = 100 },
        new Product { ProductID = 3, Name = "Coffee Mug", Category = "Kitchen", Price = 15, StockQuantity = 200 }
    };

        public IActionResult Index()
        {
            return View(products);
        }

        public static Product GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.ProductID == productId);
        }
    }
}
