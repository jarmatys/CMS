using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingsService _settingsService;
        public HomeController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        // [ GET ] - <domain>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
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