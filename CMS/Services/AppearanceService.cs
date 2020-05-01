using CMS.Context;
using CMS.Models.Db.Admin;
using CMS.Models.Db.Media;
using CMS.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class AppearanceService : IAppearanceService
    {
        private readonly CMSContext _context;
        public AppearanceService(CMSContext context)
        {
            _context = context;
        }
        public async Task<OptionsModel> GetOptions()
        {
            return await _context.Options
                .Include(a => a.Logo)
                .Include(a => a.Favicon)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveLogo(MediaModel logo)
        {
            var options = await _context.Options.FirstOrDefaultAsync();
            options.Logo = logo;
            return await _context.SaveChangesAsync() > 0;
        }

       

        public async Task<bool> SaveFavicon(MediaModel favicon)
        {
            var options = await _context.Options.FirstOrDefaultAsync();
            options.Favicon = favicon;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
