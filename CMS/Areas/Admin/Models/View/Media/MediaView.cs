using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.View.Media
{
    public class MediaView
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required(ErrorMessage = "Uzupełnij nazwę zdjęcia")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij opis zdjęcia")]
        public string Description { get; set; }
    }
}
