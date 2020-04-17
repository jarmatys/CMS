using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure;
using CMS.Models.Db.Article;
using CMS.Models.ViewModels.Article;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class TagController : Controller
    {
        // Wstrzykiwanie serwisu do obsługi kategorii w CMS'ie
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // [ GET ] - <domain>/Tag/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            // 1. Pobieranie z bazy tagi na blogu i przekazujemy do widoku
            var tags = await _tagService.GetAll();

            return View(tags);
        }

        // [ GET ] - <domain>/Tag/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // [ POST ] - <domain>/Tag/Add
        [HttpPost]
        public async Task<IActionResult> Add(TagView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            await _tagService.Create(TagHelpers.ConvertToModel(result));

            return RedirectToAction("List");
        }

        // [ GET ] - <domain>/Tag/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var tag = await _tagService.Get(Id);
            return View(TagHelpers.ConvertToView(tag));
        }

        // [ POST ] - <domain>/Tag/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(TagView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var tag = await _tagService.Get(result.Id);

            await _tagService.Update(TagHelpers.MergeViewWithModel(tag, result));

            return RedirectToAction("List");
        }

        // [ POST ] - <domain>/Tag/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            await _tagService.Delete(Id);
            return RedirectToAction("List");
        }
    }
}