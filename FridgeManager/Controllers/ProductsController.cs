using FridgeManager.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FridgeManager.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProductsAsync());
        }
    }
}
