using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IHomeService _homeService;

        public HomeController(ISettingsService settingsService, IHomeService homeService)
        {
            _settingsService = settingsService;
            _homeService = homeService;
        }

        // [ GET ] - <domain>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homeView = await _homeService.GetHomeProperties();
            return View(homeView);
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

            var homeView = await _homeService.GetHomeProperties();
            return View(homeView);
        }

        // [ GET ] - <domain>/polityka-prywatnosci
        [HttpGet]
        [Route("polityka-prywatnosci")]
        public async Task<IActionResult> PrivacyPolicy()
        {
            var homeView = await _homeService.GetHomeProperties();
            homeView.TempData = await _settingsService.GetPrivacyPolicySettings();
            return View(homeView);
        }

    }
}