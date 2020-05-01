using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Settings
{
    public class PrivacyPolicyView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Uzupełnij adres strony")]
        public string PageUrl { get; set; }
        [Required(ErrorMessage = "Uzupełnij nazwę firmy")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Uzupełnij ulice, na której zarejestrowana jest firma")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Uzupełnij miasto w ktorym zarejestrowana jest firma")]
        public string City { get; set; }
        [Required(ErrorMessage = "Uzupełnij kod pocztowy")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Uzupełnij adres e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Uzupełnij nazwę hostingodawcy")]
        public string HostingName { get; set; }
    }
}
