using FridgeManager.Models;
using FridgeManager.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeManager.Contracts
{
    public interface IFridgeService
    {
        public Task<IEnumerable<Fridge>> GetAllFridgesAsync();
        public Task<Fridge> GetFridgeAsync(Guid id);
        public Task CreateFridgeAsync(FridgeToCreate fridge, List<FridgeProductToAdd> products);
        public Task UpdateFridgeAsync(Fridge fridge);
        public Task DeleteFridgeAsync(Guid id);
        public Task<IEnumerable<FridgeProduct>> GetProductsForFridgeAsync(Guid id);
        public Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
