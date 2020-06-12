using CMS.Areas.Admin.Models.Db.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface ICategoryService
    {
        Task<bool> Create(CategoryModel category);
        Task<CategoryModel> Get(int id);
        Task<List<CategoryModel>> GetAll();
        Task<bool> Update(CategoryModel category);
        Task<bool> Delete(int id);
        Task<List<CategoryModel>> GetCategoriesByNames(IEnumerable<string> categoriesName);
        Task<CategoryModel> GetCategoryByName(string name);
        Task<bool> CheckIfCategoryExist(string name);
    }
}
