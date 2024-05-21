using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that creates a <see cref="Check"/> object in the ledger, which is a deferred payment that can be cashed by its intended destination. The sender of this transaction is the sender of the <see cref="Check"/>.
    /// </summary>
    public abstract class CheckCreate : Transaction
    {
        /// <summary>
        /// The ID of the <see cref="Check"/> ledger object to cash, as a 64-character hexadecimal string.
        /// </summary>
        public required string Destination { get; set; }

        /// <summary>
        /// (Optional) Arbitrary tag that identifies the reason for the <see cref="Check"/>, or a hosted recipient to pay.
        /// </summary>
        public uint? DestinationTag { get; set; }

        /// <summary>
        /// (Optional) Time after which the <see cref="Check"/> is no longer valid, in seconds since the Ripple Epoch.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// (Optional) Arbitrary 256-bit hash representing a specific reason or identifier for this <see cref="Check"/>.
        /// </summary>
        public string? InvoiceID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckCreate"/> class.
        /// </summary>
        protected CheckCreate() : base(TransactionType.CheckCreate)
        {
        }
    }

    /// <summary>
    /// Specifies a transaction that creates a <see cref="Check{TAmount}"/> object in the ledger, which is a deferred payment that can be cashed by its intended destination.
    /// <para/>The sender of this transaction is the sender of the <see cref="Check{TAmount}"/>.
    /// </summary>
    /// <typeparam name="TAmount">The type of currency amount.</typeparam>
    public abstract class CheckCreate<TAmount> : CheckCreate
        where TAmount : class
    {
        /// <summary>
        /// Maximum amount of source currency the <see cref="Check{TAmount}"/> is allowed to debit the sender, including transfer fees on non-XRP currencies.
        /// <para/>The <see cref="Check{TAmount}"/> can only credit the destination with the same currency (from the same issuer, for non-XRP currencies). For non-XRP amounts, the nested field names MUST be lower-case.
        /// </summary>
        public required TAmount SendMax { get; set; }
    }

    /// <summary>
    /// Represents a transaction that creates an <see cref="XrpCheck"/> object in the ledger, which is a deferred payment that can be cashed by its intended destination.
    /// <para/>The sender of this transaction is the sender of the <see cref="XrpCheck"/>.
    /// </summary>
    public sealed class XrpCheckCreate : CheckCreate<string>
    {
    }

    /// <summary>
    /// Represents a transaction that creates an <see cref="FungibleTokenCheck"/> object in the ledger, which is a deferred payment that can be cashed by its intended destination.
    /// <para/>The sender of this transaction is the sender of the <see cref="FungibleTokenCheck"/>.
    /// </summary>
    public sealed class TokenCheckCreate : CheckCreate<TokenAmount>
    {
    }
}