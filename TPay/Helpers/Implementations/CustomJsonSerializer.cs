using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TPay.Helpers.Contracts;

namespace TPay.Helpers.Implementations
{
    public class CustomJsonSerializer : ISerializer
    {
        public JsonSerializerSettings Settings { get; set; } = new JsonSerializerSettings();

        public CustomJsonSerializer()
        {
            Settings.NullValueHandling = NullValueHandling.Ignore;
        }


        public CustomJsonSerializer(JsonSerializerSettings settings)
        {
            Settings = settings;
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Settings);
        }

    }
}
