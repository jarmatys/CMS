﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Models.ViewModels.Admin;
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

        // [ GET ] - <domain>/Admin/Help
        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }

        // [ GET ] - <domain>/Admin/License
        [HttpGet]
        public IActionResult License()
        {
            return View();
        }

        // [ POST ] - <domain>/Admin/SendNotification
        [HttpPost]
        public IActionResult SendNotification(NotificationView message)
        {
            return View();
        }
    }
}