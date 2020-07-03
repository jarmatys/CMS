using CMS.Areas.Admin.Models.Pdf;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IPdfService
    {
       Task<FileStreamResult> CreateAnalyticsRaport(string viewName, string fileName, AnalyticsView data);
    }
}
