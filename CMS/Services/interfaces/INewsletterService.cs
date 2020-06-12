using CMS.Areas.Admin.Models.View.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface INewsletterService
    {
        bool SaveUser(NewsletterData result);
    }
}
