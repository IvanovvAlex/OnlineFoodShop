using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodShop.Models.Products
{
    public class CreateProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
