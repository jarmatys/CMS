using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Models.Others;
using CMS.Models.ViewModels.Admin;
using CMS.Models.ViewModels.Home;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IHomeService _homeService;
        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;
        private readonly IPageService _pageService;

        public HomeController(ISettingsService settingsService, IHomeService homeService, IEmailService emailService, INotificationService notoficationService, IPageService pageService)
        {
            _settingsService = settingsService;
            _homeService = homeService;
            _emailService = emailService;
            _notificationService = notoficationService;
            _pageService = pageService;
        }

        // [ GET ] - <domain>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();
            return View();
        }

        // [ POST ] - <domain>
        [HttpPost]
        public async Task<IActionResult> Index(ContactView result)
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var notification = new NotificationData($"Masz jedną wiadomość z formularza od: {result.Name}");
            _notificationService.Send(notification);
            _emailService.SendContactForm(result);

            return RedirectToAction("ContactConfirmation");
        }

        // [ GET ] - <domain>/{link}
        [HttpGet("{slug}")]
        public async Task<IActionResult> Index(string slug)
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

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

            return RedirectToAction("PageNotFound", "Error");
        }

        // [ GET ] - <domain>/strona/{slug}
        [HttpGet("strona/{slug}")]
        [Route("strona/{slug}")]
        public async Task<IActionResult> Page(string slug)
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            var page = await _pageService.GetPageBySlug(slug);
            if(page == null || (page.IsDraft == true && !User.Identity.IsAuthenticated))
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            return View(page);
        }

        // [ GET ] - <domain>/polityka-prywatnosci
        [HttpGet]
        [Route("polityka-prywatnosci")]
        public async Task<IActionResult> PrivacyPolicy()
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();
            var privacyPolicy = await _settingsService.GetPrivacyPolicySettings();
            return View(privacyPolicy);
        }

        // [ GET ] - <domain>/potwierdzenie-kontaktu
        [HttpGet]
        [Route("potwierdzenie-kontaktu")]
        public async Task<IActionResult> ContactConfirmation()
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            return View();
        }


    }
}