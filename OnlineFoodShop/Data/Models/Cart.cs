using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodShop.Data.Models
{
    public class Cart
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public bool IsArchived { get; set; }
        public string? OrderDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
