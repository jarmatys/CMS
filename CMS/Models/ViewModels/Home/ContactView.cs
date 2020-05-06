using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Home
{
    public class ContactView
    {
        [Required(ErrorMessage = "Pole imię jest obowiązkowe")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole e-mail jest obowiązkowe")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole telefon jest obowiązkowe")]
        public string Phone { get; set; }
        public string Subject { get; set; }

        [Required(ErrorMessage = "Pole wiadomość jest obowiązkowe")]
        public string Message { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Akceptacja polityki prywatności jest obowiązkowa")]
        public bool IsAccepted { get; set; }
    }
}
