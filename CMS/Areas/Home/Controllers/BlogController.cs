using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Areas.Admin.Models.Others;
using CMS.Areas.Admin.Models.View.Article;
using CMS.Infrastructure.Helpers;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.Home.Controllers
{
    [Area("home")]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IHomeService _homeService;
        private readonly ISettingsService _settingsService;
        private readonly ICommentService _commentService;
        private readonly INotificationService _notificationService;
        private readonly IEmailService _emailService;
        private readonly ICategoryService _categoryService;

        public BlogController(IArticleService articleService, IHomeService homeService, ISettingsService settingsService, ICommentService commentService, INotificationService notificationService, IEmailService emailService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _homeService = homeService;
            _settingsService = settingsService;
            _commentService = commentService;
            _notificationService = notificationService;
            _emailService = emailService;
            _categoryService = categoryService;
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
            ViewBag.MaxPage = maxPax;

            return View(articles);
        }

        // [ GET ] - <domain>/blog/wpis/{slug}
        [HttpGet("blog/wpis/{slug}")]
        [Route("blog/wpis/{slug}")]
        public async Task<IActionResult> Details(string slug, string status)
        {
            var article = await _articleService.GetArticleBySlug(slug);

            if (article == null)
            {
                return NotFound();
            }

            ViewData["Article"] = article;

            // liczenie wyświetleń wpisu
            if (Request.Cookies[$"article_view_{article.Id}"] != "false")
            {
                Response.Cookies.Append($"article_view_{article.Id}", "false", new CookieOptions() { Expires = DateTime.Now.AddHours(1) });
                await _articleService.IncrementArticleViews(article.Id);
            }

            return View();
        }

        // [ GET ] - <domain>/blog/kategoria/{category}
        [HttpGet("blog/kategoria/{category}")]
        [Route("blog/kategoria/{category}")]
        public IActionResult Category(string category)
        {
            return RedirectToAction("Category", new { category = category, page = 1 });
        }

        // [ GET ] - <domain>/blog/kategoria/{category}
        [HttpGet("blog/kategoria/{category}/{page:int}")]
        [Route("blog/kategoria/{category}/{page:int}")]
        public async Task<IActionResult> Category(string category, int page)
        {
            // pobieranie informacji o kategorii i sprawdzanie czy taka kategoria istnieje
            var categoryModel = await _categoryService.GetCategoryByName(category);
            if (categoryModel == null)
            {
                return NotFound();
            }

            ViewBag.CategoryName = categoryModel.Name;
            ViewBag.CategoryDesc = categoryModel.Description;

            var blogSettings = await _settingsService.GetBlogSettings();
            var maxPax = ((await _articleService.ArticleCount()) / blogSettings.PostPerPage) + 1;

            // sprawdzamy aby użytkownik nie przekręcił "licznika" paginacji
            if (page < 1 || page > maxPax)
            {
                page = 1;
            }

            var skip = (page - 1) * blogSettings.PostPerPage;
            var articles = await _articleService.GetRangeOfArticleCategory(skip, blogSettings.PostPerPage, category);

            ViewBag.CurrentPage = page;
            ViewBag.MaxPage = maxPax;

            return View(articles);
        }

        // [ POST ] - <domain>/Blog/AddComment
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentView result)
        {
            if (!ModelState.IsValid)
            {
                // wysyłamy informacje o błędach
                return BadRequest(ModelState);
            }

            var settings = await _settingsService.GetBlogSettings();

            var article = await _articleService.Get(result.ArticleId);

            var comment = await _commentService.Create(CommentHelpers.ConvertToModel(result, article));

            if (comment)
            {
                var notification = new NotificationData($"Wpadł Ci nowy komentarz od {result.Name} | {result.Email}");
                _notificationService.Send(notification);

                if (settings.CommentsNotify)
                {
                    _emailService.SendCommentConfirmation(result);
                }

                return Ok(new { status = "Komentarz zapisany pomyślnie" });
            }
            else
            {
                return BadRequest(new { status = "Problem z zapisem komentarza" });
            }
        }
    }
}