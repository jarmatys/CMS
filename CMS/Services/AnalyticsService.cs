using CMS.Areas.Admin.Models.Db.Article;
using CMS.Context;
using CMS.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly CMSContext _context;
        public AnalyticsService(CMSContext context)
        {
            _context = context;
        }


        public async Task<ICollection<ArticleModel>> GetMostPopularArticle()
        {
            return await _context.Articles.OrderByDescending(a => a.Views).Take(10).ToListAsync();
        }

        public async Task<int> GetSumArticleCount()
        {
            var articles = await _context.Articles.ToListAsync();
            return articles.Count();
        }

        public async Task<int> GetSumArticleViews()
        {
            return await _context.Articles.SumAsync(x=> x.Views);
        }

        public async Task<int> GetSumComments()
        {
            var comments = await _context.Comments.ToListAsync();
            return comments.Count();
        }
    }
}
