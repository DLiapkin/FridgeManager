using FridgeManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeManager.Contracts
{
    public interface IFridgeService
    {
        public Task<IEnumerable<Fridge>> GetAllFridgesAsync();
        public Task<Fridge> GetFridgeAsync(Guid id);
        public Task<IEnumerable<FridgeProduct>> GetProductsForFridgeAsync(Guid id);
    }
}
