using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Article
{
    public class TagView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uzupełnij nazwę tagu")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij skrócona nazwę tagu")]
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
