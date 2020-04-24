using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Helpers;
using CMS.Models.ViewModels.Media;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class MediaController : Controller
    {
        // Wstrzykiwanie serwisu do obsługi platformy cloudinary w CMS'ie
        private readonly ICloudService _cloudinaryService;
        private readonly IMediaService _mediaService;

        public MediaController(ICloudService cloudinaryService, IMediaService mediaService)
        {
            _cloudinaryService = cloudinaryService;
            _mediaService = mediaService;
        }

        // [ GET ] - <domain>/Media/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var medias = await _mediaService.GetAll();

            ViewBag.MediasCount = await _mediaService.MediaCount();

            return View(medias);
        }

        // [ GET ] - <domain>/Media/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // [ POST ] - <domain>/Media/Add
        [HttpPost]
        public async Task<IActionResult> Add(List<IFormFile> files)
        {
            var check = await _cloudinaryService.AddMultipleFiles(files);
            return RedirectToAction("List","Media");
        }

        // [ GET ] - <domain>/Media/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var medium = await _mediaService.Get(id);
            return View(medium);
        }

        // [ GET ] - <domain>/Media/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var medium = await _mediaService.Get(id);
            return View(MediaHelpers.ConvertToView(medium));
        }

        // [ POST ] - <domain>/Media/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(MediaView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var medium = await _mediaService.Get(result.Id);

            await _mediaService.Update(MediaHelpers.MergeViewWithModel(medium, result));

            return RedirectToAction("Details", "Media", new { id = result.Id });
        }

        // [ POST ] - <domain>/Media/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            await _cloudinaryService.DeleteFile(Id);
            return RedirectToAction("List");
        }
    }
}
