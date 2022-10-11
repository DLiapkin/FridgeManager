using FridgeManager.Contracts;
using FridgeManager.Models;
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
    }
}
