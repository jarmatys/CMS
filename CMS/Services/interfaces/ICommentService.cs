using CMS.Areas.Admin.Models.Db.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface ICommentService
    {
        Task<bool> Create(CommentModel comment);
        Task<CommentModel> Get(int id);
        Task<List<CommentModel>> GetAll();
        Task<bool> Update(CommentModel comment);
        Task<bool> Delete(int id);
        Task<int> Count();
        Task<bool> Accept(int id);
        Task<bool> Reject(int id);
    }
}
