using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Models.ViewModels.Article;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class ArticleController : Controller
    {
        // Wstrzykiwanie serwisu do obsługi kategorii w CMS'ie
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, ITagService tagService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        // [ GET ] - <domain>/Article/Lists
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var articles = await _articleService.GetAll();
            return View(articles);
        }

        // [ GET ] - <domain>/Article/Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // 1. Pobieranie listy tagów oraz kategorii
            ViewBag.Categories = await _categoryService.GetAll();
            ViewBag.Tags = await _tagService.GetAll();

            return View();
        }

        // [ POST ] - <domain>/Article/Add
        [HttpPost]
        public async Task<IActionResult> Add(ArticleView result)
        {
            // 1. Pobieranie listy tagów oraz kategorii
            ViewBag.Categories = await _categoryService.GetAll();
            ViewBag.Tags = await _tagService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(result);
            }

            return RedirectToAction("List");
        }
    }
}