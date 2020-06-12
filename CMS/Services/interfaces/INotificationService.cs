using CMS.Areas.Admin.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface INotificationService
    {
        bool Send(NotificationData result);
    }
}
