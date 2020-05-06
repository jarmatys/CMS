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

        // [ GET ] - <domain>/404
        [HttpGet]
        [Route("nie-odnaleziono")]
        public async Task<IActionResult> PageNotFound()
        {
            ViewData["HomeData"] = await _homeService.GetHomeProperties();

            return View();
        }
    }
}