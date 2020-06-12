using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.View.Seo
{
    public class RetrievalLinksView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uzupełnij stary link")]
        public string OldUrl { get; set; }

        [Required(ErrorMessage = "Uzupełnij nowy link")]
        public string NewUrl { get; set; }
    }
}
