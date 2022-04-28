using OnlineFoodShop.Data.Models;
using OnlineFoodShop.Models.Carts;

namespace OnlineFoodShop.Services.Carts
{
    public interface ICartService
    {
        Task<MyCartViewModel> GetCartById(string cartId);
        Task<ICollection<CartViewModel>> GetArchive();
        Task<bool>AddProduct(string id, string userId);
        Task<bool> IncreaseProduct(string id, string userId);
        Task<bool> DecreaseProduct(string id, string userId);
        Task<bool> RemoveProduct(string id, string userId);
        Task ArchiveCart(ApplicationUser user);
        Task CleanCart(ApplicationUser user);
    }
}
