using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TPay.Models.Transaction.Requests
{
    /// <summary>
    /// Blik model
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Blik
    {
        /// <summary>Transaction title.</summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>6 digit code generated in customer bank mobile app (required if customer does not have registered alias or when customer does not want to pay by regietered device). BLIK code contains only digits but can start with zero or multiple zeroes, so you must not cast this variable to int.</summary>
        [DataMember]
        public int? Code { get; set; }

        /// <summary>API password.</summary>
        [DataMember]
        public string ApiPassword { get; set; }

        /// <summary>
        /// Mandatory field when creating oneClick transactions, optional for standart Blik transactions with 6 digit code. In case of alias registration attempt you can send only 1 alias per 1 request.
        /// </summary>
        [DataMember]
        public Alias Alias { get; set; }

        /// <summary>
        /// Transaction type. 0 - WEB mode (default value). 1 - POS mode dedicated for payment terminals Can be 0 or 1
        /// </summary>
        [DataMember]
        public Type Type { get; set; }
    }
}
