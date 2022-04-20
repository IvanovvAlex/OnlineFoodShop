using OnlineFoodShop.Data.Models;

namespace OnlineFoodShop.Services.Roles
{
    public interface IRoleService
    {
        Task<bool> AddUserToRole(ApplicationUser user, string roleName);
        Task<bool> CreateRole(string name);

    }
}
