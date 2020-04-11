using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class MediaController : Controller
    {
        // [ GET ] - <domain>/Media/List
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        // [ GET ] - <domain>/Media/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}