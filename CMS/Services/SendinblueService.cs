using CMS.Areas.Admin.Models.View.Home;
using CMS.Context;
using CMS.Infrastructure.Settings;
using CMS.Services.interfaces;
using Microsoft.Extensions.Options;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class SendinblueService : INewsletterService
    {
        private readonly ContactsApi _sendinblue;


        public SendinblueService(IOptions<SendinblueSettings> config, CMSContext context)
        {
            if(config.Value != null)
            {
                Configuration.Default.ApiKey["api-key"] = config.Value.ApiKey;
                _sendinblue = new ContactsApi();
            }           
        }

        public async Task<bool> SaveUser(NewsletterData result)
        {
            if(_sendinblue != null)
            {
                var newContact = new CreateContact
                {
                    Email = result.Email
                };

                var response = await _sendinblue.CreateContactAsync(newContact);

                return response.Id > 0;
            }
            else
            {
                return false;
            }
            
        }
    }
}
