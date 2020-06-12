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
    public class CommentService : ICommentService
    {
        private readonly CMSContext _context;
        public CommentService(CMSContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            var articles = await _context.Comments.ToListAsync();
            return articles.Count;
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
            var comments = await _context.Comments
                .Include(a => a.Article)
                .ToListAsync();

            comments.Reverse();

            return comments;
        }

        public async Task<bool> Update(CommentModel comment)
        {
            _context.Comments.Update(comment);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Reject(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            comment.IsAccepted = false;

            _context.Comments.Update(comment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Accept(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            comment.IsAccepted = true;

            _context.Comments.Update(comment);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
