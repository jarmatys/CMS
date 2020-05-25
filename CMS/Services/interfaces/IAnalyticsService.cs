using CMS.Models.Db.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IAnalyticsService
    {
        Task<int> GetSumArticleCount();
        Task<int> GetSumComments();
        Task<int> GetSumArticleViews();
        Task<ICollection<ArticleModel>> GetMostPopularArticle();
    }
}
