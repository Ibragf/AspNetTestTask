using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AspNetTestTask.Models
{
    public class Order
    {
        public string Id { get; set; } = null!;
        public decimal Amount { get; set; }
        [Required]
        public List<string> ProductsId { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;
    }
}
