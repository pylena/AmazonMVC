using AmazonMVC.Data;
using AmazonMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmazonMVC.Controllers

{
    public class OrderController : Controller
    {
        private static List<Order> orders = new List<Order>();
        private static int currentOrderId = 1;

        /*
        private readonly AppDBContext _db;

        
        public OrdersController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            var products = _db.Products.ToList();
            return View(products);
        }
        */
        // GET: Products to display on Order Form

        public IActionResult PlaceOrder(int userId, List<int> productIds, List<int> quantities)
        {
            // Validate the order (simple validation for this example)
            if (productIds.Count != quantities.Count)
            {
                ModelState.AddModelError("", "Product and quantity lists must match.");
                return View("Error");
            }

            // Create OrderDetails and calculate SubTotal
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            decimal total = 0;
            for (int i = 0; i < productIds.Count; i++)
            {
                var product = ProductController.GetProductById(productIds[i]);
                if (product == null)
                {
                    ModelState.AddModelError("", "Product not found.");
                    return View("Error");
                }
                int quantity = quantities[i];
                decimal subTotal = product.Price * quantity;
                total += subTotal;

                orderDetails.Add(new OrderDetails
                {
                    OrderDetailID = i + 1,
                    OrderID = currentOrderId,
                    ProductID = product.ProductID,
                    Quantity = quantity,
                    SubTotal = subTotal
                });
            }

            // Create Order
            Order order = new Order
            {
                OrderID = currentOrderId++,
                UserID = userId,
                OrderDetails = orderDetails
            };

            orders.Add(order);
            return View("OrderHistory", orders);
        }

        public IActionResult OrderHistory(int userId)
        {
            var userOrders = orders.FindAll(o => o.UserID == userId);
            return View(userOrders);
        }


    }
}

