using FridgeManager.Contracts;
using FridgeManager.Models;
using FridgeManager.Models.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public async Task<IActionResult> Create()
        {
            ProductToCreate product = new ProductToCreate();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DefaultQuantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Product product = await _service.GetProductByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,DefaultQuantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
