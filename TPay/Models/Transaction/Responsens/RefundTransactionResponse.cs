using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TPay.Models.Enums;
using TPay.Models.Transaction.Requests;

namespace TPay.Models.Transaction.Responsens
{
    /// <summary>
    /// Refund transaction response model.
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class RefundTransactionRespose
    {
        /// <summary>
        /// Request result.
        /// </summary>
        [DataMember]
        public Result Result { get; set; }

        /// <summary>
        /// Chargebacks associated to transaction.
        /// </summary>
        [DataMember]
        public ICollection<ChargebackStatus> Chargebacks { get; set; }

        /// <summary>
        /// Error code.
        /// </summary>
        [DataMember]
        public TransactionErrorCodes? Err { get; set; }
    }
}
