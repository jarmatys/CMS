using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Helpers;
using CMS.Models.ViewModels.Seo;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class SeoController : Controller
    {
        private readonly ISeoService _seoService;
        public SeoController(ISeoService seoService)
        {
            _seoService = seoService;
        }

        // [ GET ] - <domain>/Seo/SocialMedia
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var socialMedias = await _seoService.GetAllSocialMedias();
            return View(socialMedias);
        }

        // [ GET ] - <domain>/Seo/SocialMediaAdd
        [HttpGet]
        public IActionResult SocialMediaAdd()
        {
            ViewBag.SocialMediaName = _seoService.GetSocialMediaName();
            return View();
        }

        // [ POST ] - <domain>/Seo/SocialMediaAdd
        [HttpPost]
        public async Task<IActionResult> SocialMediaAdd(SocialMediaView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            await _seoService.CreateSocialMedia(SeoHelpers.ConvertToModel(result));

            return RedirectToAction("SocialMediaList", "Seo");
        }

        // [ GET ] - <domain>/Seo/SocialMediaEdit
        [HttpGet]
        public async Task<IActionResult> SocialMediaEdit(int Id)
        {
            var socialMedia = await _seoService.GetSocialMedia(Id);
            return View(SeoHelpers.ConvertToView(socialMedia));
        }

        // [ POST ] - <domain>/Seo/SocialMediaEdit
        [HttpPost]
        public async Task<IActionResult> SocialMediaEdit(SocialMediaView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var socialMedia = await _seoService.GetSocialMedia(result.Id);
            await _seoService.UpdateSocialMedia(SeoHelpers.MergeViewWithModel(socialMedia, result)); 

            return RedirectToAction("SocialMediaList", "Seo");
        }

        // [ POST ] - <domain>/Seo/SocialMediaDelete
        [HttpPost]
        public async Task<IActionResult> SocialMediaDelete(int Id)
        {
            await _seoService.DeleteSocialMedia(Id);
            return RedirectToAction("SocialMediaList", "Seo");
        }

        // [ GET ] - <domain>/Seo/Meta
        [HttpGet]
        public IActionResult Meta()
        {
            return View();
        }

        // [ GET ] - <domain>/Seo/RetrievalLinks
        [HttpGet]
        public IActionResult RetrievalLinks()
        {
            return View();
        }
    }
}