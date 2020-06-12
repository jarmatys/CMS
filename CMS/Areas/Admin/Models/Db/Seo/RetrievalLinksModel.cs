using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Seo
{
    public class RetrievalLinksModel
    {
        public int Id { get; set; }
        public string OldUrl { get; set; }
        public string NewUrl { get; set; }
    }
}
