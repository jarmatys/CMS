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
            return View(SettingsHelpers.ConvertToViewEmail(emailSettings));
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
            await _settingsService.SetEmailSettings(SettingsHelpers.MergeViewWithModelEmail(emailSettings,result));

            return RedirectToAction("Email","Settings");
        }

        // [ GET ] - <domain>/Settings/PrivacyPolicy
        [HttpGet]
        public async Task<IActionResult> PrivacyPolicy()
        {
            var privacySettings = await _settingsService.GetPrivacyPolicySettings();
            return View(SettingsHelpers.ConvertToViewPrivacePolicy(privacySettings));
        }

        // [ POST ] - <domain>/Settings/PrivacyPolicy
        [HttpPost]
        public async Task<IActionResult> PrivacyPolicy(PrivacyPolicyView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var policyPrivacySetting = await _settingsService.GetPrivacyPolicySettingsById(result.Id);
            await _settingsService.SetPrivacyPolicySettings(SettingsHelpers.MergeViewWithModelPrivacyPolicy(policyPrivacySetting, result));

            return RedirectToAction("PrivacyPolicy", "Settings");
        }

    }
}