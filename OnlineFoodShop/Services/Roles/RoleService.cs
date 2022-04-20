using Microsoft.AspNetCore.Identity;
using OnlineFoodShop.Data.Models;

namespace OnlineFoodShop.Services.Roles
{
    public class RoleService : IRoleService
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<bool> CreateRole(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            await roleManager.CreateAsync(new IdentityRole
            {
                Name = name
            });
            return true;
        }
        public async Task<bool> AddUserToRole(ApplicationUser user, string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName) || user is null)
            {
                return false;
            }
            await userManager.AddToRoleAsync(user, roleName);
            return true;
        }
    }
}
