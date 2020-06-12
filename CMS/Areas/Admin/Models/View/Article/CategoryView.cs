using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.View.Article
{
    public class CategoryView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uzupełnij nazwę kategorii")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij skrócona nazwę kategorii")]
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
