using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TPay.Models.Transaction.Responsens
{
    /// <summary>
    /// Blik alias response
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BlikAliasResponse
    {

        ///<summary>
        ///Alias user friendly name saved at mobile app (blik request label parameter).
        ///</summary>
        [DataMember]
        public string ApplicationName { get; set; }

        ///<summary>
        ///Alias key which has to be send in case of using non-unique alias.
        ///</summary>
        [DataMember]
        public string ApplicationCode { get; set; }
    }
}
