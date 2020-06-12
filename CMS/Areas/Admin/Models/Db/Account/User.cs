using CMS.Areas.Admin.Models.Db.Article;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Models.Db.Account
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}
