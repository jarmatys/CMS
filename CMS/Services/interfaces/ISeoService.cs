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
        List<SelectListItem> GetSocialMediaName();
        List<SelectListItem> GetMetaTagsName();

        Task<bool> CreateSocialMedia(SocialMediaModel socialMedia);
        Task<SocialMediaModel> GetSocialMedia(int id);
        Task<List<SocialMediaModel>> GetAllSocialMedias();
        Task<bool> UpdateSocialMedia(SocialMediaModel socialMedia);
        Task<bool> DeleteSocialMedia(int id);

        Task<bool> CreateMetaTag(MetaTagModel metaTag);
        Task<MetaTagModel> GetMetaTag(int id);
        Task<List<MetaTagModel>> GetAllMetaTags();
        Task<bool> UpdateMetaTag(MetaTagModel metaTag);
        Task<bool> DeleteMetaTag(int id);


        Task<bool> CreateRetrievalLink(RetrievalLinksModel retrievalLink);
        Task<RetrievalLinksModel> GetRetrievalLink(int id);
        Task<List<RetrievalLinksModel>> GetAllRetrievalLinks();
        Task<bool> UpdateRetrievalLink(RetrievalLinksModel retrievalLink);
        Task<bool> DeleteRetrievalLink(int id);

    }
}
