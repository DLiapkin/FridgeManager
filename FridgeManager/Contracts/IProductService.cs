using FridgeManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeManager.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<Product> GetProductByIdAsync(Guid id);
        public Task CreateProductAsync(Product product);
        public Task UpdateProductAsync(Product product);
        public Task DeleteProductAsync(Guid id);
    }
}
