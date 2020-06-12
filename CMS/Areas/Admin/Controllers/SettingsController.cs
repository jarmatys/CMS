using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Areas.Admin.Models.View.Settings;
using CMS.Infrastructure.Helpers;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin/{controller}/{action=Index}/{id?}")]
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

        // [ GET ] - <domain>/Settings/Integration
        [HttpGet]
        public async Task<IActionResult> Integration()
        {
            var integration = await _settingsService.GetIntegrationSettings();
            return View(SettingsHelpers.ConvertToViewIntegration(integration));
        }

        // [ POST ] - <domain>/Settings/Integration
        [HttpPost]
        public async Task<IActionResult> Integration(IntegrationView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var integrationSettings = await _settingsService.GetIntegrationSettingsById(result.Id);
            await _settingsService.SetIntegrationSettings(SettingsHelpers.MergeViewWithModelIntegration(integrationSettings, result));

            return RedirectToAction("Integration", "Settings");
        }

        // [ GET ] - <domain>/Settings/Blog
        [HttpGet]
        public async Task<IActionResult> Blog()
        {
            var blogSettings = await _settingsService.GetBlogSettings();
            return View(SettingsHelpers.ConvertToViewBlog(blogSettings));
        }

        // [ POST ] - <domain>/Settings/Integration
        [HttpPost]
        public async Task<IActionResult> Blog(BlogView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var blogSettings = await _settingsService.GetBlogSettingsById(result.Id);
            await _settingsService.SetBlogSettings(SettingsHelpers.MergeViewWithModelBlog(blogSettings, result));

            return RedirectToAction("Blog", "Settings");
        }
    }
}