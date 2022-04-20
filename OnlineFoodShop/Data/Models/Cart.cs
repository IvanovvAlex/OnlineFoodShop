using System.ComponentModel.DataAnnotations;

namespace OnlineFoodShop.Data.Models
{
    public class Cart
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public ICollection<CartProduct> CardProducts { get; set; } = new List<CartProduct>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
