using FridgeManager.Entities.DataTransferObjects;
using FridgeManager.Entities.Models;
using System.Collections.Generic;

namespace FridgeManager.Models
{
    public class CreateFridgeViewModel
    {
        public FridgeToCreate Fridge { get; set; }
        public List<FridgeProductToAdd> FridgeProducts { get; set; }
        public List<Product> Products { get; set; }
        public List<FridgeModel> Models { get; set; }

        public CreateFridgeViewModel()
        {
            FridgeProducts = new List<FridgeProductToAdd>();
            Products = new List<Product>();
            Models = new List<FridgeModel>();
        }
    }
}
