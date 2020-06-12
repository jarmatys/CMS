using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Seo
{
    public class GeneralSeoSettingsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MainUrl { get; set; }
    }
}
