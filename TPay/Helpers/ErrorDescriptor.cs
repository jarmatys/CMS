using System;
using System.Collections.Generic;
using System.Text;
using TPay.Models.Enums;

namespace TPay.Helpers
{
    public class ErrorDescriptor
    {
        public string GetErrorInfo(TransactionErrorCodes? errorCode)
        {
            switch (errorCode)
            {
                case TransactionErrorCodes.ERR31:
                    return "Access disabled";
                case TransactionErrorCodes.ERR32:
                    return "Access denied (via Merchant Panel settings)";
                case TransactionErrorCodes.ERR41:
                    return "Cannot create refund for this payment channel";
                case TransactionErrorCodes.ERR42:
                    return "Invalid refund amount";
                case TransactionErrorCodes.ERR43:
                    return "Insufficient funds to create refund";
                case TransactionErrorCodes.ERR44:
                    return "Incorrect transaction title";
                case TransactionErrorCodes.ERR45:
                    return "Refund amount is too high";
                case TransactionErrorCodes.ERR51:
                    return "Cannot create transaction for this channel";
                case TransactionErrorCodes.ERR52:
                    return "Error while creating transaction, try again later";
                case TransactionErrorCodes.ERR53:
                    return "Input data error";
                case TransactionErrorCodes.ERR54:
                    return "No such transaction";
                case TransactionErrorCodes.ERR55:
                    return "Incorrect date format or value";
                case TransactionErrorCodes.ERR61:
                    return "Invalid BLIK code or alias data format";
                case TransactionErrorCodes.ERR62:
                    return "Error connecting BLIK system";
                case TransactionErrorCodes.ERR63:
                    return "Invalid BLIK six-digit code";
                case TransactionErrorCodes.ERR64:
                    return "Can not pay with BLIK code or alias for non BLIK transaction" +
                           "Transaction was not created with BLIK(150) group parameter";
                case TransactionErrorCodes.ERR65:
                    return "Incorrect transaction status - should be pending";
                case TransactionErrorCodes.ERR66:
                    return "BLIK POS is not available. Try to send type parameter 0 - web purchase";
                case TransactionErrorCodes.ERR82:
                    return "Given alias is non-unique";
                case TransactionErrorCodes.ERR84:
                    return "Given alias has not been registered or has been deregistered";
                case TransactionErrorCodes.ERR85:
                    return "Given alias section is incorrect. See BLIK examples section to check correct parameters set.";
                case TransactionErrorCodes.ERR96:
                    return "Cannot create refund for this payment channel";
                case TransactionErrorCodes.ERR97:
                    return "No such method";
                case TransactionErrorCodes.ERR98:
                    return "Authorisation error (wrong api_key or api_password)";
                case TransactionErrorCodes.ERR99:
                    return "General error";
                default: return $"Can not resolve this code";
            }

        }
    }
}
