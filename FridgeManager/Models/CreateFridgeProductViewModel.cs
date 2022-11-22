using FridgeManager.Entities.DataTransferObjects;
using FridgeManager.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Models
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
