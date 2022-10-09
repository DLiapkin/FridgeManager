﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Models
{
    public class Fridge
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }
        [Required]
        [Display(Name = "Model Id")]
        public Guid ModelId { get; set; }
    }
}