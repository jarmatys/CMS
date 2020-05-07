using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IHomeService _homeService;
        private readonly ISettingsService _settingsService;

        public BlogController(IArticleService articleService, IHomeService homeService, ISettingsService settingsService)
        {
            _articleService = articleService;
            _homeService = homeService;
            _settingsService = settingsService;
        }

        // [ GET ] - <domain>/blog/
        [HttpGet("blog")]
        [Route("blog")]
        public IActionResult List()
        {
            return RedirectToAction("List", new { page = 1 });
        }

        // [ GET ] - <domain>/blog/{page}
        [HttpGet("blog/{page:int}")]
        [Route("blog/{page:int}")]
        public async Task<IActionResult> List(int page)
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            var blogSettings = await _settingsService.GetBlogSettings();
            var maxPax = ((await _articleService.ArticleCount()) / blogSettings.PostPerPage) + 1;

            // sprawdzamy aby użytkownik nie przekręcił "licznika" paginacji
            if (page < 1 || page > maxPax)
            {
                page = 1;
            }

            var skip = (page - 1) * blogSettings.PostPerPage;
            var articles = await _articleService.GetRangeOfArticle(skip, blogSettings.PostPerPage);

            ViewBag.CurrentPage = page;
            ViewBag.MaxPage = ((await _articleService.ArticleCount()) / blogSettings.PostPerPage) + 1;

            return View(articles);
        }

        // [ GET ] - <domain>/blog/{slug}
        [HttpGet("blog/wpis/{slug}")]
        [Route("blog/wpis/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            var article = await _articleService.GetArticleBySlug(slug);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }
    }
}