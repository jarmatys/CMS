using CMS.Context;
using CMS.Models.Db.Article;
using CMS.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class ArticleService : IArticleService
    {
        private readonly CMSContext _context;

        public ArticleService(CMSContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(ArticleModel category)
        {
            await _context.Articles.AddAsync(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ArticleModel> Get(int id)
        {
            return await _context.Articles
                .Include(x => x.Taxonomies).ThenInclude(x => x.Category)
                .Include(x => x.Taxonomies).ThenInclude(x => x.Tag)
                .Include(x => x.Image)
                .Include(x => x.User)
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<ArticleModel>> GetAll()
        {
            // PYTANIE - Jak wyciągnąć dane powiązane z taxonomies w categorii i tagach
            var articleList = await _context.Articles
                .Include(x => x.Taxonomies).ThenInclude(x => x.Category)
                .Include(x => x.Taxonomies).ThenInclude(x => x.Tag)
                .Include(x => x.User)
                .ToListAsync();

            articleList.Reverse();

            return articleList;
        }

        public async Task<bool> Update(ArticleModel article)
        {
            article.ModifiedDate = DateTime.Now;

            _context.Articles.Update(article);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(b => b.Id == id);

            if (article == null)
            {
                return false;
            }

            _context.Articles.Remove(article);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ArticleModel> GetArticleBySlug(string slug)
        {
            return await _context.Articles
             .Include(x => x.Taxonomies).ThenInclude(x => x.Category)
             .Include(x => x.Taxonomies).ThenInclude(x => x.Tag)
             .Include(x => x.Image)
             .Include(x => x.User)
             .SingleOrDefaultAsync(b => b.Slug == slug);
        }

        public async Task<List<ArticleModel>> GetRangeOfArticle(int start, int count)
        {
            var articleList = await _context.Articles
           .Include(x => x.Taxonomies).ThenInclude(x => x.Category)
           .Include(x => x.Taxonomies).ThenInclude(x => x.Tag)
           .Include(x => x.User)
           .ToListAsync();

            articleList.Reverse();   

            return articleList.Skip(start).Take(count).ToList();
        }

        public async Task<int> ArticleCount()
        {
            var articles = await _context.Articles.ToListAsync();
            return articles.Count;
        }
    }
}
