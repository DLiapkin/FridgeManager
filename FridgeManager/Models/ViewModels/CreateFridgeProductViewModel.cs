using FridgeManager.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Models.ViewModels
{
    public class CreateFridgeProductViewModel
    {
        [Required]
        public Guid FridgeId { get; set; }
        [Required]
        public FridgeProductToAdd FridgeProduct { get; set; }
        public List<Product> Products { get; set; }
    }
}
