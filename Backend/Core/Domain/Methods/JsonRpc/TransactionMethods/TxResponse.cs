using System.Text.Json.Serialization;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.Methods.JsonRpc.TransactionMethods
{
    /// <summary>
    /// Represents a response to a transaction method request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    public record HashJsonTxResponse : ResponseBase<HashJsonTxResult>
    {
    }

    /// <summary>
    /// Represents a response to a transaction method request that retrieves information on a single transaction, by its identifying CTID.
    /// </summary>
    public record CtidJsonTxResponse : ResponseBase<CtidJsonTxResult>
    {
    }

    /// <summary>
    /// Represents a response to a transaction method request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    public record HashBinaryTxResponse : ResponseBase<HashBinaryTxResult>
    {
    }

    /// <summary>
    /// Represents a response to a transaction method request that retrieves information on a single transaction, by its identifying CTID.
    /// </summary>
    public record CtidBinaryTxResponse : ResponseBase<CtidBinaryTxResult>
    {
    }

    /// <summary>
    /// Specifies a result of a transaction response object.
    /// </summary>
    public abstract record TxResult : Result
    {
        /// <summary>
        /// The close time of the ledger in which the transaction was applied, in seconds since the Ripple Epoch.
        /// </summary>
        [JsonPropertyName("date")]
        public uint Date { get; init; }

        /// <summary>
        /// The ledger index of the ledger that includes this transaction.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public required string LedgerIndex { get; init; }

        /// <summary>
        /// Transaction metadata, which describes the results of the transaction.
        /// </summary>
        [JsonPropertyName("meta")]
        public object Meta { get; init; } = null!;

        /// <summary>
        /// If true, this data comes from a validated ledger version; if omitted or set to false, this data is not fi
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; init; }
    }

    /// <summary>
    /// Specifies a result of a transaction response object where the transaction metadata is a JSON object.
    /// </summary>
    public abstract record JsonTxResult : TxResult
    {
        /// <summary>
        /// Transaction metadata, which describes the results of the transaction.
        /// </summary>
        [JsonPropertyName("meta")]
        public new required TransactionMetadata Meta { get => (TransactionMetadata)base.Meta; set => base.Meta = value; }
    }

    /// <summary>
    /// Specifies a result of a transaction response object where the transaction metadata is a binary string.
    /// </summary>
    public abstract record BinaryTxResult : TxResult
    {
        /// <summary>
        /// Transaction metadata, which describes the results of the transaction.
        /// </summary>
        [JsonPropertyName("meta")]
        public new required string Meta { get => (string)base.Meta; set => base.Meta = value; }
    }

    /// <summary>
    /// Represents a <see cref="TxResult"/> with a compact transaction identifier of the transaction and a JSON-based transaction metadata.
    /// </summary>
    public sealed record CtidJsonTxResult : JsonTxResult
    {
        /// <summary>
        /// The compact transaction identifier of the transaction to look up.
        /// <para/>Must use uppercase hexadecimal only.
        /// </summary>
        [JsonPropertyName("ctid")]
        public required string Ctid { get; init; }
    }

    /// <summary>
    /// Represents a <see cref="TxResult"/> with a 256-bit hash of the transaction and a JSON-based transaction metadata.
    /// </summary>
    public sealed record HashJsonTxResult : JsonTxResult
    {
        /// <summary>
        /// The 256-bit hash of the transaction to look up, as hexadecimal.
        /// </summary>
        [JsonPropertyName("transaction")]
        public required string Transaction { get; init; }
    }

    /// <summary>
    /// Represents a <see cref="TxResult"/> with a compact transaction identifier of the transaction and a binary transaction metadata.
    /// </summary>
    public sealed record CtidBinaryTxResult : BinaryTxResult
    {
        /// <summary>
        /// The compact transaction identifier of the transaction to look up.
        /// <para/>Must use uppercase hexadecimal only.
        /// </summary>
        [JsonPropertyName("ctid")]
        public required string Ctid { get; init; }
    }

    /// <summary>
    /// Represents a <see cref="TxResult"/> with a 256-bit hash of the transaction and a binary transaction metadata.
    /// </summary>
    public sealed record HashBinaryTxResult : BinaryTxResult
    {
        /// <summary>
        /// The 256-bit hash of the transaction to look up, as hexadecimal.
        /// </summary>
        [JsonPropertyName("transaction")]
        public required string Transaction { get; init; }
    }
}