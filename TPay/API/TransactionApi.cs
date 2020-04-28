using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPay.Helpers;
using TPay.Models.Enums;
using TPay.Models.Transaction.Requests;
using TPay.Models.Transaction.Responsens;
using TPay.Models.Validators;

namespace TPay.API
{

    /// <summary>
    /// <see cref="ITransactionsApi"/>
    /// </summary>
    public class TransactionApi : ITransactionsApi
    {
        // private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private string _create = "CreateUrl";
        private string _blik = "BlikUrl";
        private string _chargeback = "ChargebackUrl";
        private string _chargebackAny = "ChargebackAny";
        private string _get = "GetUrl";
        private string _refund = "StatusUrl";
        private IDictionary<string, string> _routes;

        public TransactionApi(IDictionary<string, string> routes)
        {
            _routes = routes;
        }

        public async Task<BlikResponse> BlikPayment(Blik data)
        {
            var validator = new BlikValidator();
            var validResult = validator.Validate(data);

            if (validResult.IsValid)
            {
                var url = _routes[_blik];
                var sender = new Sender<Blik, BlikResponse>();
                var result = await sender.Post(data, url);

                if (result != null)
                {
                    //if (result.Err != null)
                    //{
                    //    LogResultError(url, result.Err);
                    //}
                }
                else
                {
                    // Logger.Error("Could't recive data. Check internet connection.");
                }

                return result;
            }
            else
            {
                var errors = validResult.Errors;
                LogErrors(errors);
            }

            return null;
        }

        public async Task<ChargebackResponse> Chargeback(Chargeback data)
        {
            var validator = new ChargebackValidator();
            var validResult = validator.Validate(data);

            if (validResult.IsValid)
            {
                var url = _routes[_chargeback];
                var sender = new Sender<Chargeback, ChargebackResponse>();
                var result = await sender.Post(data, url);
                if (result != null)
                {
                    //if (result.Err != null)
                    //{
                    //    LogResultError(url, result.Err);
                    //}
                }
                else
                {
                    // Logger.Error("Could't recive data. Check internet connection.");
                }

                return result;
            }
            else
            {
                var errors = validResult.Errors;
                LogErrors(errors);
            }

            return null;
        }

        public async Task<ChargebackResponse> ChargebackAny(ChargebackAny data)
        {
            //Get transaction amount to ensure you will not chargeback more money than transaction amount 
            var getResponse = await Get(new Get { Title = data.Title, ApiPassword = data.ApiPassword });
            var transactionAmount = getResponse.Amount;

            var validator = new ChargebackAnyValidator(transactionAmount);
            var validResult = validator.Validate(data);

            if (validResult.IsValid)
            {
                var url = _routes[_chargebackAny];
                var sender = new Sender<ChargebackAny, ChargebackResponse>();
                var result = await sender.Post(data, url);
                if (result != null)
                {
                    //if (result.Err != null)
                    //{
                    //    LogResultError(url, result.Err);
                    //}
                }
                else
                {
                    // Logger.Error("Could't recive data. Check internet connection.");
                }

                return result;
            }
            else
            {
                var errors = validResult.Errors;
                LogErrors(errors);
            }

            return null;
        }

        public async Task<CreateResponse> Create(Create data)
        {
            var validator = new CreateValidator();
            var validResult = validator.Validate(data);

            if (validResult.IsValid)
            {
                var url = _routes[_create];
                var sender = new Sender<Create, CreateResponse>();
                var result = await sender.Post(data, url);
                if (result != null)
                {
                    //if (result.Err != null)
                    //{
                    //    LogResultError(url, result.Err);
                    //}
                }
                else
                {
                    // Logger.Error("Could't recive data. Check internet connection.");
                }

                return result;
            }
            else
            {
                var errors = validResult.Errors;
                LogErrors(errors);

            }

            return null;
        }

        public async Task<GetResponse> Get(Get data)
        {
            var validator = new GetValidator();
            var validResult = validator.Validate(data);

            if (validResult.IsValid)
            {
                var url = _routes[_get];
                var sender = new Sender<Get, GetResponse>();
                var result = await sender.Post(data, url);
                if (result != null)
                {
                    //if (result.Err != null)
                    //{
                    //    LogResultError(url, result.Err);
                    //}
                }
                else
                {
                    // Logger.Error("Could't recive data. Check internet connection.");
                }

                return result;
            }
            else
            {
                var errors = validResult.Errors;
                LogErrors(errors);
            }

            return null;
        }

        public async Task<RefundTransactionRespose> GetChargebackStatus(RefundTransaction data)
        {

            var url = _routes[_refund];

            var sender = new Sender<RefundTransaction, RefundTransactionRespose>();
            return await sender.Post(data, url); ;
        }

        private void LogErrors(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                //Logger.Error(error.ErrorMessage);
            }
        }

        private void LogResultError(string url, TransactionErrorCodes? err)
        {
            var errorDescriptor = new ErrorDescriptor();
            //Logger.Error("Error from {url}: {error}", url, errorDescriptor.GetErrorInfo(err));
        }
    }
}
