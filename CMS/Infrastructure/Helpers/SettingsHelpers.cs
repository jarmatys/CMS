using CMS.Models.Db.Settings;
using CMS.Models.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Helpers
{
    public static class SettingsHelpers
    {
        public static EmailView ConvertToView(EmailModel result)
        {
            var emailView = new EmailView
            {
                Id = result.Id,
                Host = result.Host,
                Password = result.Password,
                EnableSSL = result.EnableSSL,
                Port = result.Port,
                UserName = result.UserName
            };

            return emailView;
        }

        public static EmailModel ConvertToModel(EmailView result)
        {
            var emailModel = new EmailModel
            {
                Id = result.Id,
                Host = result.Host,
                Password = result.Password,
                EnableSSL = result.EnableSSL,
                Port = result.Port,
                UserName = result.UserName
            };

            return emailModel;
        }

        public static EmailModel MergeViewWithModel(EmailModel model, EmailView view)
        {
            model.Host = view.Host;
            model.UserName = view.UserName;
            model.Port = view.Port;
            model.Password = view.Password;
            model.EnableSSL = view.EnableSSL;

            return model;
        }
    }
}
