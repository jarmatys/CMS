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
        public string MailServerUrl { get; set; }
        public string MailServerLogin { get; set; }
        public string MailServerPassword { get; set; }
        public int MailPort { get; set; }
        public bool AllowComments { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }

    }
}
