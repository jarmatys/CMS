using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // [ GET ] - <domain>/Admin/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // [ GET ] - <domain>/Admin/Faq
        [HttpGet]
        public IActionResult Faq()
        {
            return View();
        }

    }
}