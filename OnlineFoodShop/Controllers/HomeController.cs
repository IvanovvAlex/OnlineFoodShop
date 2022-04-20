using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodShop.Data.Models;
using OnlineFoodShop.Models;
using OnlineFoodShop.Models.Products;
using OnlineFoodShop.Services.Products;
using OnlineFoodShop.Services.Roles;
using System.Diagnostics;

namespace OnlineFoodShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductService productService;
        private readonly IRoleService roleService;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, IProductService productService, IRoleService roleService)
        {
            _logger = logger;
            this.userManager = userManager;
            this.productService = productService;
            this.roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ThanksForPurchasing()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> IndexLoggedIn()
        {
            //var user = await userManager.GetUserAsync(HttpContext.User);

            //await roleService.CreateRole("Admin");
            //await roleService.AddUserToRole(user, "Admin");
            ICollection<ProductViewModel> allProducts = await productService.GetAll();
            return View(allProducts);
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}