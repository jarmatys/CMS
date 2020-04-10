using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class AdminController : Controller
    {
        // [ GET ] - <domain>/Admin/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}