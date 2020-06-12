using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.View.Seo
{
    public class GeneralSeoSettingsView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uzupełnij głowny title strony")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Uzupełnij Url strony")]
        public string MainUrl { get; set; }
    }
}
