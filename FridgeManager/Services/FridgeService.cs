using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FridgeManager.Models;
using FridgeManager.Contracts;

namespace FridgeManager.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly HttpClient _client;

        public FridgeService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("fridges");
        }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync()
        {
            var response = await _client.GetAsync("");
            response.EnsureSuccessStatusCode();
            IEnumerable<Fridge> fridges = await response.Content.ReadFromJsonAsync<IEnumerable<Fridge>>();
            return fridges;
        }

        public async Task<Fridge> GetFridgeAsync(Guid id)
        {
            var response = _client.GetAsync($"{id}").Result;
            response.EnsureSuccessStatusCode();
            Fridge fridge = await response.Content.ReadFromJsonAsync<Fridge>();
            return fridge;
        }

        public async Task<IEnumerable<FridgeProduct>> GetProductsForFridgeAsync(Guid id)
        {
            var response = await _client.GetAsync($"{id}/products");
            response.EnsureSuccessStatusCode();
            IEnumerable<FridgeProduct> products = await response.Content.ReadFromJsonAsync<IEnumerable<FridgeProduct>>();
            return products;
        }
    }
}
