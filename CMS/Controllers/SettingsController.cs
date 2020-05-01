using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Helpers;
using CMS.Models.ViewModels.Settings;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // [ GET ] - <domain>/Settings/Email
        [HttpGet]
        public async Task<IActionResult> Email()
        {
            var emailSettings = await _settingsService.GetEmailSettings();
            return View(SettingsHelpers.ConvertToView(emailSettings));
        }

        // [ POST ] - <domain>/Settings/Email
        [HttpPost]
        public async Task<IActionResult> Email(EmailView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var emailSettings = await _settingsService.GetEmailSettingsById(result.Id);

            await _settingsService.SetEmailSettings(SettingsHelpers.MergeViewWithModel(emailSettings,result));

            return RedirectToAction("Email","Settings");
        }
    }
}