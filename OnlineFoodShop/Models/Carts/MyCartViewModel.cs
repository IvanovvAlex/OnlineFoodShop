using OnlineFoodShop.Models.Products;

namespace OnlineFoodShop.Models.Carts
{
    public class MyCartViewModel
    {
        public decimal TotalPrice { get; set; }
        public ICollection<ProductViewModel> MyProducts { get; set; } = new List<ProductViewModel>();
    }
}
