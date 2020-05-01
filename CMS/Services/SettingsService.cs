using CMS.Context;
using CMS.Models.Db.Settings;
using CMS.Models.ViewModels.Settings;
using CMS.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly CMSContext _context;
        public SettingsService(CMSContext context)
        {
            _context = context;
        }

        public async Task<EmailModel> GetEmailSettingsById(int Id)
        {
            return await _context.EmailSettings.FindAsync(Id);
        }

        public async Task<EmailModel> GetEmailSettings()
        {
            return await _context.EmailSettings.FirstOrDefaultAsync();
        }

        public async Task<bool> SetEmailSettings(EmailModel result)
        {
            _context.EmailSettings.Update(result);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PrivacyPolicyModel> GetPrivacyPolicySettingsById(int Id)
        {
            return await _context.PrivacyPolicySettings.FindAsync(Id);
        }

        public async Task<PrivacyPolicyModel> GetPrivacyPolicySettings()
        {
            return await _context.PrivacyPolicySettings.FirstOrDefaultAsync();
        }

        public async Task<bool> SetPrivacyPolicySettings(PrivacyPolicyModel result)
        {
            _context.PrivacyPolicySettings.Update(result);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IntegrationModel> GetIntegrationSettingsById(int Id)
        {
            return await _context.IntegrationSettings.FindAsync(Id);
        }

        public async Task<IntegrationModel> GetIntegrationSettings()
        {
            return await _context.IntegrationSettings.FirstOrDefaultAsync();
        }

        public async Task<bool> SetIntegrationSettings(IntegrationModel result)
        {
            _context.IntegrationSettings.Update(result);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
