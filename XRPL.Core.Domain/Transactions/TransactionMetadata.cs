using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies the section of data that gets added to a transaction after it is processed.
    /// <para/>Any transaction that gets included in a ledger has metadata, regardless of whether it is successful.
    /// The transaction metadata describes the outcome of the transaction in detail.
    /// <para/> The changes described in transaction metadata are only final if the transaction is in a validated ledger version.
    /// </summary>
    public abstract class TransactionMetadata
    {
        /// <summary>
        /// List of ledger entries that were created, deleted, or modified by this transaction, and specific changes to each.
        /// </summary>
        public required LedgerEntryBase[] AffectedNodes { get; set; }

        /// <summary>
        /// (May be omitted) For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the <see cref="DeliveredAmount"/> field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        [JsonPropertyName("DeliveredAmount")]
        public object[]? PaymentDeliveredAmounts { get; set; }

        /// <summary>
        /// The transaction's position within the ledger that included it.
        /// This is zero-indexed. (For example, the value 2 means it was the 3rd transaction in that ledger.)
        /// </summary>
        public uint TransactionIndex { get; set; }

        /// <summary>
        /// A result code indicating whether the transaction succeeded or how it failed.
        /// </summary>
        public string? TransactionResult { get; set; }

        /// <summary>
        /// (Omitted for non-Payment transactions) The [Currency Amount][] actually received by the Destination account.
        /// <para/>Use this field to determine how much was delivered, regardless of whether the transaction is a partial payment.
        /// </summary>
        [JsonPropertyName("delivered_amount")]
        public object[]? DeliveredAmount { get; set; }
    }

    /// <summary>
    /// Represents the section of data that gets added to a transaction after it is processed.
    /// <para/>Any transaction that gets included in a ledger has metadata, regardless of whether it is successful.
    /// The transaction metadata describes the outcome of the transaction in detail.
    /// <para/> The changes described in transaction metadata are only final if the transaction is in a validated ledger version.
    /// </summary>
    public class XrpTransactionMetadata : TransactionMetadata
    {
        /// <summary>
        /// (May be omitted) For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the <see cref="DeliveredAmount"/> field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        [JsonPropertyName("DeliveredAmount")]
        public new string[]? PaymentDeliveredAmounts
        {
            get
            {
                if (base.PaymentDeliveredAmounts == null) return null;
                var amounts = new string[base.PaymentDeliveredAmounts.Length];
                base.PaymentDeliveredAmounts.CopyTo(amounts, 0);
                return amounts;
            }
            set
            {
                if (value == null) base.PaymentDeliveredAmounts = null;
                else
                {
                    base.PaymentDeliveredAmounts = new string[value.Length];
                    value.CopyTo(base.PaymentDeliveredAmounts, 0);
                }
            }
        }

        /// <summary>
        /// (Omitted for non-Payment transactions) The [Currency Amount][] actually received by the Destination account.
        /// <para/>Use this field to determine how much was delivered, regardless of whether the transaction is a partial payment.
        /// </summary>
        [JsonPropertyName("delivered_amount")]
        public new string[]? DeliveredAmount
        {
            get
            {
                if (base.DeliveredAmount == null) return null;
                var amounts = new string[base.DeliveredAmount.Length];
                base.DeliveredAmount.CopyTo(amounts, 0);
                return amounts;
            }
            set
            {
                if (value == null) base.DeliveredAmount = null;
                else
                {
                    base.DeliveredAmount = new string[value.Length];
                    value.CopyTo(base.DeliveredAmount, 0);
                }
            }
        }
    }

    /// <summary>
    /// Represents the section of data that gets added to a transaction after it is processed.
    /// <para/>Any transaction that gets included in a ledger has metadata, regardless of whether it is successful.
    /// The transaction metadata describes the outcome of the transaction in detail.
    /// <para/> The changes described in transaction metadata are only final if the transaction is in a validated ledger version.
    /// </summary>
    public class FungibleTokenTransactionMetadata : TransactionMetadata
    {
        /// <summary>
        /// (May be omitted) For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the <see cref="DeliveredAmount"/> field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        [JsonPropertyName("DeliveredAmount")]
        public new TokenAmount[]? PaymentDeliveredAmounts
        {
            get
            {
                if (base.PaymentDeliveredAmounts == null) return null;
                var amounts = new TokenAmount[base.PaymentDeliveredAmounts.Length];
                base.PaymentDeliveredAmounts.CopyTo(amounts, 0);
                return amounts;
            }
            set
            {
                if (value == null) base.PaymentDeliveredAmounts = null;
                else
                {
                    base.PaymentDeliveredAmounts = new TokenAmount[value.Length];
                    value.CopyTo(base.PaymentDeliveredAmounts, 0);
                }
            }
        }

        /// <summary>
        /// (Omitted for non-Payment transactions) The [Currency Amount][] actually received by the Destination account.
        /// <para/>Use this field to determine how much was delivered, regardless of whether the transaction is a partial payment.
        /// </summary>
        [JsonPropertyName("delivered_amount")]
        public new TokenAmount[]? DeliveredAmount
        {
            get
            {
                if (base.DeliveredAmount == null) return null;
                var amounts = new TokenAmount[base.DeliveredAmount.Length];
                base.DeliveredAmount.CopyTo(amounts, 0);
                return amounts;
            }
            set
            {
                if (value == null) base.DeliveredAmount = null;
                else
                {
                    base.DeliveredAmount = new string[value.Length];
                    value.CopyTo(base.DeliveredAmount, 0);
                }
            }
        }
    }
}
