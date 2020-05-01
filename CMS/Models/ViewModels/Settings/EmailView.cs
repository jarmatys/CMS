using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Settings
{
    public class EmailView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Uzupełnij hosta")]
        public string Host { get; set; }
        [Required(ErrorMessage = "Uzupełnij port")]
        public int Port { get; set; }
        [Required(ErrorMessage = "Uzupełnij adres e-mail")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Uzupełnij hasło")]
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
    }
}
