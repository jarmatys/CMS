using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TPay.Models.Transaction.Requests
{
    /// <summary>
    /// Chargeback status model
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ChargebackStatus
    {
        /// <summary>
        /// Chargeback title in Tpay.com system.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Chargeback creation time.
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Refunded amount
        /// </summary>
        [DataMember]
        public float Amount { get; set; }

        /// <summary>
        /// <see cref="ChargebackStatus"/>
        /// </summary>
        [DataMember]
        public ChargebackStatus Status { get; set; }
    }
}
