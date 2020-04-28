using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPay.Models.Transaction.Requests;
using TPay.Models.Transaction.Responsens;

namespace TPay.API
{
    /// <summary>
    /// Contains methods for executing api methods.
    /// </summary>
    public interface ITransactionsApi
    {
        /// <summary>
        /// Allows for payment using Blik.
        /// </summary>
        /// <param name="data">Data required to execute request.</param>
        /// <returns>Response mapped to c# object.</returns>
        Task<BlikResponse> BlikPayment(Blik data);

        /// <summary>
        /// Allows for chargeback money for transaction.
        /// </summary>
        /// <param name="data">Data required to execute request.</param>
        /// <returns>Response mapped to c# object.</returns>
        Task<ChargebackResponse> Chargeback(Chargeback data);

        /// <summary>
        /// Allows for chargeback money for transaction with specified amount.
        /// </summary>
        /// <param name="data">Data required to execute request.</param>
        /// <returns>Response mapped to c# object.</returns>
        Task<ChargebackResponse> ChargebackAny(ChargebackAny data);

        /// <summary>
        /// Allows for creating transaction.
        /// </summary>
        /// <param name="data">Data required to execute request.</param>
        /// <returns>Response mapped to c# object.</returns>
        Task<CreateResponse> Create(Create data);

        /// <summary>
        /// Allows for get information about transaction.
        /// </summary>
        /// <param name="data">Data required to execute request.</param>
        /// <returns>Response mapped to c# object.</returns>
        Task<GetResponse> Get(Get data);

        /// <summary>
        /// Allows get information about chargeback status.
        /// </summary>
        /// <param name="data">Data required to execute request.</param>
        /// <returns>Response mapped to c# object.</returns>
        Task<RefundTransactionRespose> GetChargebackStatus(RefundTransaction data);
    }
}
