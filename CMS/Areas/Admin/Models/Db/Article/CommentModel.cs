using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Article
{
    public class CommentModel
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsAccepted { get; set; }

        public int ArticleId { get; set; }
        public ArticleModel Article { get; set; }
    }
}
