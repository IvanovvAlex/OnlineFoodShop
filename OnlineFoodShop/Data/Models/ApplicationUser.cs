using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodShop.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string CartId { get; set; }

        [Required]
        public Cart Cart { get; set; }
    }
}
