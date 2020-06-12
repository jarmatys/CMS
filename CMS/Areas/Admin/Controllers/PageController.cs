using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Areas.Admin.Models.View.Page;
using CMS.Infrastructure.Helpers;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin/{controller}/{action=List}/{id?}")]
    public class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly ISeoService _seoService;

        public PageController(IPageService pageService, ISeoService seoService)
        {
            _pageService = pageService;
            _seoService = seoService;
        }

        // [ GET ] - <domain>/Page/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.PagesCount = await _pageService.MediaCount();
            var pages = await _pageService.GetAll();
            return View(pages);
        }

        // [ GET ] - <domain>/Page/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // [ POST ] - <domain>/Page/Add
        [HttpPost]
        public async Task<IActionResult> Add(PageView result)
        {
            if (await _pageService.CheckIfSlugExist(result.Slug))
            {
                ModelState.AddModelError("", "Strona o podanym linku istnieje");
            }

            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var seoSettings = await _seoService.GetSeoSettings();
            await _pageService.Create(PageHelpers.ConvertToModel(result, seoSettings.MainUrl));

            // d. Zapis fullUrl do bazki edycja helpery itp TODO

            return RedirectToAction("List", "Page");
        }

        // [ GET ] - <domain>/Page/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var page = await _pageService.Get(Id);
            return View(PageHelpers.ConvertToView(page));
        }

        // [ POST ] - <domain>/Page/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(PageView result)
        {
            var page = await _pageService.Get(result.Id);

            if(page.Slug != result.Slug)
            {
                if (await _pageService.CheckIfSlugExist(result.Slug))
                {
                    ModelState.AddModelError("", "Strona o podanym linku istnieje");
                }
            }
           
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var seoSettings = await _seoService.GetSeoSettings();

            await _pageService.Update(PageHelpers.MergeViewWithModel(page, result, seoSettings.MainUrl));

            return RedirectToAction("List", "Page");
        }

        // [ POST ] - <domain>/Page/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            await _pageService.Delete(Id);
            return RedirectToAction("List", "Page");
        }
    }
}