using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that creates a <see cref="Check"/> object in the ledger, which is a deferred payment that can be cashed by its intended destination. The sender of this transaction is the sender of the <see cref="Check"/>.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(CheckCreate), typeDiscriminator: nameof(CheckCreate))]
    [JsonDerivedType(typeof(XrpCheckCreate), typeDiscriminator: nameof(XrpCheckCreate))]
    [JsonDerivedType(typeof(FungibleTokenCheckCreate), typeDiscriminator: nameof(FungibleTokenCheckCreate))]
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
        /// Maximum amount of source currency the <see cref="Check"/> is allowed to debit the sender, including transfer fees on non-XRP currencies.
        /// <para/>The <see cref="Check"/> can only credit the destination with the same currency (from the same issuer, for non-XRP currencies). For non-XRP amounts, the nested field names MUST be lower-case.
        /// </summary>
        public object SendMax { get; set; } = null!;

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
    /// Represents a transaction that creates an <see cref="XrpCheck"/> object in the ledger, which is a deferred payment that can be cashed by its intended destination.
    /// <para/>The sender of this transaction is the sender of the <see cref="XrpCheck"/>.
    /// </summary>
    [JsonDerivedType(typeof(XrpCheckCreate), typeDiscriminator: nameof(XrpCheckCreate))]
    public sealed class XrpCheckCreate : CheckCreate
    {
        /// <summary>
        /// Maximum amount of source currency the <see cref="Check"/> is allowed to debit the sender.
        /// <para/>The <see cref="Check"/> can only credit the destination with the same currency.
        /// </summary>
        public new required string SendMax { get => (string)base.SendMax; set => base.SendMax = value; }
    }

    /// <summary>
    /// Represents a transaction that creates an <see cref="FungibleTokenCheck"/> object in the ledger, which is a deferred payment that can be cashed by its intended destination.
    /// <para/>The sender of this transaction is the sender of the <see cref="FungibleTokenCheck"/>.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenCheckCreate), typeDiscriminator: nameof(FungibleTokenCheckCreate))]
    public sealed class FungibleTokenCheckCreate : CheckCreate
    {
        /// <summary>
        /// Maximum amount of source currency the <see cref="Check"/> is allowed to debit the sender, including transfer fees on non-XRP currencies.
        /// <para/>The <see cref="Check"/> can only credit the destination with the same currency (from the same issuer, for non-XRP currencies). 
        /// <para/>For non-XRP amounts, the nested field names MUST be lower-case.
        /// </summary>
        public new required TokenAmount SendMax { get => (TokenAmount)base.SendMax; set => base.SendMax = value; }
    }
}