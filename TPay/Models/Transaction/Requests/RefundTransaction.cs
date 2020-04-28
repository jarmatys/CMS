using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TPay.Models.Transaction.Requests
{
    /// <summary>
    /// Refunt transaction model
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class RefundTransaction
    {
        /// <summary>
        /// Transaction title.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// API password.
        /// </summary>
        [DataMember]
        public string Password { get; set; }
    }
}
