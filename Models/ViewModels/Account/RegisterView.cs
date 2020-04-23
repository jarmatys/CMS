using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Account
{
    public class RegisterView
    {
        [Required(ErrorMessage = "Uzupełnij login użytkownika")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Uzupełnij adres E-mail użytkownika")]
        [EmailAddress(ErrorMessage = "Adres E-mail jest niepoprawny")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Uzupełnij hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Uzupełnij powtórkę hasła")]
        [Compare("Password", ErrorMessage = "Hasła nie pasują do siebie")]
        public string RepeatPassword { get; set; }
    }
}
