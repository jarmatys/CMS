using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TPay.Models.Transaction.Requests
{
    /// <summary>
    /// Alias model
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Alias
    {
        /// <summary>
        /// Alias generated in merchant system (unique for each customer).
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Alias type. Can be UID.
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        ///<summary>
        ///This field should contain alias key (returned by first api call with error ERR82) in case of using non-unique alias.
        ///</summary>
        [DataMember]
        public string Key { get; set; }
    }
}
