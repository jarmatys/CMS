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
    /// Report response model.
    /// </summary>
    [DataContract]
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ReportResponse
    {
        /// <summary>
        /// Api call result.
        /// </summary>
        [DataMember]
        public Result Result { get; set; }

        /// <summary>
        /// Report content encoded in base64. Characters encoding is UTF8. After decoding the report you will get:
        /// (header[NL], empty line[NL], columns description[NL], transactions list, each in new line, where[NL] is a new line indicator): Summary of transactions and refunds sorted by dates
        /// LP;Transaction ID; Transaction amount; Paid amount; commission %;flat commission; commission taken; Transaction CRC; Transaction description; Payment date; Refund date; E-mail;Customer name; Address;Postal code; City;Country;Phone;Additional description(Acquirer (Elavon / eService));RRN(Acquirer (Elavon / eService))
        /// Columns are separated by; (semicolon).
        /// </summary>
        [DataMember]
        public string Report { get; set; }

        /// <summary>
        /// ErrorCode.
        /// </summary>
        [DataMember]
        public TransactionErrorCodes Err { get; set; }
    }
}
