using FridgeManager.Contracts;
using FridgeManager.Models;
using FridgeManager.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FridgeManager.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("products");
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var response = await _client.GetAsync("");
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Product>();
            }
            IEnumerable<Product> products = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var response = await _client.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode)
            {
                return new Product();
            }
            Product product = await response.Content.ReadFromJsonAsync<Product>();
            return product;
        }

        public async Task CreateProductAsync(Product product)
        {
            ProductToCreate productToCreate = new ProductToCreate()
            {
                Name = product.Name,
                DefaultQuantity = product.DefaultQuantity
            };
            var response = await _client.PostAsJsonAsync("", productToCreate);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(Product product)
        {
            ProductToUpdate productToUpdate = new ProductToUpdate()
            {
                Name = product.Name,
                DefaultQuantity= product.DefaultQuantity
            };
            var response = await _client.PutAsJsonAsync($"{product.Id}", productToUpdate);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var response = await _client.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
