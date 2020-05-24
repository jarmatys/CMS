using CMS.Models.Db.Article;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Db.Media
{
    public class MediaModel
    {
        public MediaModel()
        {
            AddDate = DateTime.Now;
        }

        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Length { get; set; }

        public DateTime AddDate { get; set; }

        public int TypeId { get; set; }
        public string Type { get; set; }

        [ForeignKey("ArticleModel")]
        // poczytac o isunique żeby dane zdjęcie było w relacji jeden do jeden z articlem
        public int? ArticleId { get; set; }

        public ArticleModel Article { get; set; }
    }
}
