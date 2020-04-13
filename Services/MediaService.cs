using CMS.Context;
using CMS.Models.Db.Media;
using CMS.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class MediaService : IMediaService
    {
		private readonly CMSContext _context;

		public MediaService(CMSContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(MediaModel media)
		{
			await _context.Medias.AddAsync(media);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<MediaModel> Get(int id)
		{
			return await _context.Medias.SingleOrDefaultAsync(b => b.Id == id);
		}

		public async Task<List<MediaModel>> GetAll()
		{
			return await _context.Medias.ToListAsync();
		}

		public async Task<bool> Update(MediaModel media)
		{
			_context.Medias.Update(media);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(int id)
		{
			var media = await _context.Medias.SingleOrDefaultAsync(b => b.Id == id);

			if (media == null)
			{
				return false;
			}

			_context.Medias.Remove(media);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
