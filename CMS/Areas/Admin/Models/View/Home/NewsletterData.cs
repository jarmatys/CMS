using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.View.Home
{
    public class NewsletterData
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Aby się zapisać podaj wczeniej poprawny adres e-mial")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail")]
        public string Email { get; set; }
    }
}
