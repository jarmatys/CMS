using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Areas.Admin.Models.Others;
using CMS.Areas.Admin.Models.View.Home;
using CMS.Areas.Home.Models;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.Home.Controllers
{
    [Area("home")]
    public class HomeController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;
        private readonly IHomeService _homeService;
        private readonly IPageService _pageService;
        private readonly INewsletterService _newsletterService;

        public HomeController(ISettingsService settingsService, IHomeService homeService, IEmailService emailService, INotificationService notoficationService, IPageService pageService, INewsletterService newsletterService)
        {
            _settingsService = settingsService;
            _emailService = emailService;
            _notificationService = notoficationService;
            _pageService = pageService;
            _homeService = homeService;
            _newsletterService = newsletterService;
        }

        // [ GET ] - <domain>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // [ POST ] - <domain>
        [HttpPost]
        public IActionResult SendMessage([FromBody] ContactView result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notification = new NotificationData($"Masz jedną wiadomość z formularza od: {result.Name}");
            _notificationService.Send(notification);
            var isSend = _emailService.SendContactForm(result);

            if (isSend)
            {
                return Ok(new { status = "Wiadomość została wysłana poprawnie, odpowiem najszybciej jak to tylko możliwe! :)" });
            }

            return BadRequest(new { status = "Bład przy wysyłaniu wiadomości, odśwież stronę i spróbuj ponownie." });
        }


        // [ POST ] - <domain>
        [HttpPost]
        public async Task<IActionResult> SendNewsletter([FromBody] NewsletterData result)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notification = new NotificationData($"Masz nowy zapis do newslettera: {result.Email}");
            _notificationService.Send(notification);

            var isSave = await _newsletterService.SaveUser(result);

            if (isSave)
            {
                return Ok(new { status = "Poprawnie zapisałeś się do newslettera! :)" });
            }

            return BadRequest(new { status = "Bład przy zapisywaniu do newslettera." });
        }

        // [ GET ] - <domain>/{link}
        [HttpGet("{slug}")]
        public async Task<IActionResult> Index(string slug)
        {
            var newUrl = await _homeService.CheckRedirect(slug);
            var page = await _homeService.CheckPageRedirect(slug);

            if (page != null)
            {
                return RedirectToAction("Page", page.Slug);
            }

            if (!string.IsNullOrEmpty(newUrl))
            {
                return RedirectPermanent(newUrl);
            }

            return NotFound();
        }

        // [ GET ] - <domain>/strona/{slug}
        [HttpGet("strona/{slug}")]
        [Route("strona/{slug}")]
        public async Task<IActionResult> Page(string slug)
        {
            var page = await _pageService.GetPageBySlug(slug);
            if (page == null || (page.IsDraft == true && !User.Identity.IsAuthenticated))
            {
                return NotFound();
            }

            return View(page);
        }

        // [ GET ] - <domain>/polityka-prywatnosci
        [HttpGet]
        [Route("polityka-prywatnosci")]
        public async Task<IActionResult> PrivacyPolicy()
        {
            var privacyPolicy = await _settingsService.GetPrivacyPolicySettings();
            return View(privacyPolicy);
        }
    }
}