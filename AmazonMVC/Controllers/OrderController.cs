using AmazonMVC.Data;
using AmazonMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmazonMVC.Controllers

{
    public class OrderController : Controller
    {
        private static List<Order> orders = new List<Order>();
        private static List<Product> products = new List<Product>
    {
        new Product { ProductID = 1, Name = "Laptop", Category = "Electronics", Price = 1000, StockQuantity = 10 },
        new Product { ProductID = 2, Name = "Phone", Category = "Electronics", Price = 500, StockQuantity = 20 },
        new Product { ProductID = 3, Name = "Headphones", Category = "Accessories", Price = 200, StockQuantity = 30 }
    };


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

        // GET: /Orders/Create
        public ActionResult Create()
        {
            var viewModel = new OrderViewModel
            {
                Products = products
            };
            return View(viewModel);
        }

       
        [HttpPost]
        public ActionResult Create(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Products = products;
                return View(model);
            }

            if (model.SelectedProductIDs.Count != model.Quantities.Count)
            {
                ModelState.AddModelError("", "Mismatch between selected products and quantities.");
                model.Products = products;
                return View(model);
            }

            var order = new Order
            {
                OrderID = orders.Count + 1,
                UserID = model.UserID,
                OrderDetails = new List<OrderDetails>()
            };

            for (int i = 0; i < model.SelectedProductIDs.Count; i++)
            {
                var product = products.FirstOrDefault(p => p.ProductID == model.SelectedProductIDs[i]);
                if (product != null && model.Quantities[i] > 0 && model.Quantities[i] <= product.StockQuantity)
                {
                    order.OrderDetails.Add(new OrderDetails
                    {
                        OrderDetailID = order.OrderDetails.Count + 1,
                        OrderID = order.OrderID,
                        ProductID = product.ProductID,
                        Quantity = model.Quantities[i],
                        SubTotal = product.Price * model.Quantities[i]
                    });

                    // Reduce stock quantity
                    product.StockQuantity -= model.Quantities[i];
                }
                else
                {
                    ModelState.AddModelError("", $"Invalid quantity for {product?.Name}. Check stock availability.");
                    model.Products = products;
                    return View(model);
                }
            }

            orders.Add(order);
            return RedirectToAction("OrderHistory", new { userId = model.UserID });
        }

        // GET: /Orders/{userId}
        public ActionResult OrderHistory(int userId)
        {
            var userOrders = orders.Where(o => o.UserID == userId).ToList();
            return View(userOrders);
        }
    }


}


