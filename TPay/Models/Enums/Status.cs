using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TPay.Models.Enums
{
    public enum Status
    {
        /// <summary>
        /// Enum Correct for value: correct
        /// </summary>
        [EnumMember(Value = "correct")]
        Correct = 1,

        /// <summary>
        /// Enum Paid for value: paid
        /// </summary>
        [EnumMember(Value = "paid")]
        Paid = 2,

        /// <summary>
        /// Enum Pending for value: pending
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending = 3,

        /// <summary>
        /// Enum Error for value: error
        /// </summary>
        [EnumMember(Value = "error")]
        Error = 4,

        /// <summary>
        /// Enum Chargeback for value: chargeback
        /// </summary>
        [EnumMember(Value = "chargeback")]
        Chargeback = 5

    }
}
