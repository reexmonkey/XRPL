using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents the section of data that gets added to a transaction after it is processed.
    /// <para/> Any transaction that gets included in a ledger has metadata, regardless of whether it is successful. The transaction metadata describes the outcome of the transaction in detail.
    /// <para/> The changes described in transaction metadata are only final if the transaction is in a validated ledger version.
    /// </summary>
    public class TransactionMetadata
    {
        public LedgerEntryBase[]? AffectedNodes { get; set; }

        /// <summary>
        /// (May be omitted) For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the delivered_amount field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        public TokenAmount[]? CurrencyAmounts { get; set; }

        /// <summary>
        /// (May be omitted) For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the delivered_amount field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        [JsonPropertyName("DeliveredAmount")]
        public TokenAmount[]? PartialPaymentDeliveredAmount { get; set; }

        /// <summary>
        /// The transaction's position within the ledger that included it. This is zero-indexed. (For example, the value 2 means it was the 3rd transaction in that ledger.)
        /// </summary>
        public uint TransactionIndex { get; set; }

        /// <summary>
        /// A result code indicating whether the transaction succeeded or how it failed.
        /// </summary>
        public string? TransactionResult { get; set; }

        /// <summary>
        /// (Omitted for non-Payment transactions) The [Currency Amount][] actually received by the Destination account. Use this field to determine how much was delivered, regardless of whether the transaction is a partial payment. See this description for details.
        /// </summary>
        [JsonPropertyName("delivered_amount")]
        public TokenAmount? DeliveredAmount { get; set; }
    }
}