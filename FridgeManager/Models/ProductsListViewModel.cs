using System;
using System.Collections.Generic;
using FridgeManager.Entities.Models;

namespace FridgeManager.Models
{
    public class ProductsListViewModel
    {
        public Guid FridgeId { get; set; }
        public List<FridgeProduct> FridgeProducts { get; set; }
        public List<Product> Products { get; set; }

        public ProductsListViewModel()
        {
            FridgeProducts = new List<FridgeProduct>();
            Products = new List<Product>();
        }
    }
}
