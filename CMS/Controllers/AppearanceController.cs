using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class AppearanceController : Controller
    {
        private readonly ICloudService _cloudService;

        public AppearanceController(ICloudService cloudService)
        {
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
            return View();
        }

        // [ GET ] - <domain>/Appearance/SetTypography
        [HttpGet]
        public async Task<IActionResult> SetTypography()
        {
            return View();
        }

        // [ GET ] - <domain>/Appearance/SetColors
        [HttpGet]
        public async Task<IActionResult> SetColors()
        {
            return View();
        }

        // [ POST ] - <domain>/Appearance/SetLogo
        [HttpPost]
        public async Task<IActionResult> SetLogo(IFormFile logo)
        {
            return RedirectToAction("SetImages", "Appearance");
        }

        // [ POST ] - <domain>/Appearance/SetLogo
        [HttpPost]
        public async Task<IActionResult> SetFavicon(IFormFile favicon)
        {
            return RedirectToAction("SetImages", "Appearance");
        }
    }
}