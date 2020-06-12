using CMS.Areas.Admin.Models.Db.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Home
{
    public class OptionsModel
    {
        [Key]
        public int Id { get; set; }
        public string SiteUrl { get; set; }
        public string BlogName { get; set; }
        public string BlogDescription { get; set; }
        public bool UserCanRegister { get; set; }
        public string AdminEmail { get; set; }
        public bool IsIndex { get; set; }

        public MediaModel Logo { get; set; }
        public MediaModel Favicon { get; set; }
    }
}
