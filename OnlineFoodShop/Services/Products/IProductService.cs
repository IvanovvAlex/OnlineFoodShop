using OnlineFoodShop.Data.Models;
using OnlineFoodShop.Models.Carts;
using OnlineFoodShop.Models.Products;

namespace OnlineFoodShop.Services.Products
{
    public interface IProductService
    {
        Task<ICollection<ProductViewModel>> GetAll();
        Task<MyCartViewModel> GetMyProducts(ApplicationUser user);
        Task<CreateProductViewModel> Create(CreateProductViewModel model);
        Task<bool> Delete(string id);
    }
}
