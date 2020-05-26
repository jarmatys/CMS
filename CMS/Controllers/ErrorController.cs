using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    // controller do obsługi kodów błedu i wyświetlanie customowych widoków
    public class ErrorController : Controller
    {
        // [ GET ] - <domain>/error/404
        [HttpGet]
        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        // [ GET ] - <domain>/error/500
        [HttpGet]
        [Route("error/500")]
        public IActionResult Error500()
        {
            return View();
        }

        // [ GET ] - <domain>/blad
        [HttpGet]
        [Route("blad")]
        public IActionResult PageBadRequest()
        {
            return View();
        }
    }
}