using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Areas.Admin.Models.Db.Account;
using CMS.Areas.Admin.Models.Others;
using CMS.Areas.Admin.Models.View.Home;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin/{action=Index}/{id?}")]
    public class HomeController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<User> _userManager;

        public HomeController(INotificationService notificationService, UserManager<User> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        // [ GET ] - <domain>/Admin/Home/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // [ GET ] - <domain>/Admin/Home/Faq
        [HttpGet]
        public IActionResult Faq()
        {
            return View();
        }

        // [ GET ] - <domain>/Admin/Home/Help
        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }

        // [ GET ] - <domain>/Admin/Home/License
        [HttpGet]
        public IActionResult License()
        {
            return View();
        }

        // [ POST ] - <domain>/Admin/Home/SendNotification
        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationView message)
        {
            // wysyłamy na slacka pełne imię i nazwisko użytkownika
            var userName = "";
            var userInfo = await _userManager.FindByNameAsync(message.Client);
            if (!string.IsNullOrEmpty(userInfo.Name) && !string.IsNullOrEmpty(userInfo.Surname))
            {
                userName = $"{userInfo.Name} {userInfo.Surname}";
            }
            else
            {
                userName = message.Client;
            }

            var notification = new NotificationData($"---------------\nKlient: {userName}\nMetoda: {message.ActionName}\n\nTreść zgłoszenia: {message.Message}");
            _notificationService.Send(notification);

            return Ok();
        }
    }
}