using System.Text.Json.Serialization;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    /// <summary>
    /// Represents the response to a ledger request, containing the result of the operation.
    /// </summary>
    public record LedgerResponse : Response
    {
        /// <summary>
        /// Gets the result of a <see cref="LedgerResponse"/> request.
        /// </summary>
        [JsonPropertyName("result")]
        public required LedgerResult Result { get; init; }
    }

    /// <summary>
    /// Represents the result of a ledger operation, containing details about the ledger and its state.
    /// </summary>
    public record LedgerResult : Result
    {
        /// <summary>
        /// The complete ledger header data of this ledger, with some additional fields added for convenience.
        /// </summary>
        public required Ledger Ledger { get; init; }

        /// <summary>
        /// The unique identifying hash of the entire ledger, as hexadecimal.
        /// </summary>
        public required string LedgerHash { get; init; }

        /// <summary>
        /// The Ledger Index of this ledger.
        /// </summary>
        public required uint LedgerIndex { get; init; }

        /// <summary>
        /// If true, this is a validated ledger version. If omitted or set to false, this ledger's data is not final.
        /// </summary>
        public bool? Validated { get; init; }

        /// <summary>
        /// Ârray of objects describing queued transactions, in the same order as the queue.
        /// If the request specified expand as true, members contain full representations of the transactions,
        /// in either JSON or binary depending on whether the request specified binary as true.
        /// </summary>
        public QueueTransaction[]? QueueData { get; init; }
    }

    /// <summary>
    /// Represents the complete header data of a ledger.
    /// </summary>
    public record Ledger
    {
        /// <summary>
        /// Hash of all account state information in this ledger, as hexadecimal.
        /// </summary>
        public required string AccountHash { get; init; }

        /// <summary>
        /// A bit-map of flags relating to the closing of this ledger.
        /// </summary>
        public required uint CloseFlags { get; init; }

        /// <summary>
        /// The time this ledger was closed, in seconds since the Ripple Epoch.
        /// </summary>
        public required uint CloseTime { get; init; }

        /// <summary>
        /// The time this ledger was closed, in human-readable format. Always uses the UTC time zone.
        /// </summary>
        public required string CloseTimeHuman { get; init; }

        /// <summary>
        /// The time this ledger was closed, in ISO 8601 format.
        /// </summary>
        public required string CloseTimeIso { get; init; }

        /// <summary>
        /// Ledger close times are rounded to within this many seconds.
        /// </summary>
        public required uint CloseTimeResolution { get; init; }

        /// <summary>
        /// Whether or not this ledger has been closed.
        /// </summary>
        public required bool Current { get; init; }

        /// <summary>
        /// Unique identifying hash of the entire ledger.
        /// </summary>
        public required string LedgerHash { get; init; }

        /// <summary>
        /// The Ledger Index of this ledger.
        /// </summary>
        public required uint LedgerIndex { get; init; }

        /// <summary>
        /// The time at which the previous ledger was closed.
        /// </summary>
        public required uint ParentCloseTime { get; init; }

        /// <summary>
        /// The unique identifying hash of the ledger that came immediately before this one, as hexadecimal.
        /// </summary>
        public required string ParentHash { get; init; }

        /// <summary>
        /// Total number of XRP drops in the network, as a quoted integer. (This decreases as transaction costs destroy XRP.)
        /// </summary>
        public required string TotalCoins { get; init; }

        /// <summary>
        /// Hash of the transaction information included in this ledger.
        /// </summary>
        public required string TransactionHash { get; init; }

        /// <summary>
        /// Transactions applied in this ledger version. By default, members are the transactions' identifying Hash strings.
        /// If the request specified expand as true, members are full representations of the transactions instead,
        /// in either JSON or binary depending on whether the request specified binary as true.
        /// </summary>
        public Transaction[]? Transactions { get; init; }
    }

    /// <summary>
    /// Represents a transaction in the queue.
    public abstract record QueueTransaction
    {
        /// <summary>
        /// The Address of the sender for this queued transaction.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// How many times this transaction can be retried before being dropped.
        /// </summary>
        public required uint RetriesRemaining { get; init; }

        /// <summary>
        /// The tentative result from preliminary transaction checking. This is always tesSUCCESS.
        /// </summary>
        public required string PreflightResult { get; init; }

        /// <summary>
        /// If this transaction was left in the queue after getting a retriable (ter) result, this is the exact ter result code it got.
        /// </summary>
        public string? LastResult { get; init; }

        /// <summary>
        /// Whether this transaction changes this address's ways of authorizing transactions.
        /// </summary>
        public bool? AuthChange { get; init; }

        /// <summary>
        /// The Transaction Cost of this transaction, in drops of XRP.
        /// </summary>
        public string? Fee { get; init; }

        /// <summary>
        /// The transaction cost of this transaction, relative to the minimum cost for this type of transaction, in fee levels.
        /// </summary>
        public string? FeeLevel { get; init; }

        /// <summary>
        /// The maximum amount of XRP, in drops, this transaction could potentially send or destroy.
        /// </summary>
        public string? MaxSpendDrops { get; init; }
    }

    /// <summary>
    /// Represents a binary transaction in a queue.
    /// </summary>
    public record BinaryQueueTransaction : QueueTransaction
    {
        /// <summary>
        /// Unique hashed string containing the binary form of the transaction as a decimal string.
        /// </summary>
        [JsonPropertyName("tx_blob")]
        public required string Tx { get; set; }
    }

    /// <summary>
    /// Represents a JSON transaction in a queue.
    /// </summary>
    public record JsonQueueTransaction : QueueTransaction
    {
        /// <summary>
        ///  An object containing the transaction object including the transaction's identifying hash in the hash field.
        /// </summary>
        [JsonPropertyName("tx")]
        public required Transaction Tx { get; set; }
    }
}
