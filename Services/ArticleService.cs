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
			return await _context.Articles.SingleOrDefaultAsync(b => b.Id == id);
		}

		public async Task<List<ArticleModel>> GetAll()
		{
			return await _context.Articles.ToListAsync();
		}

		public async Task<bool> Update(ArticleModel article)
		{
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
	}
}
