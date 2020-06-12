using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Settings
{
    public class PrivacyPolicyModel
    {
        public int Id { get; set; }
        public string PageUrl { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string HostingName { get; set; }
    }
}
