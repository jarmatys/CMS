using CMS.Context;
using CMS.Models.Db.Page;
using CMS.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class PageService : IPageService
    {
		private readonly CMSContext _context;

		public PageService(CMSContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(PageModel page)
		{
			await _context.Pages.AddAsync(page);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<PageModel> Get(int id)
		{
			return await _context.Pages.SingleOrDefaultAsync(b => b.Id == id);
		}

		public async Task<List<PageModel>> GetAll()
		{
			return await _context.Pages.ToListAsync();
		}

		public async Task<bool> Update(PageModel category)
		{
			_context.Pages.Update(category);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(int id)
		{
			var page = await _context.Pages.SingleOrDefaultAsync(b => b.Id == id);

			if (page == null)
			{
				return false;
			}

			_context.Pages.Remove(page);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<int> MediaCount()
		{
			var pages = await _context.Pages.ToListAsync();
			return pages.Count();
		}

		public async Task<PageModel> GetPageBySlug(string slug)
		{
			return await _context.Pages.SingleOrDefaultAsync(b => b.Slug == slug);
		}
	}
}
