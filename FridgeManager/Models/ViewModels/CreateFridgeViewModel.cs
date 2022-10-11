using FridgeManager.Models.DataTransferObjects;
using System.Collections.Generic;

namespace FridgeManager.Models.ViewModels
{
    public class CreateFridgeViewModel
    {
        public FridgeToCreate Fridge { get; set; }
        public List<FridgeProductToAdd> FridgeProducts { get; set; }
        public List<Product> Products { get; set; }

        public CreateFridgeViewModel()
        {
            FridgeProducts = new List<FridgeProductToAdd>();
            Products = new List<Product>();
        }
    }
}
