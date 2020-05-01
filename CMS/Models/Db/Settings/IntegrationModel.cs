using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Db.Settings
{
    public class IntegrationModel
    {
        public int Id { get; set; }
        public string Tawkto { get; set; }
        public string GoogleAnalytics { get; set; }
        public string FacebookPixel { get; set; }
        public string YandexMetrica { get; set; }
        public string GoogleMaps { get; set; }
        public string Recaptcha { get; set; }
        public string Hotjar { get; set; }
        public string CustomScripts { get; set; }
    }
}
