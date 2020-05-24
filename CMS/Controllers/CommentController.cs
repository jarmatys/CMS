using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Helpers;
using CMS.Models.ViewModels.Article;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // [ GET ] - <domain>/Comment/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.CommentCount = await _commentService.Count();

            var comments = await _commentService.GetAll();

            return View(comments);
        }

        // [ GET ] - <domain>/Comment/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var category = await _commentService.Get(Id);
            return View(CommentHelpers.ConvertToView(category));
        }

        // [ POST ] - <domain>/Comment/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(CommentView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var comment = await _commentService.Get(result.Id);

            await _commentService.Update(CommentHelpers.MergeViewWithModel(comment, result));

            return RedirectToAction("List");
        }

        // [ POST ] - <domain>/Comment/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            await _commentService.Delete(Id);
            return RedirectToAction("List", "Comment");
        }

        // [ GET ] - <domain>/Comment/Accept
        [HttpGet]
        public async Task<IActionResult> Accept(int Id)
        {
            await _commentService.Accept(Id);
            return RedirectToAction("List", "Comment");
        }

        // [ GET ] - <domain>/Comment/Accept
        [HttpGet]
        public async Task<IActionResult> Reject(int Id)
        {
            await _commentService.Reject(Id);
            return RedirectToAction("List", "Comment");
        }

    }
}