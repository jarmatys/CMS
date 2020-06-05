using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Models.Db.Account;
using CMS.Models.Others;
using CMS.Models.ViewModels.Admin;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<User> _userManager;

        public AdminController(INotificationService notificationService, UserManager<User> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
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
        public async Task<IActionResult> SendNotification([FromBody] NotificationView message)
        {
            // wysyłamy na slacka pełne imię i nazwisko użytkownika
            var userName = "";
            var userInfo = await _userManager.FindByNameAsync(message.Client);
            if(!string.IsNullOrEmpty(userInfo.Name) && !string.IsNullOrEmpty(userInfo.Surname))
            {
                userName = $"{userInfo.Name} {userInfo.Surname}";
            }
            else
            {
                userName = message.Client;
            }

            var notofication = new NotificationData($"---------------\nKlient: {userName}\nMetoda: {message.ActionName}\n\nTreść zgłoszenia: {message.Message}");
            _notificationService.Send(notofication);

            return Ok();
        }
    }
}