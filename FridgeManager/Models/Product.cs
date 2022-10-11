﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int DefaultQuantity { get; set; }
    }
}