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

        public BlogController(IArticleService articleService, IHomeService homeService)
        {
            _articleService = articleService;
            _homeService = homeService;
        }

        // [ GET ] - <domain>/blog
        [HttpGet]
        [Route("blog")]
        public async Task<IActionResult> List()
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            var articles = await _articleService.GetAll();

            return View(articles);
        }

        // [ GET ] - <domain>/blog/{slug}
        [HttpGet("blog/{slug}")]
        [Route("blog/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            var article = await _articleService.GetArticleBySlug(slug);
            
            if(article == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            return View(article);
        }
    }
}