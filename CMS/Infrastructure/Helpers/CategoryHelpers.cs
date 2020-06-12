using CMS.Areas.Admin.Models.Db.Article;
using CMS.Areas.Admin.Models.View.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
    public static class CategoryHelpers
    {
        static string ConvertTextToSlug(string text)
        {
            return text.Trim().Replace(" ", "-").ToLower();
        } 

        public static CategoryModel ConvertToModel(CategoryView result)
        {
            var categoryModel = new CategoryModel
            {
                Name = result.Name,
                Slug = ConvertTextToSlug(result.ShortName),
                Description = result.Description,
                Count = 0
            };
            return categoryModel;
        }

        public static CategoryView ConvertToView(CategoryModel result)
        {
            var categoryView = new CategoryView
            {
                Id = result.Id,
                Name = result.Name,
                ShortName = result.Slug,
                Description = result.Description
            };
            return categoryView;
        }

        public static CategoryModel MergeViewWithModel(CategoryModel model, CategoryView view)
        {
            model.Name = view.Name;
            model.Slug = ConvertTextToSlug(view.ShortName);
            model.Description = view.Description;

            return model;
        }
    }
}
