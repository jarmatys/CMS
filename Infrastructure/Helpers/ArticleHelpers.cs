using CMS.Models.Db.Account;
using CMS.Models.Db.Article;
using CMS.Models.Db.Media;
using CMS.Models.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Helpers
{
    public static class ArticleHelpers
    {
        private static string ValidateSlug(string text)
        {
            var tempString = text.Trim().Replace(" ", "-").ToLower();
            return Regex.Replace(tempString, "/[&\\/\\#,+()$~%.'\":*?<>{}!]/g", "", RegexOptions.Compiled);
        }

        private static DateTime MergeTimeWithDate(DateTime date, DateTime time)
        {
            var day = date.Day;
            var mounth = date.Month;
            var year = date.Year;

            var minutes = time.Minute;
            var hour = time.Hour;

            return new DateTime(year, mounth, day, hour, minutes, 0);
        }

        public static ArticleModel ConvertToModel(ArticleView article, User user, MediaModel media)
        {
            var articleModel = new ArticleModel
            {
                AddDate = MergeTimeWithDate(article.Date, article.Time),
                Content = article.Content,
                Title = article.Title,
                Excerpt = article.Excerpt,
                IsDraft = article.IsDraft,
                CommentStatus = article.CommentStatus,
                Slug = ValidateSlug(article.Slug),
                ModifiedDate = null,
                FullUrl = null,
                MenuOrder = null,
                CommentCount = 0,
                User = user,
                Image = media,
            };

            return articleModel;
        }
    }
}
