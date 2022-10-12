using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FridgeManager.Models;
using FridgeManager.Contracts;
using FridgeManager.Models.DataTransferObjects;

namespace FridgeManager.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly HttpClient _fridgeClient;
        private readonly HttpClient _productsClient;
        private readonly HttpClient _fridgeModelClient;

        public FridgeService(IHttpClientFactory factory)
        {
            _fridgeClient = factory.CreateClient("fridges");
            _productsClient = factory.CreateClient("products");
            _fridgeModelClient = factory.CreateClient("fridge models");
        }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync()
        {
            var response = await _fridgeClient.GetAsync("");
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Fridge>();
            }
            IEnumerable<Fridge> fridges = await response.Content.ReadFromJsonAsync<IEnumerable<Fridge>>();
            return fridges;
        }

        public async Task<Fridge> GetFridgeAsync(Guid id)
        {
            var response = _fridgeClient.GetAsync($"{id}").Result;
            response.EnsureSuccessStatusCode();
            Fridge fridge = await response.Content.ReadFromJsonAsync<Fridge>();
            return fridge;
        }

        public async Task CreateFridgeAsync(FridgeToCreate fridgeToCreate, List<FridgeProductToAdd> products)
        {
            var response = await _fridgeClient.PostAsJsonAsync("", fridgeToCreate);
            response.EnsureSuccessStatusCode();
            if (products.Count > 0)
            {
                Guid createdId = (await response.Content.ReadFromJsonAsync<Fridge>()).Id;
                await CreateProductsForFridge(createdId, products);
            }
        }

        public async Task UpdateFridgeAsync(Fridge fridge)
        {
            FridgeToUpdate fridgeToUpdate = new FridgeToUpdate()
            {
                Name = fridge.Name,
                OwnerName = fridge.OwnerName,
                ModelId = fridge.ModelId
            };
            var response = await _fridgeClient.PutAsJsonAsync($"{fridge.Id}", fridgeToUpdate);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteFridgeAsync(Guid id)
        {
            var response = await _fridgeClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateProductsForFridge(Guid fridgeId, List<FridgeProductToAdd> products)
        {
            IEnumerable<Product> avaibleProducts = await GetAllProductsAsync();
            foreach (var product in products)
            {
                if (avaibleProducts.Any(p => p.Name.Equals(product.ProductName)))
                {
                    FridgeProductToCreate productToCreate = new FridgeProductToCreate()
                    {
                        ProductId = avaibleProducts.FirstOrDefault(p => p.Name.Equals(product.ProductName)).Id,
                        Quantity = product.Quantity
                    };
                    var response = await _fridgeClient.PostAsJsonAsync($"{fridgeId}/products", productToCreate);
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        public async Task<IEnumerable<FridgeProduct>> GetProductsForFridgeAsync(Guid id)
        {
            var response = await _fridgeClient.GetAsync($"{id}/products");
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<FridgeProduct>();
            }
            IEnumerable<FridgeProduct> products = await response.Content.ReadFromJsonAsync<IEnumerable<FridgeProduct>>();
            return products;
        }

        public async Task DeleteProductForFridgeAsync(Guid fridgeId, Guid id)
        {
            var response = await _fridgeClient.DeleteAsync($"{fridgeId}/products/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task ReplenishProducts()
        {
            var responce = await _fridgeClient.GetAsync("refresh-product");
            responce.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var response = await _productsClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            IEnumerable<Product> products = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            return products;
        }

        public async Task<IEnumerable<FridgeModel>> GetAllFridgeModelsAsync()
        {
            var response = await _fridgeModelClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            IEnumerable<FridgeModel> models = await response.Content.ReadFromJsonAsync<IEnumerable<FridgeModel>>();
            return models;
        }
    }
}
