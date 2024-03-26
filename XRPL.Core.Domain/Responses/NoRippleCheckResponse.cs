using System.Runtime.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response that encapsulates a list of validated transactions that involve a given account.
    /// </summary>
    [DataContract]
    public class NoRippleCheckResponse : ResponseBase<NoRippleCheckResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="NoRippleCheckResponse"/> object.
    /// </summary>
    [DataContract]
    [KnownType(typeof(BinaryAccountTransaction))]
    [KnownType(typeof(JsonAccountTransaction))]
    public class NoRippleCheckResult : ResultBase
    {
        /// <summary>
        /// The ledger index of the ledger used to calculate these results.
        /// </summary>
        [DataMember(Name = "ledger_current_index")]
        public int LedgerCurrentIndex { get; set; }

        /// <summary>
        /// Array of strings with human-readable descriptions of the problems.
        /// <para/>This includes up to one entry if the account's Default Ripple setting is not as recommended, plus up to limit entries for trust lines whose No Ripple setting is not as recommended.
        /// </summary>
        [DataMember(Name = "problems")]
        public string[]? Problems { get; set; }

        /// <summary>
        /// (May be omitted) If the request specified transactions as true, this is an array of JSON objects, each of which is the JSON form of a transaction that should fix one of the described problems.
        /// <para/>The length of this array is the same as the problems array, and each entry is intended to fix the problem described at the same index into that array.
        /// </summary>
        [DataMember(Name = "transactions")]
        public Transaction[]? Transactions { get; set; }
    }
}