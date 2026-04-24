using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XRPL.Core.Domain
{
    /// <summary>
    /// Represents the header information for a ledger.
    /// <para/>Every ledger version has a unique header that describes the contents. 
    /// You can look up a ledger's header information with the ledger method.
    /// </summary>
    public record LedgerHeader
    {
        /// <summary>
        /// The ledger index of the ledger. Some API methods display this as a quoted integer; some display it as a native JSON number.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public required string LedgerIndex { get; init; }

        /// <summary>
        /// The SHA-512Half of this ledger version. This serves as a unique identifier for this ledger and all its contents.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public required string LedgerHash { get; init; }

        /// <summary>
        /// The SHA-512Half of this ledger's state tree information.
        /// </summary>
        [JsonPropertyName("account_hash")]
        public required string AccountHash { get; init; }

        /// <summary>
        /// A bit-map of flags relating to the closing of this ledger.
        /// </summary>
        [JsonPropertyName("close_flags")]
        public required uint CloseFlags { get; init; }

        /// <summary>
        /// The approximate time this ledger version closed, as the number of seconds since the Ripple Epoch of 2000-01-01 00:00:00 UTC.
        /// This value is rounded based on the close_time_resolution.
        /// </summary>
        [JsonPropertyName("close_time")]
        public required uint CloseTime { get; init; }

        /// <summary>
        /// An integer in the range [2,120] indicating the maximum number of seconds by which the close_time could be rounded.
        /// </summary>
        [JsonPropertyName("close_time_resolution")]
        public required uint CloseTimeResolution { get; init; }

        /// <summary>
        /// If true, this ledger version is no longer accepting new transactions.
        /// (However, unless this ledger version is validated, it might be replaced by a different ledger version with a different set of transactions.)
        /// </summary>
        [JsonPropertyName("closed")]
        public required bool Closed { get; init; }

        /// <summary>
        /// The ledger_hash value of the previous ledger version that is the direct predecessor of this one.
        /// If there are different versions of the previous ledger index, this indicates from which one the ledger was derived.
        /// </summary>
        [JsonPropertyName("parent_hash")]
        public required string ParentHash { get; init; }

        /// <summary>
        /// The total number of drops of XRP owned by accounts in the ledger. This omits XRP that has been destroyed by transaction fees.
        /// The actual amount of XRP in circulation is lower because some accounts are "black holes" whose keys are not known by anyone.
        /// </summary>
        [JsonPropertyName("total_coins")]
        public required string TotalCoins { get; init; }

        /// <summary>
        /// The SHA-512Half of the transactions included in this ledger.
        /// </summary>
        [JsonPropertyName("transaction_hash")]
        public required string TransactionHash { get; init; }
    }
}
