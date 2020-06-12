using CMS.Areas.Admin.Models.Db.Account;
using CMS.Areas.Admin.Models.Db.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Article
{
    // Model wpisu na blogu
    public class ArticleModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime AddDate { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }

        public bool IsDraft { get; set; }
        public bool CommentStatus { get; set; }

        public string Slug { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string FullUrl { get; set; }
        public int? MenuOrder { get; set; }
        public int CommentCount { get; set; }
        public int Views { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        //public string ImageId { get; set; }
        public MediaModel Image { get; set; }

        public ICollection<TaxonomyModel> Taxonomies { get; set; }
        public ICollection<CommentModel> Comments { get; set; }

    }
}
