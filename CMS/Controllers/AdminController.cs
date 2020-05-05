using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Models.Others;
using CMS.Models.ViewModels.Admin;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly INotificationService _notificationService;
        public AdminController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

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
        public IActionResult SendNotification([FromBody] NotificationView message)
        {
            var notofication = new NotificationData($"---------------\nKlient: {message.Client}\nMetoda: {message.ActionName}\n\nTreść zgłoszenia: {message.Message}");
            _notificationService.Send(notofication);

            return Ok();
        }
    }
}