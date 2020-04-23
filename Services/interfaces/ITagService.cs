using CMS.Models.Db.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface ITagService
    {
        Task<bool> Create(TagModel tag);
        Task<TagModel> Get(int id);
        Task<List<TagModel>> GetAll();
        Task<bool> Update(TagModel tag);
        Task<bool> Delete(int id);
        Task<List<TagModel>> GetCategoriesByNames(IEnumerable<string> tagsName);

    }
}
