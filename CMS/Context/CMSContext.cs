using CMS.Models.Db.Account;
using CMS.Models.Db.Admin;
using CMS.Models.Db.Article;
using CMS.Models.Db.Media;
using CMS.Models.Db.Page;
using CMS.Models.Db.Seo;
using CMS.Models.Db.Settings;
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
        public DbSet<OptionsModel> Options { get; set; }
        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<TaxonomyModel> Taxonomies { get; set; }
        public DbSet<MediaModel> Medias { get; set; }
        public DbSet<MediaTypeModel> MediaTypes { get; set; }
        public DbSet<PageModel> Pages { get; set; }

        public DbSet<EmailModel> EmailSettings { get; set; }
        public DbSet<PrivacyPolicyModel> PrivacyPolicySettings { get; set; }
        public DbSet<IntegrationModel> IntegrationSettings { get; set; }
        public DbSet<BlogModel> BlogSettings { get; set; }

        public DbSet<SocialMediaModel> SocialMedias { get; set; }
        public DbSet<MetaTagModel> MetaTags { get; set; }
        public DbSet<RetrievalLinksModel> RetrievalLinks { get; set; }

        // Zaślepka na klasę bazową
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Zapytać jak to działa

            //builder.Entity<ArticleModel>()
            //    .HasOne(i => i.Image)
            //    .WithOne(a => a.Article)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ArticleModel>()
            //    .HasMany(t => t.Taxonomies)
            //    .WithOne(a => a.Article)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
