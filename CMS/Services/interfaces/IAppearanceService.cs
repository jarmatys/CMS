using CMS.Models.Db.Admin;
using CMS.Models.Db.Media;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IAppearanceService
    {
        Task<bool> SaveLogo(MediaModel logo);
        Task<bool> SaveFavicon(MediaModel favicon);
        Task<OptionsModel> GetOptions();
    }
}
