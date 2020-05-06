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
        public static EmailView ConvertToViewEmail(EmailModel result)
        {
            var emailView = new EmailView
            {
                Id = result.Id,
                Host = result.Host,
                Password = result.Password,
                EnableSSL = result.EnableSSL,
                Port = result.Port,
                EmailTo = result.EmailTo,
                EmailFrom = result.EmailFrom
            };

            return emailView;
        }

        public static EmailModel ConvertToModelEmail(EmailView result)
        {
            var emailModel = new EmailModel
            {
                Id = result.Id,
                Host = result.Host,
                Password = result.Password,
                EnableSSL = result.EnableSSL,
                Port = result.Port,
                EmailTo = result.EmailTo,
                EmailFrom = result.EmailFrom
            };

            return emailModel;
        }

        public static EmailModel MergeViewWithModelEmail(EmailModel model, EmailView view)
        {
            model.Host = view.Host;
            model.EmailFrom = view.EmailFrom;
            model.EmailTo = view.EmailTo;
            model.Port = view.Port;
            model.Password = view.Password;
            model.EnableSSL = view.EnableSSL;

            return model;
        }

        public static PrivacyPolicyView ConvertToViewPrivacePolicy(PrivacyPolicyModel result)
        {
            var privacyPolicyView = new PrivacyPolicyView
            {
                Id = result.Id,
                PageUrl = result.PageUrl,
                CompanyName = result.CompanyName,
                Street = result.Street,
                City = result.City,
                ZipCode = result.ZipCode,
                Email = result.Email,
                HostingName = result.HostingName
            };

            return privacyPolicyView;
        }

        public static PrivacyPolicyModel MergeViewWithModelPrivacyPolicy(PrivacyPolicyModel model, PrivacyPolicyView view)
        {
            model.PageUrl = view.PageUrl;
            model.CompanyName = view.CompanyName;
            model.Street = view.Street;
            model.City = view.City;
            model.ZipCode = view.ZipCode;
            model.Email = view.Email;
            model.HostingName = view.HostingName;

            return model;
        }

        public static IntegrationView ConvertToViewIntegration(IntegrationModel result)
        {
            var integrationView = new IntegrationView
            {
                Id = result.Id,
                Tawkto = result.Tawkto,
                GoogleAnalytics = result.GoogleAnalytics,
                FacebookPixel = result.FacebookPixel,
                YandexMetrica = result.YandexMetrica,
                GoogleMaps = result.GoogleMaps,
                Recaptcha = result.Recaptcha,
                Hotjar = result.Hotjar,
                CustomScripts = result.CustomScripts,
            };

            return integrationView;
        }

        public static IntegrationModel MergeViewWithModelIntegration(IntegrationModel model, IntegrationView view)
        {
            model.Tawkto = view.Tawkto;
            model.GoogleAnalytics = view.GoogleAnalytics;
            model.FacebookPixel = view.FacebookPixel;
            model.YandexMetrica = view.YandexMetrica;
            model.GoogleMaps = view.GoogleMaps;
            model.Recaptcha = view.Recaptcha;
            model.Hotjar = view.Hotjar;
            model.CustomScripts = view.CustomScripts;

            return model;
        }

        public static BlogView ConvertToViewBlog(BlogModel result)
        {
            var blogView = new BlogView
            {
                Id = result.Id,
                CommentsNotify = result.CommentsNotify,
                PostPerPage = result.PostPerPage,
                AllowComments = result.AllowComments,
                DateFormat = result.DateFormat,
                TimeFormat = result.TimeFormat
            };

            return blogView;
        }
        
        public static BlogModel MergeViewWithModelBlog(BlogModel model, BlogView view)
        {
            model.CommentsNotify = view.CommentsNotify;
            model.PostPerPage = view.PostPerPage;
            model.AllowComments = view.AllowComments;
            model.DateFormat = view.DateFormat;
            model.TimeFormat = view.TimeFormat;

            return model;
        }
    }
}
