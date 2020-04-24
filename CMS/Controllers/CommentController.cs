using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {

        // [ GET ] - <domain>/Comment/List
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

    }
}