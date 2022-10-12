using System;
using System.Collections.Generic;

namespace FridgeManager.Models.ViewModels
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
