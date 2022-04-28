using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineFoodShop.Data.Models;

namespace OnlineFoodShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Cart>().HasMany(c => c.Products);
            builder.Entity<CartProduct>().HasKey(x => new { x.ProductId, x.CartId });
            builder.Entity<ApplicationUser>().HasOne(t => t.Cart)
                     .WithOne(t => t.User)
                     .HasForeignKey<Cart>(t => t.UserId);

            builder.Entity<Cart>().HasOne(t => t.User)
                     .WithOne(t => t.Cart)
                     .HasForeignKey<ApplicationUser>(t => t.CartId);
        }
    }
}
