using CMS.Context;
using CMS.Models.Db.Seo;
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

        public async Task<bool> CreateSocialMedia(SocialMediaModel socialMedia)
        {
            await _context.SocialMedia.AddAsync(socialMedia);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSocialMedia(int id)
        {
            var socialMedia = await _context.SocialMedia.SingleOrDefaultAsync(b => b.Id == id);

            if (socialMedia == null)
            {
                return false;
            }

            _context.SocialMedia.Remove(socialMedia);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<SocialMediaModel>> GetAllSocialMedias()
        {
            return await _context.SocialMedia.ToListAsync();
        }

        public async Task<SocialMediaModel> GetSocialMedia(int id)
        {
            return await _context.SocialMedia.SingleOrDefaultAsync(b => b.Id == id);
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

        public async Task<bool> UpdateSocialMedia(SocialMediaModel socialMedia)
        {
            _context.SocialMedia.Update(socialMedia);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
