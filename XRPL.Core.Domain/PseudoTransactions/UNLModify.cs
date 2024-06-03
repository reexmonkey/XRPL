using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.PseudoTransactions
{
    /// <summary>
    /// Represents a pseudo-transaction that marks a change to the Negative UNL, indicating that a trusted validator has gone offline or come back online.
    /// </summary>
    [JsonDerivedType(typeof(UNLModify), typeDiscriminator: nameof(UNLModify))]
    public class UNLModify : PseudoTransaction
    {
        /// <summary>
        /// The ledger index where this pseudo-transaction appears. This distinguishes the pseudo-transaction from other occurrences of the same change.
        /// </summary>
        public required uint LedgerSequence { get; set; }

        /// <summary>
        /// If 1, this change represents adding a validator to the Negative UNL.
        /// If 0, this change represents removing a validator from the Negative UNL. (No other values are allowed.)
        /// </summary>
        public required uint UNLModifyDisabling { get; set; }

        /// <summary>
        /// The validator to add or remove, as identified by its master public key.
        /// </summary>
        public required string UNLModifyValidator { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UNLModify"/> class.
        /// </summary>
        public UNLModify() : base(PseudoTransactionType.UNLModify)
        {
        }
    }
}
