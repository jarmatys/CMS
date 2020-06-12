using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Page
{
    public class PageModel
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string Content { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }

        public bool IsIndex { get; set; }
        public bool IsDraft { get; set; }
        public bool IsCannonical { get; set; }

        public string FullUrl { get; set; }
        public string Slug { get; set; }
    }
}
