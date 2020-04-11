using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class TagController : Controller
    {
        // [ GET ] - <domain>/Tag/List
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        // [ POST ] - <domain>/Tag/Add
        [HttpPost]
        public IActionResult Add()
        {
            return RedirectToAction("List");
        }
    }
}