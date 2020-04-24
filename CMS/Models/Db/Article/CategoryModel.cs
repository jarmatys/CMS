using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Db.Article
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }

        public ICollection<TaxonomyModel> Taxonomies { get; set; }

    }
}
