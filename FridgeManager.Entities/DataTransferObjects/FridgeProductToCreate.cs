using System;
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Entities.DataTransferObjects
{
    public class FridgeProductToCreate
    {
        [Required]
        [Display(Name = "Product Id")]
        public Guid ProductId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity can't be less than 0.")]
        public int Quantity { get; set; }
    }
}
