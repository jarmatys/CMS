using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPay.API;
using TPay.Helpers.Implementations;
using TPay.Models.Transaction.Requests;
using TPay.Models.Transaction.Responsens;
using TPay.Models.Transaction.ViewModels;

namespace TPay.Logic
{
    /// <summary>
    /// This class provides methods for handling TPay transaction method.
    /// </summary>
    public class Transaction
    {
        // private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private ITransactionsApi _api;
        private TransactionCredentials _credentials;

        /// <summary>
        /// Date format used in Tpay system. It's important for hashing reasons.
        /// </summary>
        public string DateTimeFormat = "yyyy:MM:dd:HH:MM";

        /// <summary>
        /// Allows for chargeback money with possibility to set amount.
        /// </summary>
        public bool AllowChargebackAny { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction" /> class.
        /// </summary>
        /// <param name="credentials">Provides data required to get access to api.</param>
        /// <param name="api">Provides methods for executing api requests.</param>
        public Transaction(TransactionCredentials credentials, ITransactionsApi api)
        {
            _api = api;
            _credentials = credentials;
        }

        /// <summary>
        /// This method allows you to prepare transaction for customer.
        /// </summary>
        /// <param name="model">Provides data required to create transaction</param>
        /// <returns>Response from api mapped to c# object. Includes data required to execute other methods</returns>
        public async Task<CreateResponse> CreateTransaction(CreateData model)
        {
            #region hashing
            //Hash is required for seurity reason. "md5sum" is mandatory. "timeHash" will be set if date will be set.
            var hashCalculator = new HashCalculator();
            var md5Sum = hashCalculator.Md5Sum(_credentials.Id.ToString(), model.Amount.ToString("0.00").Replace(",", "."), _credentials.CRC, _credentials.Code);
            string timeHash = null;
            if (model.ExpirationDate != null)
            {
                timeHash = hashCalculator.TimeHash(model.ExpirationDate.Value.ToString(DateTimeFormat), _credentials.Code);
            }
            #endregion

            var secrets = new Secrets
            {
                Md5sum = md5Sum,
                TimeHash = timeHash,
                CRC = _credentials.CRC,
                Id = _credentials.Id,
                Password = _credentials.Password
            };

            return await _api.Create(new Create
            {
                Id = secrets.Id,
                CRC = secrets.CRC,
                TimeHash = secrets.TimeHash,
                Md5sum = secrets.Md5sum,
                ApiPassword = secrets.Password,
                AcceptTos = model.AcceptTos,
                Address = model.Address,
                Amount = model.Amount.ToString("0.00").Replace(",", "."),
                City = model.City,
                Country = model.Country,
                CustomDescription = model.CustomDescription,
                Description = model.Description,
                Email = model.Email,
                ExprationDate = model.ExpirationDate != null ? model.ExpirationDate.Value.ToString(DateTimeFormat) : null,
                Group = model.Group,
                Language = model.Language,
                MerchantDescription = model.MerchantDescription,
                Name = model.Name,
                Online = model.Online,
                Phone = model.Phone,
                ResultEmail = model.ResultEmail,
                ResultUrl = model.ResultUrl,
                ReturnErrorUrl = model.ReturnErrorUrl,
                ReturnUrl = model.ReturnUrl,
                Zip = model.Zip,
            });
        }

        /// <summary>
        /// Allows for payment using Blik.
        /// </summary>
        /// <param name="model">Provides transaction data for which payment will be executing.</param>
        /// <param name="code">6 digits code provided by Blik system.</param>
        /// <returns>Response from api mapped to c# object.</returns>
        public async Task<BlikResponse> PayUsingBlik(CreateResponse model, int code)
        {
            if (model != null)
            {

                return await _api.BlikPayment(new Blik
                {
                    Code = code,
                    Title = model.Title,
                    ApiPassword = _credentials.Password,
                });
            }

            return null;

        }

        /// <summary>
        /// Allows to get information about transaction.
        /// </summary>
        /// <param name="model">Provides transaction information required to get more information.</param>
        /// <returns>Response from api mapped to c# object.</returns>
        public async Task<GetResponse> Get(CreateResponse model)
        {
            if (model != null)
            {
                return await _api.Get(new Get { Title = model.Title, ApiPassword = _credentials.Password });
            }

            return null;
        }

        /// <summary>
        /// Allows for payment using OneClick. If alias is registered, code is not required.
        /// </summary>
        /// <param name="model">Provides transaction data for which payment will be executing.</param>
        /// <param name="alias">Mandatory field when creating oneClick transactions, optional for standart Blik transactions with 6 digit code. In case of alias registration attempt you can send only 1 alias per 1 request.</param>
        /// <param name="code">6 digits code provided by Blik system.</param>
        /// <returns>Response from api mapped to c# object.</returns>
        public async Task<BlikResponse> PayUsingBlik(CreateResponse model, Alias alias, int? code = null)
        {
            if (model != null)
            {
                return await _api.BlikPayment(new Blik
                {
                    Code = code,
                    Title = model.Title,
                    ApiPassword = _credentials.Password,
                    Alias = alias
                });
            }

            return null;
        }

        /// <summary>
        /// Allows for chargeback money for transaction.
        /// </summary>
        /// <param name="model">Provides transaction information.</param>
        /// <returns>Response from api mapped to c# object.</returns>
        public async Task<ChargebackResponse> Chargeback(CreateResponse model)
        {
            if (model != null)
            {
                return await _api.Chargeback(new Chargeback
                {
                    Title = model.Title,
                    ApiPassword = _credentials.Password
                });
            }

            return null;
        }

        /// <summary>
        /// Allows for chargeback money for transaction. You can decide how much you want to chargeback.
        /// </summary>
        /// <param name="model">Provides transaction information.</param>
        /// <param name="amount">Chargeback amount  </param>
        /// <returns>Response from api mapped to c# object.</returns>
        /// <remarks>This option is disabled by default. Set <see cref="AllowChargebackAny"/> as true to enable.</remarks>
        public async Task<ChargebackResponse> ChargebackAny(CreateResponse model, float amount)
        {
            if (AllowChargebackAny && model != null)
            {
                return await _api.ChargebackAny(new ChargebackAny
                {
                    Title = model.Title,
                    ApiPassword = _credentials.Password,
                    ChargebackAmount = amount.ToString("0.00").Replace(",", ".")

                });
            }

            return null;
        }

        /// <summary>
        /// Allow to get information about chargeback status
        /// </summary>
        /// <param name="model">Provides transaction information.</param>
        /// <returns>Response from api mapped to c# object.</returns>
        public async Task<RefundTransactionRespose> GetChargebackStatus(CreateResponse model)
        {
            if (model != null)
            {
                return await _api.GetChargebackStatus(new RefundTransaction
                {
                    Title = model.Title,
                    Password = _credentials.Password
                });
            }

            return null;
        }
    }
}
