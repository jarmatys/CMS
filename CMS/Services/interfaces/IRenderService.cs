using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IRenderService
    {
        Task<string> ToHtmlStringAsync(string viewName, object model);
    }
}
