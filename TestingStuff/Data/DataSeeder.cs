using TestingStuff.Models;
using TestingStuff.Data;
using System.Net.Http;

namespace TestingStuff.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (!_context.Categories.Any())
            {
                // Seed categories
                var categories = new List<Category>
                {
                    new Category { Name = "Category 1", Description = "Category 1 description" },
                    new Category { Name = "Category 2", Description = "Category 2 description" },
                    // Add more categories as needed
                };

                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }

            if (!_context.Suppliers.Any())
            {
                // Seed suppliers
                var suppliers = new List<Supplier>
                {
                    new Supplier { Name = "Supplier 1", ContactDetails = "Contact details 1", Email = "supplier1@example.com" },
                    new Supplier { Name = "Supplier 2", ContactDetails = "Contact details 2", Email = "supplier2@example.com" },
                    // Add more suppliers as needed
                };

                _context.Suppliers.AddRange(suppliers);
                _context.SaveChanges();
            }

            if (!_context.Products.Any())
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync("https://miro.medium.com/v2/resize:fit:640/format:webp/1*vhl49RME0h8TYSbmJ8StdA.png").Result;
                var imageBytes = response.Content.ReadAsByteArrayAsync().Result;

                // Seed products
                var products = new List<Product>
                {
                    new Product { Name = "Product 1", Description = "Product 1 description", Price = 10.00m, Quantity = 10, CategoryId = 1, SupplierId = 1, Image = imageBytes },
                    new Product { Name = "Product 2", Description = "Product 2 description", Price = 20.00m, Quantity = 20, CategoryId = 2, SupplierId = 2, Image = imageBytes },
                    // Add more products as needed
                };

                _context.Products.AddRange(products);
                _context.SaveChanges();
            }

            if(!_context.OrderItems.Any())
            {
                // Seed Order
                var order = new Order { OrderNumber = "Order 1", OrderDate = DateTime.Now, SupplierId = 1 };
                _context.Orders.Add(order);
                _context.SaveChanges();

                // Seed OrderItem
                var orderItem = new OrderItem { ProductId = 2, Quantity = 1, Price = 10.00m, OrderId = 1 };
                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();

                // Uodate Order.OrderItems
                order.OrderItems = new List<OrderItem> { orderItem };
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
        }
    }
}
