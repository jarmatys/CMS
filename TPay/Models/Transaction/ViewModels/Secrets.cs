using System;
using System.Collections.Generic;
using System.Text;

namespace TPay.Models.Transaction.ViewModels
{
    /// <summary>
    /// Hashed data.
    /// </summary>
    public class Secrets
    {
        /// <summary>
        /// Merchant ID in Tpay.com system.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Auxiliary parameter to identify the transaction on the merchant side. We do recommend to encode your crc value in base64. The exact value of crc used to create transaction will be returned in tpay payment notification as tr_crc parameter.
        /// </summary>
        public string CRC { get; set; }

        /// <summary>
        /// md5 sum calculated from id.amount.crc.security_code where dots means concatenation (security code can be found in merchant panel).
        /// </summary>
        public string Md5sum { get; set; }

        /// <summary>
        /// Parameter protects expiration_date from unauthorized changes.
        /// </summary>
        public string TimeHash { get; set; }

        /// <summary>
        /// API password. 
        /// </summary>
        public string Password { get; set; }
    }
}
