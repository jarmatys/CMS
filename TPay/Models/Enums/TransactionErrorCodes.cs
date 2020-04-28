using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace TPay.Models.Enums
{
    /// <summary>
    /// Error codes enum
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionErrorCodes
    {
        /// <summary>
        /// Enum ERR99 for value: ERR99
        /// </summary>
        [EnumMember(Value = "ERR99")]
        ERR99 = 1,

        /// <summary>
        /// Enum ERR98 for value: ERR98
        /// </summary>
        [EnumMember(Value = "ERR98")]
        ERR98 = 2,

        /// <summary>
        /// Enum ERR97 for value: ERR97
        /// </summary>
        [EnumMember(Value = "ERR97")]
        ERR97 = 3,

        /// <summary>
        /// Enum ERR96 for value: ERR96
        /// </summary>
        [EnumMember(Value = "ERR96")]
        ERR96 = 4,

        /// <summary>
        /// Enum ERR85 for value: ERR85
        /// </summary>
        [EnumMember(Value = "ERR85")]
        ERR85 = 5,

        /// <summary>
        /// Enum ERR84 for value: ERR84
        /// </summary>
        [EnumMember(Value = "ERR84")]
        ERR84 = 6,

        /// <summary>
        /// Enum ERR82 for value: ERR82
        /// </summary>
        [EnumMember(Value = "ERR82")]
        ERR82 = 7,

        /// <summary>
        /// Enum ERR63 for value: ERR63
        /// </summary>
        [EnumMember(Value = "ERR63")]
        ERR63 = 8,

        /// <summary>
        /// Enum ERR62 for value: ERR62
        /// </summary>
        [EnumMember(Value = "ERR62")]
        ERR62 = 9,

        /// <summary>
        /// Enum ERR61 for value: ERR61
        /// </summary>
        [EnumMember(Value = "ERR61")]
        ERR61 = 10,

        /// <summary>
        /// Enum ERR55 for value: ERR55
        /// </summary>
        [EnumMember(Value = "ERR55")]
        ERR55 = 11,

        /// <summary>
        /// Enum ERR54 for value: ERR54
        /// </summary>
        [EnumMember(Value = "ERR54")]
        ERR54 = 12,

        /// <summary>
        /// Enum ERR53 for value: ERR53
        /// </summary>
        [EnumMember(Value = "ERR53")]
        ERR53 = 13,

        /// <summary>
        /// Enum ERR52 for value: ERR52
        /// </summary>
        [EnumMember(Value = "ERR52")]
        ERR52 = 14,

        /// <summary>
        /// Enum ERR51 for value: ERR51
        /// </summary>
        [EnumMember(Value = "ERR51")]
        ERR51 = 15,

        /// <summary>
        /// Enum ERR45 for value: ERR45
        /// </summary>
        [EnumMember(Value = "ERR45")]
        ERR45 = 16,

        /// <summary>
        /// Enum ERR44 for value: ERR44
        /// </summary>
        [EnumMember(Value = "ERR44")]
        ERR44 = 17,

        /// <summary>
        /// Enum ERR43 for value: ERR43
        /// </summary>
        [EnumMember(Value = "ERR43")]
        ERR43 = 18,

        /// <summary>
        /// Enum ERR42 for value: ERR42
        /// </summary>
        [EnumMember(Value = "ERR42")]
        ERR42 = 19,

        /// <summary>
        /// Enum ERR41 for value: ERR41
        /// </summary>
        [EnumMember(Value = "ERR41")]
        ERR41 = 20,

        /// <summary>
        /// Enum ERR32 for value: ERR32
        /// </summary>
        [EnumMember(Value = "ERR32")]
        ERR32 = 21,

        /// <summary>
        /// Enum ERR31 for value: ERR31
        /// </summary>
        [EnumMember(Value = "ERR31")]
        ERR31 = 22,

        /// <summary>
        /// Enum ERR64 for value: ERR64
        /// </summary>
        [EnumMember(Value = "ERR64")]
        ERR64 = 23,

        /// <summary>
        /// Enum ERR65 for value: ERR65
        /// </summary>
        [EnumMember(Value = "ERR65")]
        ERR65 = 24,

        /// <summary>
        /// Enum ERR66 for value: ERR66
        /// </summary>
        [EnumMember(Value = "ERR66")]
        ERR66 = 25
    }
}

