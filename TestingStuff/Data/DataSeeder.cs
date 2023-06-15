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
                var categories = new List<Category>
                {
                    new Category { Name = "Kategoria 1", Description = "Opis kategorii 1" },
                    new Category { Name = "Kategoria 2", Description = "Opis kategorii 2" },
                };

                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }

            if (!_context.Suppliers.Any())
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier { Name = "Dostawca 1", ContactDetails = "Szczegóły kontaktu 1", Email = "dostawca1@example.com" },
                    new Supplier { Name = "Dostawca 2", ContactDetails = "Szczegóły kontaktu 2", Email = "dostawca2@example.com" },
                };

                _context.Suppliers.AddRange(suppliers);
                _context.SaveChanges();
            }

            if (!_context.Products.Any())
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync("https://miro.medium.com/v2/resize:fit:640/format:webp/1*vhl49RME0h8TYSbmJ8StdA.png").Result;
                var imageBytes = response.Content.ReadAsByteArrayAsync().Result;

                // Zasiej produkty
                var products = new List<Product>
                {
                    new Product { Name = "Produkt 1", Description = "Opis produktu 1", Price = 10.00m, Quantity = 10, CategoryId = 1, SupplierId = 1, Image = imageBytes },
                    new Product { Name = "Produkt 2", Description = "Opis produktu 2", Price = 20.00m, Quantity = 20, CategoryId = 2, SupplierId = 2, Image = imageBytes },
                };

                _context.Products.AddRange(products);
                _context.SaveChanges();
            }

            if (!_context.OrderItems.Any())
            {
                var order = new Order { OrderNumber = "Zamówienie 1", OrderDate = DateTime.Now, SupplierId = 1 };
                _context.Orders.Add(order);
                _context.SaveChanges();

                var orderItem = new OrderItem { ProductId = 2, Quantity = 1, Price = 10.00m, OrderId = 1 };
                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();

                order.OrderItems = new List<OrderItem> { orderItem };
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
        }
    }
}
