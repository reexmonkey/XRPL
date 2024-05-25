using System.Runtime.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to a transaction method request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    [DataContract]
    public class HashTxResponse : ResponseBase<HashTxResult>
    {
    }

    /// <summary>
    /// Represents a response to a transaction method request that retrieves information on a single transaction, by its identifying CTID.
    /// </summary>
    [DataContract]
    public class CtidTxResponse : ResponseBase<CtidTxResult>
    {
    }

    /// <summary>
    /// Specifies a result of a transaction response object.
    /// </summary>
    [DataContract]
    public abstract class TxResult : ResultBase
    {
        /// <summary>
        /// If true, return transaction data and metadata as binary serialized to hexadecimal strings. If false, return transaction data and metadata as JSON.
        /// <para/>The default is false.
        /// </summary>
        [JsonPropertyName("binary")]
        public bool Binary { get; set; }

        /// <summary>
        /// Use this with max_ledger to specify a range of up to 1000 ledger indexes, starting with this ledger (inclusive).
        /// <para/>If the server cannot find the transaction, it confirms whether it was able to search all the ledgers in this range.
        /// </summary>
        [JsonPropertyName("min_ledger")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// Use this with min_ledger to specify a range of up to 1000 ledger indexes, ending with this ledger (inclusive).
        /// <para/>If the server cannot find the transaction, it confirms whether it was able to search all the ledgers in the requested range.
        /// </summary>
        [JsonPropertyName("max_ledger")]
        public TransactionMetadata? MaxLedger { get; set; }
    }

    /// <summary>
    /// Represents a <see cref="TxResult"/> with a 256-bit hash of the transaction.
    /// </summary>
    public sealed class HashTxResult : TxResult
    {
        /// <summary>
        /// The 256-bit hash of the transaction to look up, as hexadecimal.
        /// </summary>
        [JsonPropertyName("transaction")]
        public string? Transaction { get; set; }
    }

    /// <summary>
    /// Represents a <see cref="TxResult"/> with a compact transaction identifier of the transaction.
    /// </summary>
    [DataContract]
    public sealed class CtidTxResult : TxResult
    {
        /// <summary>
        /// The compact transaction identifier of the transaction to look up.
        /// <para/>Must use uppercase hexadecimal only.
        /// </summary>
        [JsonPropertyName("ctid")]
        public string? Ctid { get; set; }
    }
}