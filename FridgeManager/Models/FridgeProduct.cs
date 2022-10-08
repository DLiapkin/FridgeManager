using System;
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Models
{
    public class FridgeProduct
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Product Id")]
        public Guid ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity can't be less than 0.")]
        public int Quantity { get; set; }
    }
}
