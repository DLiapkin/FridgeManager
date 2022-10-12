using FridgeManager.Entities.Models;
using FridgeManager.Entities.DataTransferObjects;
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
        public Task CreateProductsForFridge(Guid fridgeId, List<FridgeProductToAdd> products);
        public Task DeleteProductForFridgeAsync(Guid fridgeId, Guid Id);
        public Task ReplenishProducts();
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<IEnumerable<FridgeModel>> GetAllFridgeModelsAsync();
    }
}
