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

        public HomeController(ISettingsService settingsService, IHomeService homeService, IEmailService emailService, INotificationService notoficationService)
        {
            _settingsService = settingsService;
            _homeService = homeService;
            _emailService = emailService;
            _notificationService = notoficationService;
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
        [HttpGet("{link}")]
        public async Task<IActionResult> Index(string link)
        {
            var newUrl = await _homeService.CheckRedirect(link);

            if (!string.IsNullOrEmpty(newUrl))
            {
                return RedirectPermanent(newUrl);
            }

            ViewData["HomeData"] = await _homeService.GetHomeProperties();
            return RedirectToAction("PageNotFound", "Error");
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