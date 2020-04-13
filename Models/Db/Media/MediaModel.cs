using CMS.Models.Db.Article;
using System;
using System.Collections.Generic;
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

        public int Id { get; set; }
        public string Path { get; set; }
        public string MiniaturePath { get; set; }
        public DateTime AddDate { get; set; }

        public int TypeMediaId { get; set; }
        public MediaTypeModel Type { get; set; }

        public int? ArticleId { get; set; }
        public ArticleModel Article { get; set; }
    }
}
