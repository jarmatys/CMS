using CMS.Models.Db.Article;
using CMS.Models.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
    public class TagHelpers
    {
        static string ConvertTextToSlug(string text)
        {
            return text.Trim().Replace(" ", "-").ToLower();
        }

        public static TagModel ConvertToModel(TagView result)
        {
            var categoryModel = new TagModel
            {
                Name = result.Name,
                Slug = ConvertTextToSlug(result.ShortName),
                Description = result.Description,
                Count = 0
            };
            return categoryModel;
        }

        public static TagView ConvertToView(TagModel result)
        {
            var tagView = new TagView
            {
                Id = result.Id,
                Name = result.Name,
                ShortName = result.Slug,
                Description = result.Description
            };
            return tagView;
        }

        public static TagModel MergeViewWithModel(TagModel model, TagView view)
        {
            model.Name = view.Name;
            model.Slug = ConvertTextToSlug(view.ShortName);
            model.Description = view.Description;

            return model;
        }
    }
}
