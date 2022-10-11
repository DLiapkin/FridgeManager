using FridgeManager.Contracts;
using FridgeManager.Models;
using FridgeManager.Models.DataTransferObjects;
using FridgeManager.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IActionResult> Create()
        {
            CreateFridgeViewModel fridgeViewModel = new CreateFridgeViewModel();
            fridgeViewModel.Fridge = new FridgeToCreate();
            fridgeViewModel.FridgeProducts.Add(new FridgeProductToAdd());
            fridgeViewModel.Products = (await _service.GetAllProductsAsync()).ToList();
            return View(fridgeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddFridgeProduct([Bind("Fridge,FridgeProducts")] CreateFridgeViewModel fridgeViewModel)
        {
            fridgeViewModel.FridgeProducts.Add(new FridgeProductToAdd());
            return PartialView("FridgeProducts", fridgeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Fridge,FridgeProducts")] CreateFridgeViewModel fridgeViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _service.CreateFridgeAsync(fridgeViewModel.Fridge, fridgeViewModel.FridgeProducts);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return View(fridgeViewModel.Fridge);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Fridge updateFridge = await _service.GetFridgeAsync(id);
            return View(updateFridge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Name,OwnerName,ModelId")] Fridge fridge)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateFridgeAsync(fridge);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return View(fridge);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteFridgeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
