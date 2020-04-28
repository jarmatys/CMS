using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TPay.Routes;

namespace TPay.Helpers
{
    public class RoutesGetter<T> where T : RouteSettings
    {
        private object _routes;

        public RoutesGetter(object routes)
        {
            _routes = routes;
        }
        public IDictionary<string, string> GetRoutesDictionary()
        {
            var routes = new Dictionary<string, string>();
            foreach (PropertyInfo property in _routes.GetType().GetProperties())
            {
                if (property.Name.Contains("Url"))
                {
                    routes.Add(property.Name, property.GetValue(_routes).ToString());
                }
            }

            return routes;
        }
    }
}
