using CMS.Models.Db.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Db.Admin
{
    // Podstawowe ustawenia strony
    public class OptionsModel
    {
        [Key]
        public int Id { get; set; }
        public string SiteUrl { get; set; }
        public string BlogName { get; set; }
        public string BlogDescription { get; set; }
        public bool UserCanRegister { get; set; }
        public string AdminEmail { get; set; }
        public bool CommentsNotify { get; set; }
        public int PostPerPage { get; set; }
        public bool AllowComments { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
        public bool IsIndex { get; set; }

        public MediaModel Logo { get; set; }
        public MediaModel Favicon { get; set; }

    }
}
