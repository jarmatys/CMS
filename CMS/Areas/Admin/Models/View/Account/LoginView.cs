using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.View.Account
{
    public class LoginView
    {
        [Required(ErrorMessage = "Podaj login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Podaj hasło")]
        public string Password { get; set; }
        public bool RemberMe { get; set; }
    }
}
