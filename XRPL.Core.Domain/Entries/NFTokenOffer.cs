using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents an offer to buy, sell or transfer an NFT.
    /// </summary>
    public abstract class NFTokenOffer : LedgerEntryBase
    {
        /// <summary>
        /// Amount expected or offered for the NFToken.
        /// <para/>If the token has the lsfOnlyXRP flag set, the amount must be specified in XRP.
        /// Sell offers that specify assets other than XRP must specify a non-zero amount.
        /// Sell offers that specify XRP can be 'free' (that is, the Amount field can be equal to "0").
        /// </summary>
        public object Amount { get; set; } = null!;

        /// <summary>
        /// The AccountID for which this offer is intended. If present, only that account can accept the offer.
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// The time after which the offer is no longer active.
        /// <para/>The value is the number of seconds since the Ripple Epoch.
        /// </summary>
        public uint Expiration { get; set; }

        /// <summary>
        /// The NFTokenID of the NFToken object referenced by this offer.
        /// </summary>
        public required string NFTokenID { get; set; }

        /// <summary>
        /// Internal bookkeeping, indicating the page inside the token buy or sell offer directory, as appropriate, where this token is being tracked.
        /// <para/>This field allows the efficient deletion of offers.
        /// </summary>
        public string? NFTokenOfferNode { get; set; }

        /// <summary>
        /// Owner of the account that is creating and owns the offer.
        /// <para/> Only the current Owner of an NFToken can create an offer to sell an NFToken, but any account can create an offer to buy an NFToken.
        /// </summary>
        public required string Owner { get; set; }

        /// <summary>
        /// Internal bookkeeping, indicating the page inside the owner directory where this token is being tracked.
        /// <para/>This field allows the efficient deletion of offers.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// Identifying hash of the transaction that most recently modified this object.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// Index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTokenOffer"/> class.
        /// </summary>
        protected NFTokenOffer()
        {
            Flags = 1u;
            LedgerEntryType = "NFTokenOffer";
        }
    }

    /// <summary>
    /// Represents an offer to buy, sell or transfer an NFT with an amount of XRPs.
    /// </summary>
    public sealed class XrpForNFTokenOffer : NFTokenOffer
    {
        /// <summary>
        /// Amount expected or offered for the NFToken.
        /// <para/>If the token has the lsfOnlyXRP flag set, the amount must be specified in XRP.
        /// Sell offers that specify assets other than XRP must specify a non-zero amount.
        /// </summary>
        public new required string Amount { get => (string)base.Amount; set => base.Amount = value; }
    }

    /// <summary>
    /// Represents an offer to buy, sell or transfer an NFT with an amount of tokens.
    /// </summary>
    public sealed class FungibleTokenForNFTokenOffer : NFTokenOffer
    {
        /// <summary>
        /// Amount expected or offered for the NFToken.
        /// <para/>If the token has the lsfOnlyXRP flag set, the amount must be specified in XRP.
        /// Sell offers that specify XRP can be 'free' (that is, the Amount field can be equal to "0").
        /// </summary>
        public new required TokenAmount Amount { get => (TokenAmount)base.Amount; set => base.Amount = value; }
    }

    /// <summary>
    /// Represents a flag for a non-fungible token offer.
    /// </summary>
    public enum NFTokenOfferFlags : uint
    {
        /// <summary>
        /// If enabled, the offer is a sell offer. Otherwise, the offer is a buy offer.
        /// </summary>
        lsfSellNFToken = 0x00000001
    }
}
