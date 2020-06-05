using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure;
using CMS.Models.ViewModels.Article;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // Wstrzykiwanie serwisu do obsługi kategorii w CMS'ie
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // [ GET ] - <domain>/Category/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            // 1. Pobieranie z bazy kategorii na blogu i przekazujemy do widoku
            var categories = await _categoryService.GetAll();

            return View(categories);
        }

        // [ GET ] - <domain>/Category/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // [ POST ] - <domain>/Category/Add
        [HttpPost]
        public async Task<IActionResult> Add(CategoryView result)
        {
            if (await _categoryService.CheckIfCategoryExist(result.Name))
            {
                ModelState.AddModelError("", "Kategoria o tej nazwie już istnieje");
            }

            if (!ModelState.IsValid)
            {
                return View(result);
            }

            await _categoryService.Create(CategoryHelpers.ConvertToModel(result));

            return RedirectToAction("List");
        }

        // [ GET ] - <domain>/Category/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var category = await _categoryService.Get(Id);
            return View(CategoryHelpers.ConvertToView(category));
        }

        // [ POST ] - <domain>/Category/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryView result)
        {
            var category = await _categoryService.Get(result.Id);

            // sprawdzamy dopiero jeżeli tytuł się 
            if (category.Name != result.Name)
            {
                if (await _categoryService.CheckIfCategoryExist(result.Name))
                {
                    ModelState.AddModelError("", "Kategoria o tej nazwie już istnieje");
                }
            }
            
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            await _categoryService.Update(CategoryHelpers.MergeViewWithModel(category, result));

            return RedirectToAction("List");
        }

        // [ POST ] - <domain>/Category/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            await _categoryService.Delete(Id);
            return RedirectToAction("List");
        }
    }
}