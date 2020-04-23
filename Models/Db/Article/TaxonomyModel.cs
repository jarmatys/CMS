using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Db.Article
{
    public class TaxonomyModel
    {
        public int Id { get; set; }

        public int? TagId { get; set; }
        public TagModel Tag { get; set; }

        public int? CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public int ArticleId { get; set; }
        public ArticleModel Article { get; set; }
    }
}
