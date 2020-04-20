using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class MediaController : Controller
    {
        // Wstrzykiwanie serwisu do obsługi kategorii w CMS'ie
        private readonly IPhotoService _mediaService;
        public MediaController(IPhotoService mediaService)
        {
            _mediaService = mediaService;
        }

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