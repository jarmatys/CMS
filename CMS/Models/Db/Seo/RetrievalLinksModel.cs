using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Db.Seo
{
    public class RetrievalLinksModel
    {
        public int Id { get; set; }
        public string OldUrl { get; set; }
        public string NewUrl { get; set; }
    }
}
