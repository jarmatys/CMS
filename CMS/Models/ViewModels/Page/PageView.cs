using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Page
{
    public class PageView
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }

        [Required(ErrorMessage = "Uzupełnij zawartość strony")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Uzupełnij tytuł strony")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }

        public bool IsCannonical { get; set; }
        public bool IsIndex { get; set; }
        public bool IsDraft { get; set; }

        [Required(ErrorMessage = "Adres strony jest wymagany")]
        public string Slug { get; set; }
    }
}
