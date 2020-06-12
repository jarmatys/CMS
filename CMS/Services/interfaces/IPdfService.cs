using CMS.Areas.Admin.Models.Email;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IPdfService
    {
        ViewAsPdf CreateAnalyticsRaport(string viewName, string fileName, AnalyticsView data);
    }
}
