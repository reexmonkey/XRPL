using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that accepts an offer to buy or sell a non-fungible token (NFT).
    /// </summary>
    public abstract class NFTokenAcceptOffer : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrokeredModeNFTokenAcceptOffer"/> class.
        /// </summary>
        protected NFTokenAcceptOffer() : base(TransactionType.NFTokenAcceptOffer)
        {
        }
    }

    /// <summary>
    /// Represents a transaction that accepts an offer to buy or sell a non-fungible token (NFT) in brokered mode,
    /// in which a third party (the broker) can match two distinct offers,
    /// one buying and one selling.
    /// If the buy price is higher than the sell price, the broker can claim the difference as a fee for themself.
    /// </summary>
    public class BrokeredNFTokenAcceptOffer : NFTokenAcceptOffer
    {
        /// <summary>
        /// (Optional) Identifies the <see cref="NFTokenOffer"/> that offers to sell the <see cref="NFToken"/>.
        /// </summary>
        public required string NFTokenSellOffer { get; set; }

        /// <summary>
        /// (Optional) Identifies the <see cref="NFTokenOffer"/>  that offers to buy the <see cref="NFToken"/>.
        /// </summary>
        public required string NFTokenBuyOffer { get; set; }

        /// <summary>
        /// The amount that the broker keeps as their fee for bringing the two offers together; the remaining amount is sent to the seller of the NFT.
        /// If specified, the fee must be such that, before applying the transfer fee, the amount that the seller would receive is at least as much as the amount indicated in the sell offer.
        /// </summary>
        public CurrencyAmount? NFTokenBrokerFee { get; set; }
    }

    /// <summary>
    /// Represents a transaction that accepts an offer to buy or sell a non-fungible token (NFT) in direct mode,
    /// a buyer can accept a sell offer directly, or a seller can accept a buy offer directly.
    /// <para/>you must specify either the <see cref="NFTokenSellOffer"/> or the <see cref="NFTokenBuyOffer"/> field.
    /// </summary>
    public class DirectNFTokenAcceptOffer : NFTokenAcceptOffer
    {
        /// <summary>
        /// (Optional) Identifies the <see cref="NFTokenOffer"/> that offers to sell the <see cref="NFToken"/>.
        /// </summary>
        public string? NFTokenSellOffer { get; set; }

        /// <summary>
        /// (Optional) Identifies the <see cref="NFTokenOffer"/>  that offers to buy the <see cref="NFToken"/>.
        /// </summary>
        public string? NFTokenBuyOffer { get; set; }
    }

    [JsonSerializable(typeof(BrokeredNFTokenAcceptOffer))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class BrokeredNFTokenAcceptOfferContext : JsonSerializerContext
    {
    }
}