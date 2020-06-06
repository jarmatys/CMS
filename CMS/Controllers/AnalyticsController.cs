using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Models.Email;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace CMS.Controllers
{
    [Authorize]
    public class AnalyticsController : Controller
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly IPdfService _pdfService;

        public AnalyticsController(IAnalyticsService analyticsService, IPdfService pdfService)
        {
            _analyticsService = analyticsService;
            _pdfService = pdfService;
        }

        // [ GET ] - <domain>/Appearance/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // [ GET ] - <domain>/Appearance/GenerateRaport
        [HttpGet]
        public async Task<IActionResult> GenerateRaport()
        {
            var data = new AnalyticsView();
            data.Views = $"{await _analyticsService.GetSumArticleViews()}";

            var result = _pdfService.CreateAnalyticsRaport("AnalyticsTemplate", "Raport wyświetleń", data);

            return result;
        }
    }
}