using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineFoodShop.Data;
using OnlineFoodShop.Data.Models;

namespace OnlineFoodShop.Services.Carts
{
    public class CartService : ICartService
    {
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> userManager;
        public CartService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<bool> AddProduct(string id, string userId)
        {
            Product product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }

            ApplicationUser user = await context.ApplicationUser.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                return false;
            }
            //user.cart.products.add(product);
            Cart myCart = await context.Carts.FirstOrDefaultAsync(x => x.Id == user.CartId);
            if (myCart != null)
            {
                CartProduct cartProduct = await context.CartProduct.FirstOrDefaultAsync(x => x.CartId == myCart.Id && x.ProductId == product.Id);

                if (cartProduct is null)
                {
                    cartProduct = new CartProduct
                    {
                        CartId = myCart.Id,
                        ProductId = product.Id,
                        Quantity = 0,
                    };
                    context.CartProduct.Add(cartProduct);
                }
                cartProduct.Quantity++;
                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task CleanCart(ApplicationUser user)
        {
            ICollection<CartProduct> myCartProducts = await context.CartProduct
                .Include(x => x.Product)
                .Include(x => x.Cart)
                .Where(x => x.CartId == user.CartId)
                .ToListAsync();

            foreach (CartProduct cartProduct in myCartProducts)
            {
                context.CartProduct.Remove(cartProduct);
            }
            await context.SaveChangesAsync();
        }

        public async Task<bool> RemoveProduct(string id, string userId)
        {
            Product product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }

            ApplicationUser user = await context.ApplicationUser.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                return false;
            }
            //user.cart.products.add(product);
            Cart myCart = await context.Carts.FirstOrDefaultAsync(x => x.Id == user.CartId);
            if (myCart != null)
            {
                CartProduct cartProduct = await context.CartProduct.FirstOrDefaultAsync(x => x.CartId == myCart.Id && x.ProductId == product.Id);

                if (cartProduct != null && cartProduct.Quantity > 1)
                {
                    cartProduct.Quantity--;
                }
                else if (cartProduct != null && cartProduct.Quantity == 1)
                {
                    context.CartProduct.Remove(cartProduct);
                }
                await context.SaveChangesAsync();
            }
            return true;
        }
    }
}
