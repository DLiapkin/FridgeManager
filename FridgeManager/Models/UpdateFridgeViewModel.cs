using FridgeManager.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Models
{
    public class UpdateFridgeViewModel
    {
        [Required]
        public Fridge Fridge { get; set; }
        public List<FridgeModel> Models { get; set; }

        public UpdateFridgeViewModel()
        {
            Models = new List<FridgeModel>();
        }
    }
}
