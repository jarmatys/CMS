using CMS.Models.Db.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface ITaxonomyService
    {
        Task<List<TaxonomyModel>> SaveCategories(List<CategoryModel> categories, ArticleModel article);
        Task<List<TaxonomyModel>> SaveTags(List<TagModel> tags, ArticleModel article);
    }
}
