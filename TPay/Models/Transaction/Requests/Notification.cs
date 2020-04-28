using System;
using System.Collections.Generic;
using System.Text;

namespace TPay.Models.Transaction.Requests
{
    public class Notification
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Alias { get; set; }
        public DateTime Tr_Date { get; set; }
        public string Tr_Crc { get; set; }
        public decimal Tr_Amount { get; set; }
        public decimal Tr_Paid { get; set; }
        public string Tr_Desc { get; set; }
        public string Tr_Status { get; set; }
        public string Tr_Error { get; set; }
        public string Tr_Email { get; set; }
        public string MD5SUM { get; set; }
        public bool TestMode { get; set; }
        public string Wallet { get; set; }
        public string Masterpass { get; set; }
    }
}
