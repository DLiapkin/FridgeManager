using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Models.DataTransferObjects
{
    public class ProductToUpdate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default quantity")]
        [Range(0, int.MaxValue)]
        public int DefaultQuantity { get; set; }
    }
}
