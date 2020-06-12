using CMS.Areas.Admin.Models.View.Article;
using CMS.Areas.Home.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IEmailService
    {
        bool SendContactForm(ContactView result);
        bool SendCommentConfirmation(CommentView result);
    }
}
