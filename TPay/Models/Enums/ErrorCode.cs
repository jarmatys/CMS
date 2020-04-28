using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TPay.Models.Enums
{
    public enum ErrorCode
    {
        /// <summary>
        /// Enum None for value: none
        /// </summary>
        [EnumMember(Value = "none")]
        None = 1,

        /// <summary>
        /// Enum Overpay for value: overpay
        /// </summary>
        [EnumMember(Value = "overpay")]
        Overpay = 2,

        /// <summary>
        /// Enum Surcharge for value: surcharge
        /// </summary>
        [EnumMember(Value = "surcharge")]
        Surcharge = 3

    }
}
