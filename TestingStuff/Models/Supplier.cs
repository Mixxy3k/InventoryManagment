using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestingStuff.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactDetails { get; set; } = null!;
        public string Email { get; set; } = null!;

         public List<Product> Products { get; set; } = null!;
    }
}