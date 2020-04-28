using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TPay.Models.Enums;

namespace TPay.Models.Transaction.Requests
{
    /// <summary>
    /// Create model
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Create
    {
        /// <summary>
        /// Merchant ID in Tpay.com system.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// <see cref="AcceptTos"/>
        /// </summary>
        [DataMember]
        public AcceptTos AcceptTos { get; set; }

        /// <summary>
        /// API password.
        /// </summary>
        [DataMember]
        public string ApiPassword { get; set; }

        /// <summary>
        /// <see cref="Online"/>
        /// </summary>
        [DataMember]
        public Online Online { get; set; }

        /// <summary>
        /// Transaction group number see the "id" element in https://secure.tpay.com/groups-{id}0.js . For example https://secure.tpay.com/groups-10100.js or https://secure.tpay.com/groups-10100.js?json
        /// </summary>
        [DataMember]
        public byte Group { get; set; }

        /// <summary>
        /// Transaction amount. Please always send the amount with two decimal places like 10.00.
        /// </summary>
        [DataMember]
        public string Amount { get; set; }

        /// <summary>
        /// Transaction description.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Auxiliary parameter to identify the transaction on the merchant side. We do recommend to encode your crc value in base64. The exact value of crc used to create transaction will be returned in tpay payment notification as tr_crc parameter.
        /// </summary>
        [DataMember]
        public string CRC { get; set; }

        /// <summary>
        /// Merchant endpoint for payment notification.
        /// </summary>
        [DataMember]
        public string ResultUrl { get; set; }

        /// <summary>
        /// Email address where notification after payment will be sent (overrides defined in merchant panel). You can add more addresses by comma concatenation.
        /// </summary>
        [DataMember]
        public string ResultEmail { get; set; }

        /// <summary>
        /// Name of merchant displayed in transaction panel (overrides defined in merchant panel).
        /// </summary>
        [DataMember]
        public string MerchantDescription { get; set; }

        /// <summary>
        /// Additional info to be displayed in transaction panel (overrides defined in merchant panel).
        /// </summary>
        [DataMember]
        public string CustomDescription { get; set; }

        /// <summary>
        /// Url to redirect customer in case of payment success.
        /// </summary>
        [DataMember]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Url to redirect customer in case of payment failure.
        /// </summary>
        [DataMember]
        public string ReturnErrorUrl { get; set; }

        /// <summary>
        /// <see cref="Language"/>
        /// </summary>
        [DataMember]
        public Language Language { get; set; }

        /// <summary>
        /// Customer email.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Customer name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Customer address (parameter is empty if this field was not send with create method).
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Customer city (parameter is empty if this field was not send with create method).
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Customer postal code (parameter is empty if this field was not send with create method).
        /// </summary>
        [DataMember]
        public string Zip { get; set; }

        /// <summary>
        /// Two letters - see ISO 3166-1 document
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Customer phone number (parameter is empty if this field was not send with create method).
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Maximum transaction payment date.
        /// </summary>
        [DataMember]
        public string ExprationDate { get; set; }

        /// <summary>
        /// Parameter protects expiration_date from unauthorized changes.
        /// </summary>
        [DataMember]
        public string TimeHash { get; set; }

        /// <summary>
        /// Md5 sum calculated from id.amount.crc.security_code where dots means concatenation (security code can be found in merchant panel).
        /// </summary>
        [DataMember]
        public string Md5sum { get; set; }
    }
}
