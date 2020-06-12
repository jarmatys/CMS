using CMS.Areas.Admin.Models.Db.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface ISettingsService
    {
        Task<EmailModel> GetEmailSettingsById(int Id);
        Task<EmailModel> GetEmailSettings();
        Task<bool> SetEmailSettings(EmailModel result);

        Task<PrivacyPolicyModel> GetPrivacyPolicySettingsById(int Id);
        Task<PrivacyPolicyModel> GetPrivacyPolicySettings();
        Task<bool> SetPrivacyPolicySettings(PrivacyPolicyModel result);

        Task<IntegrationModel> GetIntegrationSettingsById(int Id);
        Task<IntegrationModel> GetIntegrationSettings();
        Task<bool> SetIntegrationSettings(IntegrationModel result);

        Task<BlogModel> GetBlogSettingsById(int Id);
        Task<BlogModel> GetBlogSettings();
        Task<bool> SetBlogSettings(BlogModel result);
    }
}
