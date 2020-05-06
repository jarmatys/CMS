using CMS.Models.Db.Article;
using CMS.Models.Db.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Home
{
    public class HomeView
    {
        public IEnumerable<MetaTagModel> MetaTags { get; set; }
        public IEnumerable<SocialMediaModel> SocialMedias { get; set; }
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}