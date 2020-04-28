using System;
using System.Collections.Generic;
using System.Text;

namespace TPay.Models.Transaction.ViewModels
{
    /// <summary>
    /// Data required for get access to Tpay.com api
    /// </summary>
    public class TransactionCredentials
    {
        /// <summary>
        /// Merchant ID in Tpay.com system.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Merchant security code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A unique string generated in Merchant Panel in Settings->API tab.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// API password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Auxiliary parameter to identify the transaction on the merchant side. We do recommend to encode your crc value in base64. The exact value of crc used to create transaction will be returned in tpay payment notification as tr_crc parameter.
        /// </summary>
        public string CRC { get; set; }
    }
}
