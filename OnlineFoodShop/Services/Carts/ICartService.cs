using OnlineFoodShop.Data.Models;

namespace OnlineFoodShop.Services.Carts
{
    public interface ICartService
    {
        Task<bool>AddProduct(string id, string userId);
        Task<bool> RemoveProduct(string id, string userId);
        Task CleanCart(ApplicationUser user);
    }
}
