using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TPay.Models.Enums;

namespace TPay.Models.Transaction.Responsens
{
    /// <summary>
    /// Create response model
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CreateResponse
    {
        /// <summary>
        /// Api call result.
        /// </summary>
        public Result Result { get; set; }

        /// <summary>
        /// Error code.
        /// </summary>
        [DataMember]
        public TransactionErrorCodes? Err { get; set; }

        /// <summary>
        /// Transaction title.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Transaction amount casted to float.
        /// </summary>
        [DataMember]
        public float Amount { get; set; }

        /// <summary>
        /// Bank account number (only for manual bank transfers).
        /// </summary>
        [DataMember]
        public int AccountNumer { get; set; }

        /// <summary>
        /// Booking payments online indicator.
        /// </summary>
        [DataMember]
        public Online Online { get; set; }

        /// <summary>
        /// Link to transaction (for redirecting to payment).
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// Optional field, contains names of invalid fields.
        /// </summary>
        [DataMember]
        public string Desc { get; set; }
    }
}
