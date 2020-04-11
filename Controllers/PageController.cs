using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class PageController : Controller
    {
        // [ GET ] - <domain>/Article/List
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        // [ GET ] - <domain>/Article/Add
        public IActionResult Add()
        {
            return View();
        }
    }
}