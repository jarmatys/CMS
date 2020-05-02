using CMS.Models.Db.Seo;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface ISeoService
    {
        Task<bool> CreateSocialMedia(SocialMediaModel socialMedia);
        Task<SocialMediaModel> GetSocialMedia(int id);
        Task<List<SocialMediaModel>> GetAllSocialMedias();
        Task<bool> UpdateSocialMedia(SocialMediaModel socialMedia);
        Task<bool> DeleteSocialMedia(int id);

        List<SelectListItem> GetSocialMediaName();
    }
}
