using CMS.Context;
using CMS.Models.ViewModels.Home;
using CMS.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class HomeService : IHomeService
    {
        private readonly CMSContext _context;
        public HomeService(CMSContext context)
        {
            _context = context;
        }

        public async Task<string> CheckRedirect(string link)
        {
            var redirect = await _context.RetrievalLinks.SingleOrDefaultAsync(x => x.OldUrl == link);
            if(redirect != null)
            {
                return redirect.NewUrl;
            }
            return null;
        }

        public async Task<HomeView> GetHomeProperties()
        {
            var homeView = new HomeView
            {
                MetaTags = await _context.MetaTags.ToListAsync(),
                SocialMedias = await _context.SocialMedias.ToListAsync(),
                Articles = Enumerable.Reverse(await _context.Articles.Where(x => x.IsDraft != true).Include(x => x.Image).Include(x => x.User).ToListAsync()).Take(3).Reverse(),
                Integrations = await _context.IntegrationSettings.FirstOrDefaultAsync(),
                Categories = await _context.Categories.ToListAsync(),
                Tags = await _context.Tags.ToListAsync()
            };

            return homeView;
        }
    }
}
