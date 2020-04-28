using System;
using System.Collections.Generic;
using System.Text;

namespace TPay.Routes
{
    public class TransactionRoutes : RouteSettings
    {
        public TransactionRoutes(string origin, string apiKey) : base(origin, apiKey)
        {

        }

        public string CreateUrl { get; set; }
        public string BlikUrl { get; set; }
        public string GetUrl { get; set; }
        public string ChargebackUrl { get; set; }
        public string ChargebackAnyUrl { get; set; }
        public string StatusUrl { get; set; }

        public override void SetRoutes()
        {
            CreateUrl = $"{Origin}/api/gw/{ApiKey}/transaction/create";
            BlikUrl = $"{Origin}/api/gw/{ApiKey}/transaction/blik";
            GetUrl = $"{Origin}/api/gw/{ApiKey}/transaction/get";
            ChargebackUrl = $"{Origin}/api/gw/{ApiKey}/chargeback/transaction";
            ChargebackAnyUrl = $"{Origin}/api/gw/{ApiKey}/chargeback/transaction/any";
            StatusUrl = $"{Origin}/api/gw/{ApiKey}/chargeback/chargeback/status";
        }
    }
}
