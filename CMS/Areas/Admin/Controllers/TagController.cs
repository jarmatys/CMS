using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Areas.Admin.Models.View.Article;
using CMS.Infrastructure;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin/{controller}/{action=List}/{id?}")]
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
            if (await _tagService.CheckIfTagExist(result.Name))
            {
                ModelState.AddModelError("", "Tag o tej nazwie już istnieje");
            }

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
            var tag = await _tagService.Get(result.Id);
            
            if(tag.Name != result.Name)
            {
                if (await _tagService.CheckIfTagExist(result.Name))
                {
                    ModelState.AddModelError("", "Tag o tej nazwie już istnieje");
                }
            }
           
            if (!ModelState.IsValid)
            {
                return View(result);
            }


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