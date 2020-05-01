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

      
    }
}
