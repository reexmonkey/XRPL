using System.Text.Json.Serialization;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.Methods.JsonRpc.TransactionMethods
{
    /// <summary>
    /// Represents a response to a submit response.
    /// </summary>
    public record TransactionEntryResponse : Response
    {
        [JsonPropertyName("result")]
        public required TransactionEntryResult Result { get; init; }
    }

    /// <summary>
    /// Represents a result of an <see cref="TransactionEntryResponse"/> object.
    /// </summary>
    public record TransactionEntryResult : Result
    {
        /// <summary>
        /// The ledger index of the ledger version the transaction was found in; this is the same as the one from the request.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public required uint LedgerIndex { get; init; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger version the transaction was found in; this is the same as the one from the request.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The transaction metadata, which shows the exact results of the transaction in detail.
        /// </summary>
        [JsonPropertyName("metadata")]
        public required TransactionMetadata Metadata { get; init; }

        /// <summary>
        /// JSON representation of the Transaction object
        /// </summary>
        [JsonPropertyName("tx_json")]
        public required Transaction TxJson { get; init; }
    }
}