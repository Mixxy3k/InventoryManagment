using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestingStuff.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; } = null!; // Image stored as a blob, it's not the best way to do it but it's the easiest

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
    }
}