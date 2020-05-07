using CMS.Models.Db.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IArticleService
    {
        Task<bool> Create(ArticleModel article);
        Task<ArticleModel> Get(int id);
        Task<List<ArticleModel>> GetAll();
        Task<bool> Update(ArticleModel article);
        Task<bool> Delete(int id);
        Task<int> ArticleCount();
        Task<ArticleModel> GetArticleBySlug(string slug);
        Task<List<ArticleModel>> GetRangeOfArticle(int start, int count);
        Task<List<ArticleModel>> GetRangeOfArticleCategory(int start, int count, string category);
    }
}
