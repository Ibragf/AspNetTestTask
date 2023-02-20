using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AspNetTestTask.Models
{
    public class Product
    {
        public string Id { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Category { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Quantity { get; set; }
    }
}
