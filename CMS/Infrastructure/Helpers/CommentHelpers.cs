using CMS.Areas.Admin.Models.Db.Article;
using CMS.Areas.Admin.Models.View.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Helpers
{
    public static class CommentHelpers
    {
        public static CommentModel ConvertToModel(CommentView result, ArticleModel article)
        {
            var commentModel = new CommentModel
            {
                AddDate = DateTime.Now,
                Content = result.Content,
                Name = result.Name,
                Email = result.Email,
                Article = article,
                IsAccepted = false
            };
            return commentModel;
        }

        public static CommentView ConvertToView(CommentModel result)
        {
            var commentView = new CommentView
            {
                Id = result.Id,
                AddDate = DateTime.Now,
                Content = result.Content,
                Name = result.Name,
                Email = result.Email,
                IsAccepted = result.IsAccepted
                
            };
            return commentView;
        }

        public static CommentModel MergeViewWithModel(CommentModel model, CommentView view)
        {
            model.Content = view.Content;
            model.Email = view.Email;
            model.Name = view.Name;
            model.IsAccepted = view.IsAccepted;

            return model;
        }
    }
}
