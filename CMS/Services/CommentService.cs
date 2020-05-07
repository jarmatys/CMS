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
    public class CommentService : ICommentService
    {
        private readonly CMSContext _context;
        public CommentService(CMSContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(CommentModel comment)
        {
            await _context.Comments.AddAsync(comment);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> Delete(int id)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(b => b.Id == id);

            if (comment == null)
            {
                return false;
            }

            _context.Comments.Remove(comment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<CommentModel> Get(int id)
        {
            return await _context.Comments.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<CommentModel>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<bool> Update(CommentModel comment)
        {
            _context.Comments.Update(comment);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
