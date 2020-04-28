using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TPay.Models.Transaction.Requests
{
    /// <summary>
    /// Report model
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Report
    {
        /// <summary>
        /// Start range of generated report.
        /// </summary>
        [DataMember]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// End range of generated report.
        /// </summary>
        [DataMember]
        public DateTime ToDate { get; set; }

        /// <summary>
        /// API password.
        /// </summary>
        [DataMember]
        public string ApiPassword { get; set; }
    }
}
