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
    public class CategoryService : ICategoryService
    {
		private readonly CMSContext _context;

		public CategoryService(CMSContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(CategoryModel category)
		{
			await _context.Categories.AddAsync(category);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<CategoryModel> Get(int id)
		{
			return await _context.Categories.SingleOrDefaultAsync(b => b.Id == id);
		}

		public async Task<List<CategoryModel>> GetAll()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<bool> Update(CategoryModel category)
		{
			_context.Categories.Update(category);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(int id)
		{
			var category = await _context.Categories.SingleOrDefaultAsync(b => b.Id == id);

			if (category == null)
			{
				return false;
			}

			_context.Categories.Remove(category);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<List<CategoryModel>> GetCategoriesByNames(IEnumerable<string> categoriesName)
		{
			var categoriesList = new List<CategoryModel>();
			if(categoriesName != null)
			{
				foreach (var name in categoriesName)
				{
					var category = await _context.Categories.SingleOrDefaultAsync(x => x.Name == name);
					categoriesList.Add(category);
				}
			}	
			return categoriesList;
		}
	}
}
