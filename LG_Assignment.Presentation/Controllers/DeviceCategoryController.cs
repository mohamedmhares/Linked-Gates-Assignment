using LG_Assignment.Application.Services;
using LG_Assignment.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LG_Assignment.Web.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public DeviceCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeviceCategory category, List<string> propertyDescriptions)
        {
            if (ModelState.IsValid)
            {
                if (propertyDescriptions != null && propertyDescriptions.Any())
                {
                    foreach (var description in propertyDescriptions)
                    {
                        if (!string.IsNullOrWhiteSpace(description)) 
                        {
                            var propertyItem = new PropertyItem { Description = description };
                            category.PropertyItems.Add(propertyItem);
                        }
                    }
                }

                await _categoryService.AddCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DeviceCategory category, List<string> propertyDescriptions)
        {
            if (ModelState.IsValid)
            {
                category.PropertyItems.Clear();
                foreach (var description in propertyDescriptions)
                {
                    var propertyItem = new PropertyItem { Description = description };
                    category.PropertyItems.Add(propertyItem);
                }

                await _categoryService.UpdateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
