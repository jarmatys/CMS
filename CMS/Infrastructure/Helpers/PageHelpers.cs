using CMS.Areas.Admin.Models.Db.Page;
using CMS.Areas.Admin.Models.View.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Helpers
{
    public static class PageHelpers
    {
        static string ConvertTextToSlug(string text)
        {
            return text.Trim().Replace(" ", "-").ToLower();
        }

        public static string BuildPageFullUrl(string url, string slug)
        {
            return $"{url}/strona/{slug}";
        }


        public static PageModel ConvertToModel(PageView result, string mainUrl)
        {
            var pageModel = new PageModel
            {
                AddDate = DateTime.Now,
                Content = result.Content,
                Title = result.Title,
                Description = result.Description,
                KeyWords = result.KeyWords,
                IsIndex = result.IsIndex,
                IsDraft = result.IsDraft,
                IsCannonical = result.IsCannonical,
                FullUrl = BuildPageFullUrl(mainUrl, ConvertTextToSlug(result.Slug)),
                Slug = ConvertTextToSlug(result.Slug)
            };

            return pageModel;
        }

        public static PageView ConvertToView(PageModel result)
        {
            var pageView = new PageView
            {
                Id = result.Id,
                Content = result.Content,
                Title = result.Title,
                Description = result.Description,
                KeyWords = result.KeyWords,
                IsIndex = result.IsIndex,
                IsDraft = result.IsDraft,
                IsCannonical = result.IsCannonical,
                Slug = result.Slug
            };

            return pageView;
        }

        public static PageModel MergeViewWithModel(PageModel model, PageView view, string mainUrl)
        {
            model.Content = view.Content;
            model.Description = view.Description;
            model.Title = view.Title;
            model.KeyWords = view.KeyWords;
            model.IsCannonical = view.IsCannonical;
            model.IsDraft = view.IsDraft;
            model.IsIndex = view.IsIndex;
            model.FullUrl = BuildPageFullUrl(mainUrl, ConvertTextToSlug(view.Slug));
            model.Slug = ConvertTextToSlug(view.Slug);

            return model;
        }
    }
}
