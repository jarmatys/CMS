using CMS.Areas.Admin.Models.Db.Seo;
using CMS.Context;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class SeoService : ISeoService
    {
        private readonly CMSContext _context;

        public SeoService(CMSContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetSocialMediaName()
        {
            var selectList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Facebook", Text = "Facebook" },
                new SelectListItem { Value = "Instagram", Text = "Instagram" },
                new SelectListItem { Value = "Youtube", Text = "Youtube"  }
            };

            return selectList;
        }

        public List<SelectListItem> GetMetaTagsName()
        {
            var selectList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Description", Text = "Description" },
                new SelectListItem { Value = "Title", Text = "Title" },
                new SelectListItem { Value = "Keywords", Text = "Keywords"  }
            };

            return selectList;
        }

        public async Task<bool> CreateSocialMedia(SocialMediaModel socialMedia)
        {
            await _context.SocialMedias.AddAsync(socialMedia);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<SocialMediaModel> GetSocialMedia(int id)
        {
            return await _context.SocialMedias.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<SocialMediaModel>> GetAllSocialMedias()
        {
            return await _context.SocialMedias.ToListAsync();
        }

        public async Task<bool> UpdateSocialMedia(SocialMediaModel socialMedia)
        {
            _context.SocialMedias.Update(socialMedia);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSocialMedia(int id)
        {
            var socialMedia = await _context.SocialMedias.SingleOrDefaultAsync(b => b.Id == id);

            if (socialMedia == null)
            {
                return false;
            }

            _context.SocialMedias.Remove(socialMedia);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<bool> CreateMetaTag(MetaTagModel metaTag)
        {
            await _context.MetaTags.AddAsync(metaTag);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<MetaTagModel> GetMetaTag(int id)
        {
            return await _context.MetaTags.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<MetaTagModel>> GetAllMetaTags()
        {
            return await _context.MetaTags.ToListAsync();
        }

        public async Task<bool> UpdateMetaTag(MetaTagModel metaTag)
        {
            _context.MetaTags.Update(metaTag);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMetaTag(int id)
        {
            var metaTag = await _context.MetaTags.SingleOrDefaultAsync(b => b.Id == id);

            if (metaTag == null)
            {
                return false;
            }

            _context.MetaTags.Remove(metaTag);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<bool> CreateRetrievalLink(RetrievalLinksModel retrievalLink)
        {
            await _context.RetrievalLinks.AddAsync(retrievalLink);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<RetrievalLinksModel> GetRetrievalLink(int id)
        {
            return await _context.RetrievalLinks.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<RetrievalLinksModel>> GetAllRetrievalLinks()
        {
            return await _context.RetrievalLinks.ToListAsync();
        }

        public async Task<bool> UpdateRetrievalLink(RetrievalLinksModel retrievalLink)
        {
            _context.RetrievalLinks.Update(retrievalLink);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRetrievalLink(int id)
        {
            var retrievalLink = await _context.RetrievalLinks.SingleOrDefaultAsync(b => b.Id == id);

            if (retrievalLink == null)
            {
                return false;
            }

            _context.RetrievalLinks.Remove(retrievalLink);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<GeneralSeoSettingsModel> GetSeoSettingsById(int Id)
        {
            return await _context.SeoSettings.FindAsync(Id);
        }

        public async Task<GeneralSeoSettingsModel> GetSeoSettings()
        {
            return await _context.SeoSettings.FirstOrDefaultAsync();
        }

        public async Task<bool> SetSeoSettings(GeneralSeoSettingsModel result)
        {
            _context.SeoSettings.Update(result);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
