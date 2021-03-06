using System.ComponentModel.DataAnnotations;

namespace OnlineFoodShop.Data.Models
{
    public class CartProduct
    {
        [Required]
        public string CartId { get; init; }

        public virtual Cart Cart { get; set; }

        [Required]
        public string ProductId { get; init; }

        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
