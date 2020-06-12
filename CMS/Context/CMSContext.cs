using CMS.Areas.Admin.Models.Db.Account;
using CMS.Areas.Admin.Models.Db.Article;
using CMS.Areas.Admin.Models.Db.Media;
using CMS.Areas.Admin.Models.Db.Page;
using CMS.Areas.Admin.Models.Db.Seo;
using CMS.Areas.Admin.Models.Db.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Context
{
    public class CMSContext : IdentityDbContext<User>
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base(options) { }

        // Tutaj będziemy dodawać DbSet'y
        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<TaxonomyModel> Taxonomies { get; set; }
        public DbSet<MediaModel> Medias { get; set; }
        public DbSet<PageModel> Pages { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        public DbSet<EmailModel> EmailSettings { get; set; }
        public DbSet<PrivacyPolicyModel> PrivacyPolicySettings { get; set; }
        public DbSet<IntegrationModel> IntegrationSettings { get; set; }
        public DbSet<BlogModel> BlogSettings { get; set; }
        
        public DbSet<SocialMediaModel> SocialMedias { get; set; }
        public DbSet<MetaTagModel> MetaTags { get; set; }
        public DbSet<RetrievalLinksModel> RetrievalLinks { get; set; }
        public DbSet<GeneralSeoSettingsModel> SeoSettings { get; set; }

        // Zaślepka na klasę bazową
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
