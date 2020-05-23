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


        // [ GET ] - <domain>/Seo/General
        [HttpGet]
        public async Task<IActionResult> General()
        {
            var generalSettings = await _seoService.GetSeoSettings();
            return View(SeoHelpers.ConvertToViewGeneralSettings(generalSettings));
        }

        // [ POST ] - <domain>/Seo/General
        [HttpPost]
        public async Task<IActionResult> General(GeneralSeoSettingsView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var generalSettings = await _seoService.GetSeoSettingsById(result.Id);
            await _seoService.SetSeoSettings(SeoHelpers.MergeViewWithModelGeneralSettings(generalSettings, result));

            return RedirectToAction("General", "Seo");
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

            await _seoService.CreateSocialMedia(SeoHelpers.ConvertToModelSocialMedia(result));

            return RedirectToAction("SocialMediaList", "Seo");
        }

        // [ GET ] - <domain>/Seo/SocialMediaEdit
        [HttpGet]
        public async Task<IActionResult> SocialMediaEdit(int Id)
        {
            var socialMedia = await _seoService.GetSocialMedia(Id);
            return View(SeoHelpers.ConvertToViewSocialMedia(socialMedia));
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
            await _seoService.UpdateSocialMedia(SeoHelpers.MergeViewWithModelSocialMedia(socialMedia, result)); 

            return RedirectToAction("SocialMediaList", "Seo");
        }

        // [ POST ] - <domain>/Seo/SocialMediaDelete
        [HttpPost]
        public async Task<IActionResult> SocialMediaDelete(int Id)
        {
            await _seoService.DeleteSocialMedia(Id);
            return RedirectToAction("SocialMediaList", "Seo");
        }



        // [ GET ] - <domain>/Seo/MetaTagsList
        [HttpGet]
        public async Task<IActionResult> MetaTagsList()
        {
            var metaTags = await _seoService.GetAllMetaTags();
            return View(metaTags);
        }

        // [ GET ] - <domain>/Seo/MetaTagsAdd
        [HttpGet]
        public IActionResult MetaTagsAdd()
        {
            ViewBag.MetaTagsName = _seoService.GetMetaTagsName();
            return View();
        }

        // [ POST ] - <domain>/Seo/MetaTagsAdd
        [HttpPost]
        public async Task<IActionResult> MetaTagsAdd(MetaTagView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            await _seoService.CreateMetaTag(SeoHelpers.ConvertToModelMetaTag(result));

            return RedirectToAction("MetaTagsList", "Seo");
        }

        // [ GET ] - <domain>/Seo/MetaTagsEdit
        [HttpGet]
        public async Task<IActionResult> MetaTagsEdit(int Id)
        {
            var metaTag = await _seoService.GetMetaTag(Id);
            return View(SeoHelpers.ConvertToViewMetaTag(metaTag));
        }

        // [ POST ] - <domain>/SeoMetaTagsEdit
        [HttpPost]
        public async Task<IActionResult> MetaTagsEdit(MetaTagView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var metaTag = await _seoService.GetMetaTag(result.Id);
            await _seoService.UpdateMetaTag(SeoHelpers.MergeViewWithModelMetaTag(metaTag, result));

            return RedirectToAction("MetaTagsList", "Seo");
        }

        // [ POST ] - <domain>/Seo/MetaTagsDelete
        [HttpPost]
        public async Task<IActionResult> MetaTagsDelete(int Id)
        {
            await _seoService.DeleteMetaTag(Id);
            return RedirectToAction("MetaTagsList", "Seo");
        }



        // [ GET ] - <domain>/Seo/RetrievalLinksList
        [HttpGet]
        public async Task<IActionResult> RetrievalLinksList()
        {
            var retrievalLinks = await _seoService.GetAllRetrievalLinks();
            return View(retrievalLinks);
        }

        // [ GET ] - <domain>/Seo/RetrievalLinksAdd
        [HttpGet]
        public IActionResult RetrievalLinksAdd()
        {
            return View();
        }

        // [ POST ] - <domain>/Seo/MetaTagsAdd
        [HttpPost]
        public async Task<IActionResult> RetrievalLinksAdd(RetrievalLinksView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            await _seoService.CreateRetrievalLink(SeoHelpers.ConvertToModelRetrievalLink(result));

            return RedirectToAction("RetrievalLinksList", "Seo");
        }


        // [ GET ] - <domain>/Seo/RetrievalLinksEdit
        [HttpGet]
        public async Task<IActionResult> RetrievalLinksEdit(int Id)
        {
            var retrievalLink = await _seoService.GetRetrievalLink(Id);
            return View(SeoHelpers.ConvertToViewRetrievalLink(retrievalLink));
        }

        // [ POST ] - <domain>/Seo/RetrievalLinksEdit
        [HttpPost]
        public async Task<IActionResult> RetrievalLinksEdit(RetrievalLinksView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var retrievalLink = await _seoService.GetRetrievalLink(result.Id);
            await _seoService.UpdateRetrievalLink(SeoHelpers.MergeViewWithModelRetrievalLink(retrievalLink, result));

            return RedirectToAction("RetrievalLinksList", "Seo");
        }

        // [ POST ] - <domain>/Seo/RetrievalLinksDelete
        [HttpPost]
        public async Task<IActionResult> RetrievalLinksDelete(int Id)
        {
            await _seoService.DeleteRetrievalLink(Id);
            return RedirectToAction("RetrievalLinksList", "Seo");
        }


    }
}