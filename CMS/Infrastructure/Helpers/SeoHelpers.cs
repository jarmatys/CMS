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
        public static SocialMediaView ConvertToViewSocialMedia(SocialMediaModel result)
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

        public static SocialMediaModel ConvertToModelSocialMedia(SocialMediaView result)
        {
            var socialMediaModel = new SocialMediaModel
            {
                Name = result.Name,
                Link = result.Link,
                FontAwesome = result.FontAwesome
            };

            return socialMediaModel;
        }

        public static SocialMediaModel MergeViewWithModelSocialMedia(SocialMediaModel model, SocialMediaView view)
        {
            model.Link = view.Link;
            model.Name = view.Name;
            model.FontAwesome = view.FontAwesome;

            return model;
        }

        public static MetaTagModel ConvertToModelMetaTag(MetaTagView result)
        {
            var metaTagModel = new MetaTagModel
            {
                Name = result.Name,
                Content = result.Content
            };

            return metaTagModel;
        }

        public static MetaTagView ConvertToViewMetaTag(MetaTagModel result)
        {
            var metaTagView = new MetaTagView
            {
                Name = result.Name,
                Content = result.Content
            };

            return metaTagView;
        }

        public static MetaTagModel MergeViewWithModelMetaTag(MetaTagModel model, MetaTagView view)
        {
            model.Content = view.Content;
            model.Name = view.Name;

            return model;
        }
    }
}
