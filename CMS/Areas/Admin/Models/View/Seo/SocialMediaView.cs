using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.View.Seo
{
    public class SocialMediaView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uzupełnij nazwę")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Uzupełnij link do kanału social mediowego")]
        public string Link { get; set; }

        [Required(ErrorMessage = "Uzupełnij ikonkę socialmedia")]
        public string FontAwesome { get; set; }
    }
}
