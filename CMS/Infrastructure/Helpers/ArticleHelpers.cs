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
        public static string BuildArticleFullUrl(string url, string slug)
        {
            return $"{url}/blog/wpis/{slug}";
        }

        private static List<string> GetCategoryFromTaxonomy(ICollection<TaxonomyModel> taxonomies)
        {
            var categoryList = new List<string>();
            foreach(var taxonomy in taxonomies)
            {
                if(taxonomy.Category != null)
                {
                    categoryList.Add(taxonomy.Category.Name);
                }
            }
            return categoryList;
        }

        private static List<string> GetTagFromTaxonomy(ICollection<TaxonomyModel> taxonomies)
        {
            var tagList = new List<string>();
            foreach (var taxonomy in taxonomies)
            {
                if (taxonomy.Tag != null)
                {
                    tagList.Add(taxonomy.Tag.Name);
                }
            }
            return tagList;
        }

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

        public static ArticleModel ConvertToModel(ArticleView article, User user, string mainUrl)
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
                FullUrl = BuildArticleFullUrl(mainUrl, ValidateSlug(article.Slug)),
                MenuOrder = null,
                CommentCount = 0,
                User = user
            };

            return articleModel;
        }

        public static ArticleView ConvertToView(ArticleModel article)
        {
            var articleView = new ArticleView
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                Excerpt = article.Excerpt,
                IsDraft = article.IsDraft,
                CommentStatus = article.CommentStatus,
                Slug = article.Slug,
                User = article.User,
                FullUrl = article.FullUrl
            };

            // Sprawdzamy czy zdjęcie wyrożniające jest ustawione
            if(article.Image == null)
            {
                articleView.ImageUrl = "/admin/images/img-placeholder.png";
            }
            else
            {
                articleView.ImageUrl = article.Image.Url;
            }

            // Sprawdzamy czy wystepują jakieś tagi bądź kategorie
            if(article.Taxonomies.Count != 0)
            {
                articleView.Categories = GetCategoryFromTaxonomy(article.Taxonomies);
                articleView.Tags = GetTagFromTaxonomy(article.Taxonomies);
            }

            return articleView;
        }

        public static ArticleModel MergeViewWithModel(ArticleModel model, ArticleView view, string mainUrl)
        {
            model.Title = view.Title;
            model.Slug = view.Slug;
            model.Content = view.Content;
            model.CommentStatus = view.CommentStatus;
            model.IsDraft = view.IsDraft;
            model.Excerpt = view.Excerpt;
            model.FullUrl = BuildArticleFullUrl(mainUrl, view.Slug);

            return model;
        }
    }
}
