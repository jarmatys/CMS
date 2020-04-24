using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Helpers;
using CMS.Models.Db.Account;
using CMS.Models.ViewModels.Article;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        // Wstrzykiwanie serwisu do obsługi kategorii w CMS'ie
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly ICloudService _cloudService;
        private readonly ITaxonomyService _taxonomyService;
        private readonly UserManager<User> _userManager;


        public ArticleController(IArticleService articleService, ICategoryService categoryService, ITagService tagService, ICloudService cloudService, ITaxonomyService taxonomyService, UserManager<User> userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _tagService = tagService;
            _cloudService = cloudService;
            _taxonomyService = taxonomyService;
            _userManager = userManager;
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

            // 2.Poprawnie zwalidowane post zapisuję do bazy danych

            // a. Pobranie usera
            var user = await _userManager.GetUserAsync(User);

            // b. Zapis zdjęcia
            var medium = await _cloudService.AddFile(result.FeaturedImg);

            // c. Utworzenie wpisu
            var articleModel = ArticleHelpers.ConvertToModel(result, user, medium);
            var article = await _articleService.Create(articleModel);
            if (article == false) { return RedirectToAction("Index", "Admin"); } // TODO: przekieruj na stronę z błędem

            // d. Wygenerowanie taxonomies
            await _taxonomyService.SaveCategories(await _categoryService.GetCategoriesByNames(result.Categories), articleModel);
            await _taxonomyService.SaveTags(await _tagService.GetCategoriesByNames(result.Tags), articleModel);

            return RedirectToAction("List");
        }

        // [ POST ] - <domain>/Article/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var article = await _articleService.Get(Id);
            await _cloudService.DeleteFile(article.ImageId);

            await _articleService.Delete(Id);

            // TODO: cascadowe usuwanie tagów i kategorii + zdjęcia refactoring

            return RedirectToAction("List");
        }

        // [ GET ] - <domain>/Article/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var article = await _articleService.Get(Id);
            return View(article);
        }
    }
}