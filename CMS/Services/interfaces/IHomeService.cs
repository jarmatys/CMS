using CMS.Areas.Admin.Models.Db.Page;
using CMS.Areas.Home.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IHomeService
    {
        Task<HomeView> GetHomeProperties();
        Task<string> CheckRedirect(string link);
        Task<PageModel> CheckPageRedirect(string link);
    }
}
