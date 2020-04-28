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
    /// Get response model.
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class GetResponse
    {
        /// <summary>
        /// Api call result.
        /// </summary>
        [DataMember]
        public Result Result { get; set; }


        /// <summary>
        /// <see cref="Status"/>
        /// </summary>
        [DataMember]
        public Status? Status { get; set; }


        /// <summary>
        /// Depending on setting in merchant panel, error_code may be different than none for correct status, when acceptance of overpays and surcharges has been set.
        /// </summary>
        [DataMember]
        public ErrorCode? ErrorCode { get; set; }


        /// <summary>
        /// Transaction creation time.
        /// </summary>
        [DataMember]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Date of payment or empty for pending transactions.
        /// </summary>
        [DataMember]
        public DateTime? PaymentTime { get; set; }

        /// <summary>
        /// Date of payment refund or empty for not refunded transactions.
        /// </summary>
        [DataMember]
        public DateTime? ChargebackTime { get; set; }

        /// <summary>
        /// Payment channel ID can be recognised in merchant panel (your offer section).
        /// </summary>
        [DataMember]
        public int Channel { get; set; }

        /// <summary>
        /// Returns 1 if transaction was in test mode.
        /// </summary>
        [DataMember]
        public int TestMode { get; set; }

        /// <summary>
        /// Transaction amount casted to float.
        /// </summary>
        [DataMember]
        public float Amount { get; set; }

        /// <summary>
        /// The amount paid by customer.
        /// </summary>
        [DataMember]
        public float AmouuntPaid { get; set; }

        /// <summary>
        /// Customer name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Customer email.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Customer address (parameter is empty if this field was.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Customer postal code (parameter is empty if this field was not send with create method).
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Customer city (parameter is empty if this field was not send with create method).
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Customer phone number (parameter is empty if this field was not send with create method).
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Two letters - see ISO 3166-1 document.
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Error code.
        /// </summary>
        [DataMember]
        public TransactionErrorCodes? Err { get; set; }

    }
}
