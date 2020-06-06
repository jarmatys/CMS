using CMS.Models.Email;
using CMS.Services.interfaces;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class PdfService : IPdfService
    {
        public ViewAsPdf CreateAnalyticsRaport(string viewName, string fileName, AnalyticsView data)
        {
            var result = new ViewAsPdf($"~/Views/Email/{viewName}.cshtml", data);
            result.FileName = $"{fileName}.pdf";
            return result;
        }
    }
}
