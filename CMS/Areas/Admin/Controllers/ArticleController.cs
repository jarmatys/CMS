using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Areas.Admin.Models.Db.Account;
using CMS.Areas.Admin.Models.View.Article;
using CMS.Infrastructure.Helpers;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin/{controller}/{action=List}/{id?}")]
    public class ArticleController : Controller
    {
        // Wstrzykiwanie serwisu do obsługi kategorii w CMS'ie
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly ICloudService _cloudService;
        private readonly ITaxonomyService _taxonomyService;
        private readonly ISeoService _seoService;
        private readonly UserManager<User> _userManager;

        public ArticleController(ISeoService seoService, IArticleService articleService, ICategoryService categoryService, ITagService tagService, ICloudService cloudService, ITaxonomyService taxonomyService, UserManager<User> userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _tagService = tagService;
            _cloudService = cloudService;
            _taxonomyService = taxonomyService;
            _userManager = userManager;
            _seoService = seoService;
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
            if(await _articleService.CheckIfSlugExist(result.Slug))
            {
                ModelState.AddModelError("", "Wpis o podanym linku istnieje");
            }

            if (!ModelState.IsValid)
            {
                // 1. Pobieranie listy tagów oraz kategorii
                ViewBag.Categories = await _categoryService.GetAll();
                ViewBag.Tags = await _tagService.GetAll();

                return View(result);
            }

            // 2.Poprawnie zwalidowane post zapisuję do bazy danych

            // a. Pobranie dodatkowych informacji do artykułu | usera, url strony
            var user = await _userManager.GetUserAsync(User);
            var seoSettings = await _seoService.GetSeoSettings();

            // b. Utworzenie wpisu
            var articleModel = ArticleHelpers.ConvertToModel(result, user, seoSettings.MainUrl);
            var article = await _articleService.Create(articleModel);
            if(article == false) { return RedirectToAction("Index", "Admin"); } // TODO: przekieruj na stronę z błędem

            // c. Zapis zdjęcia
            var medium = await _cloudService.AddFile(result.FeaturedImg, articleModel);

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

            // Usuwamy zdjęcie przypisane do artykułu
            if (article.Image != null)
            {
                _cloudService.DeleteFile(article.Image.Id);
            }

            // Usuwamy taxonomies artykułu
            if(article.Taxonomies.Count != 0)
            {
                await _taxonomyService.Delete(Id);
            }

            // Usuwamy artykuł
            await _articleService.Delete(Id);

            return RedirectToAction("List");
        }

        // [ GET ] - <domain>/Article/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            // 1. Pobieranie listy tagów oraz kategorii
            ViewBag.Categories = await _categoryService.GetAll();
            ViewBag.Tags = await _tagService.GetAll();

            var articleModel = await _articleService.Get(Id);

            // 2. Sprawdzanie czy artykuł należy do użytkownika
            if (articleModel.User.UserName != User.Identity.Name)
            {
                return RedirectToAction("List", "Article");
            }

            var articleView = ArticleHelpers.ConvertToView(articleModel);

            return View(articleView);
        }

        // [ GET ] - <domain>/Article/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(ArticleView result)
        {
            var article = await _articleService.Get(result.Id);

            // sprawdzamy dopiero jeżeli tytuł się 
            if(result.Slug != article.Slug)
            {
                // sprawdzic czy sam sobą nie jest czasem
                if (await _articleService.CheckIfSlugExist(result.Slug))
                {
                    ModelState.AddModelError("", "Wpis o podanym linku istnieje");
                }
            }      

            if (!ModelState.IsValid)
            {
                // 1. Pobieranie listy tagów oraz kategorii
                ViewBag.Categories = await _categoryService.GetAll();
                ViewBag.Tags = await _tagService.GetAll();

                return View(result);
            }  

            // 2. Poprawnie zwalidowane post zapisuję do bazy danych

            // a. Jeżeli nastąpiła zamiana zdjęcia do zapisujemy
            if (result.IsPhotoEdited)
            {
                // Usuwanie starego zdjęcia tylko pod warunkiem jeżeli istnieje
                if (article.Image != null)
                {
                    // usuwanie starego zdjęcia
                    _cloudService.DeleteFile(article.Image.Id);
                }

                // Jeżeli zostało wgrane nowe zdjęcie to je zapisz i przypisz
                if (result.FeaturedImg != null)
                {
                    var medium = await _cloudService.AddFile(result.FeaturedImg);
                    article.Image = medium;
                }
                
            }

            // b. Aktualizacja wpisu
            var seoSettings = await _seoService.GetSeoSettings();
            await _articleService.Update(ArticleHelpers.MergeViewWithModel(article, result, seoSettings.MainUrl));

            // c. Aktualizacja taxonomies
            await _taxonomyService.Delete(result.Id);

            await _taxonomyService.SaveCategories(await _categoryService.GetCategoriesByNames(result.Categories), article);
            await _taxonomyService.SaveTags(await _tagService.GetCategoriesByNames(result.Tags), article);

            return RedirectToAction("List");
        }
    }
}