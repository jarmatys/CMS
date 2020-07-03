using CMS.Areas.Admin.Models.Email;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace CMS.Services
{
    public class PdfService : IPdfService
    {
        private readonly IGeneratePdf _generatePdf;
        public PdfService(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }

        public async Task<FileStreamResult> CreateAnalyticsRaport(string viewName, string fileName, AnalyticsView data)
        {
            var stream = await _generatePdf.GetByteArray($"~/Areas/Admin/Views/Email/{viewName}.cshtml", data);

            var pdfStream = new MemoryStream();
            pdfStream.Write(stream, 0, stream.Length);
            pdfStream.Position = 0;

            var file = new FileStreamResult(pdfStream, "application/pdf");
            file.FileDownloadName = $"{fileName}.pdf";

            return file;
        }
    }
}
