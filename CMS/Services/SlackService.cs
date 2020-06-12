using CMS.Areas.Admin.Models.Others;
using CMS.Infrastructure.Settings;
using CMS.Services.interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class SlackService : INotificationService
    {
        private readonly Uri _url;

        private static readonly Encoding _encoding = new UTF8Encoding();

        public SlackService(IOptions<SlackSettings> config)
        {
            _url = new Uri(config.Value.Url);
        }

        public bool Send(NotificationData result)
        {
            string resultJson = JsonConvert.SerializeObject(result);

            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = resultJson;

                var response = client.UploadValues(_url, "POST", data);
                string responseText = _encoding.GetString(response);
            }

            return true;
        }
    }
}
