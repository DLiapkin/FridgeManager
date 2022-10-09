using FridgeManager.Contracts;
using FridgeManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeManager.Controllers
{
    public class FridgesController : Controller
    {
        private readonly IFridgeService _service;

        public FridgesController(IFridgeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Fridge> fridges = await _service.GetAllFridgesAsync(); 
            return View(fridges);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Fridge fridge = await _service.GetFridgeAsync(id);
            return View(fridge);
        }

        public async Task<IActionResult> ProductsList(Guid id)
        {
            IEnumerable<FridgeProduct> products = await _service.GetProductsForFridgeAsync(id);
            return View(products);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteFridgeAsync(id);
            return View("Index");
        }
    }
}
