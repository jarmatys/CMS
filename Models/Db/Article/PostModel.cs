using CMS.Models.Db.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Db.Article
{
    // Model wpisu na blogu
    public class PostModel
    {
        public PostModel()
        {
            AddDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public DateTime AddDate { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }

        // Status określa na jakim etapie znajduje się nasz post [Publish, Draft]
        public string Status { get; set; }
        public bool CommentStatus { get; set; }
        public string Password { get; set; }
        public string Slug { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string FullUrl { get; set; }
        public int MenuOrder { get; set; }
        public int CommentCount { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
