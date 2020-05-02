using CMS.Models.Db.Seo;
using CMS.Models.ViewModels.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Helpers
{
    public static class SeoHelpers
    {
        public static SocialMediaView ConvertToView(SocialMediaModel result)
        {
            var socialMediaView = new SocialMediaView
            {
                Id = result.Id,
                Name = result.Name,
                Link = result.Link,
                FontAwesome = result.FontAwesome
            };

            return socialMediaView;
        }

        public static SocialMediaModel ConvertToModel(SocialMediaView result)
        {
            var socialMediaModel = new SocialMediaModel
            {
                Name = result.Name,
                Link = result.Link,
                FontAwesome = result.FontAwesome
            };

            return socialMediaModel;
        }

        public static SocialMediaModel MergeViewWithModel(SocialMediaModel model, SocialMediaView view)
        {
            model.Link = view.Link;
            model.Name = view.Name;
            model.FontAwesome = view.FontAwesome;

            return model;
        }
    }
}
