using CMS.Areas.Admin.Models.Db.Article;
using CMS.Areas.Admin.Models.Db.Seo;
using CMS.Areas.Admin.Models.Db.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Home.Models
{
    public class HomeView
    {
        public IEnumerable<MetaTagModel> MetaTags { get; set; }
        public IEnumerable<SocialMediaModel> SocialMedias { get; set; }
        public IEnumerable<ArticleModel> Articles { get; set; }
        public IntegrationModel Integrations { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<TagModel> Tags { get; set; }
        public BlogModel BlogSettings { get; set; }
    }
}
