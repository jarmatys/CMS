using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IHomeService _homeService;
        public ErrorController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        // [ GET ] - <domain>/nie-odnaleziono
        [HttpGet]
        [Route("nie-odnaleziono")]
        public async Task<IActionResult> PageNotFound()
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            return View();
        }

        // [ GET ] - <domain>/blad
        [HttpGet]
        [Route("blad")]
        public async Task<IActionResult> PageBadRequest()
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            return View();
        }
    }
}