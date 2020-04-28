using System;
using System.Collections.Generic;
using System.Text;

namespace TPay.Routes
{
    public abstract class RouteSettings
    {
        public RouteSettings(string origin, string apiKey)
        {
            Origin = origin;
            ApiKey = apiKey;

            SetRoutes();
        }
        private string apiKey;

        public string ApiKey
        {
            get { return apiKey; }
            set { SetRoutes(); apiKey = value; }
        }

        private string origin;

        public string Origin
        {
            get { return origin; }
            set { SetRoutes(); origin = value; }
        }

        public abstract void SetRoutes();
    }
}
