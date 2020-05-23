using CMS.Models.Db.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IPageService
    {
        Task<bool> Create(PageModel page);
        Task<PageModel> Get(int id);
        Task<List<PageModel>> GetAll();
        Task<bool> Update(PageModel page);
        Task<bool> Delete(int id);
        Task<int> MediaCount();
        Task<PageModel> GetPageBySlug(string slug);
        Task<bool> CheckIfSlugExist(string slug);
    }
}
