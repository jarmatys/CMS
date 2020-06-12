using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.View.Seo
{
    public class MetaTagView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uzupełnij name meta tagu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Uzupełnij content meta tagu")]
        public string Content { get; set; }
    }
}
