using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Entities.DataTransferObjects
{
    public class FridgeProductToAdd
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity can't be less than 0.")]
        public int Quantity { get; set; } = 0;
    }
}
