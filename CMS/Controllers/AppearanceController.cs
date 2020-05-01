using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class AppearanceController : Controller
    {
        private readonly IAppearanceService _appearanceService;
        private readonly ICloudService _cloudService;

        public AppearanceController(IAppearanceService appearanceService, ICloudService cloudService)
        {
            _appearanceService = appearanceService;
            _cloudService = cloudService;
        }

        // [ GET ] - <domain>/Appearance/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // [ GET ] - <domain>/Appearance/SetImages
        [HttpGet]
        public async Task<IActionResult> SetImages()
        {
            var options = await _appearanceService.GetOptions();
            return View(options);
        }

        // [ POST ] - <domain>/Appearance/SetLogo
        [HttpPost]
        public async Task<IActionResult> SetLogo(IFormFile logo)
        {
            if(logo != null)
            {
                // pobieramy opcje, aby sprawdzić czy logo zostało już wcześniej ustawione
                var options = await _appearanceService.GetOptions();
                var oldLogoId = "";
                if (options.Logo != null)
                {
                    // zapisujemy id starego logo
                    oldLogoId = options.Logo.Id;
                }

                // Zapisujemy nowy logotyp
                var medium = await _cloudService.AddFile(logo);
                if (medium != null)
                {
                    await _appearanceService.SaveLogo(medium);
                }

                // usuwamy stare logo i jego wpis w bazie danych
                if (!string.IsNullOrWhiteSpace(oldLogoId))
                {
                    await _cloudService.DeleteFile(oldLogoId);
                }

                // TODO: redirect na stronę z błędem
            }

            return RedirectToAction("SetImages", "Appearance");
        }

        // [ POST ] - <domain>/Appearance/SetLogo
        [HttpPost]
        public async Task<IActionResult> SetFavicon(IFormFile favicon)
        {
            if(favicon != null)
            {
                // pobieramy opcje, aby sprawdzić czy favicon zostało już wcześniej ustawione
                var options = await _appearanceService.GetOptions();
                var oldFaviconId = "";
                if (options.Favicon != null)
                {
                    // zapisujemy id starego favicona
                    oldFaviconId = options.Favicon.Id;
                }

                // Zapisujemy nowy logotyp
                var medium = await _cloudService.AddFile(favicon);
                if (medium != null)
                {
                    await _appearanceService.SaveFavicon(medium);
                }

                // usuwamy stare favicon i jego wpis w bazie danych
                if (!string.IsNullOrWhiteSpace(oldFaviconId))
                {
                    await _cloudService.DeleteFile(oldFaviconId);
                }

                // TODO: redirect na stronę z błędem
            }

            return RedirectToAction("SetImages", "Appearance");
        }
    }
}