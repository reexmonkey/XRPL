using System.Runtime.Serialization;
using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents the section of data that gets added to a transaction after it is processed.
    /// <para/> Any transaction that gets included in a ledger has metadata, regardless of whether it is successful. The transaction metadata describes the outcome of the transaction in detail.
    /// <para/> The changes described in transaction metadata are only final if the transaction is in a validated ledger version.
    /// </summary>
    [KnownType(typeof(AccountRoot))]
    [KnownType(typeof(AMM))]
    [KnownType(typeof(Ammendments))]
    [KnownType(typeof(Bridge))]
    [KnownType(typeof(TokenCheck))]
    [KnownType(typeof(XrpCheck))]
    [KnownType(typeof(DepositPreauth))]
    [KnownType(typeof(DID))]
    [KnownType(typeof(DirectoryNode))]
    [KnownType(typeof(Escrow))]
    [KnownType(typeof(FeeSettings))]
    [KnownType(typeof(LedgerHashes))]
    [KnownType(typeof(NegativeUNL))]
    [KnownType(typeof(XrpForNFTokenOffer))]
    [KnownType(typeof(CurrencyAmountForNFTokenOffer))]
    [KnownType(typeof(NFTokenPage))]
    [KnownType(typeof(XrpForCurrencyAmountOffer))]
    [KnownType(typeof(CurrencyAmountForXrpOffer))]
    [KnownType(typeof(CurrencyAmountForCurrencyAmountOffer))]
    [KnownType(typeof(PayChannel))]
    [KnownType(typeof(RippleState))]
    [KnownType(typeof(SignerList))]
    [KnownType(typeof(Ticket))]
    [KnownType(typeof(XRPXChainOwnedClaimID))]
    [KnownType(typeof(CurrencyAmountXChainOwnedClaimID))]
    [KnownType(typeof(XrpXChainOwnedCreateAccountClaimID))]
    [KnownType(typeof(CurrencyAmountXChainOwnedCreateAccountClaimID))]
    public class TransactionMetadata
    {
        public LedgerEntryBase[]? AffectedNodes { get; set; }

        /// <summary>
        /// (May be omitted) For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the delivered_amount field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        public Token[]? CurrencyAmounts { get; set; }

        /// <summary>
        /// (May be omitted) For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the delivered_amount field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        [DataMember(Name = "DeliveredAmount")]
        public Token[]? PartialPaymentDeliveredAmount { get; set; }

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
        [DataMember(Name = "delivered_amount")]
        public Token? DeliveredAmount { get; set; }
    }
}