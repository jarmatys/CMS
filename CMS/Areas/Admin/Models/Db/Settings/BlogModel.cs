using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Settings
{
    public class BlogModel
    {
        public int Id { get; set; }
        public bool CommentsNotify { get; set; }
        public int PostPerPage { get; set; }
        public bool AllowComments { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
    }
}
