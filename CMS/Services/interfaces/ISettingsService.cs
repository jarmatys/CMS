using CMS.Models.Db.Settings;
using CMS.Models.ViewModels.Settings;
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
    }
}
