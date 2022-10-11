using FridgeManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeManager.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
    }
}
