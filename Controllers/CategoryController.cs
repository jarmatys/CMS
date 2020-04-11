using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class CategoryController : Controller
    {
        // [ GET ] - <domain>/Category/List
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        // [ POST ] - <domain>/Category/Add
        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }
    }
}