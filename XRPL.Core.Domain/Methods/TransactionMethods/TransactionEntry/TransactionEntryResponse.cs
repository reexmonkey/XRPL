using System.Text.Json.Serialization;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.Methods.TransactionMethods.TransactionEntry
{
    /// <summary>
    /// Represents a response to a submit response.
    /// </summary>

    public class TransactionEntryResponse : ResponseBase<TransactionEntryResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="TransactionEntryResponse"/> object.
    /// </summary>

    public class TransactionEntryResult : ResultBase
    {
        /// <summary>
        /// The ledger index of the ledger version the transaction was found in; this is the same as the one from the request.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public uint LedgerIndex { get; set; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger version the transaction was found in; this is the same as the one from the request.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The transaction metadata, which shows the exact results of the transaction in detail.
        /// </summary>
        [JsonPropertyName("metadata")]
        public TransactionMetadata? Metadata { get; set; }

        /// <summary>
        /// JSON representation of the Transaction object
        /// </summary>
        [JsonPropertyName("tx_json")]
        public Transaction? TxJson { get; set; }
    }
}
