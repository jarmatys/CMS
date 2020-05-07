using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Article
{
    public class CommentView
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }
        public bool IsAccepted { get; set; }

        [EmailAddress(ErrorMessage = "Podaj poprawny adres E-mail")]
        [Required(ErrorMessage = "Uzupełnij E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Uzupełnij imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Uzupełnij treść komentarza")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Id artykułu jest obowiązkowe!")]

        public int ArticleId { get; set; }

    }
}
