using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Settings
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
    }
}
