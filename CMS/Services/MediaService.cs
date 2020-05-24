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

        public async Task<MediaModel> Get(string id)
        {
            return await _context.Medias.Include(x => x.Article).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MediaModel>> GetAll()
        {
            return await _context.Medias.Include(x => x.Article).ToListAsync();
        }

        public async Task<int> MediaCount()
        {
            var medias = await _context.Medias.ToListAsync();
            return medias.Count();
        }

        public async Task<bool> Update(MediaModel media)
        {
            _context.Medias.Update(media);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
