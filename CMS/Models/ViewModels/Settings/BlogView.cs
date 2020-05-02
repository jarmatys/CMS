using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Settings
{
    public class BlogView
    {
        public int Id { get; set; }
        public bool CommentsNotify { get; set; }
        [Required(ErrorMessage = "Uzupełnij ilość postów na stronę")]
        public int PostPerPage { get; set; }
        public bool AllowComments { get; set; }
        [Required(ErrorMessage = "Uzupełnij format daty")]
        public string DateFormat { get; set; }
        [Required(ErrorMessage = "Uzupełnij format czasu")]
        public string TimeFormat { get; set; }
    }
}
