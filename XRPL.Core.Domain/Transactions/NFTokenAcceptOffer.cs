using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that is used to accept offers to buy or sell an <see cref="NFToken"/>.
    /// This mode allow two distinct offers, one offering to buy a given <see cref="NFToken"/>
    /// and the other offering to sell the same <see cref="NFToken"/>, to be accepted in an atomic fashion.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(BrokeredModeNFTokenAcceptOffer), typeDiscriminator: nameof(BrokeredModeNFTokenAcceptOffer))]
    [JsonDerivedType(typeof(XrpBrokeredModeNFTokenAcceptOffer), typeDiscriminator: nameof(XrpBrokeredModeNFTokenAcceptOffer))]
    [JsonDerivedType(typeof(FungibleTokenBrokeredModeNFTokenAcceptOffer), typeDiscriminator: nameof(FungibleTokenBrokeredModeNFTokenAcceptOffer))]
    [JsonDerivedType(typeof(DirectModeNFTokenBuyOffer), typeDiscriminator: nameof(DirectModeNFTokenBuyOffer))]
    [JsonDerivedType(typeof(DirectModeNFTokenSellOffer), typeDiscriminator: nameof(DirectModeNFTokenSellOffer))]
    public abstract class BrokeredModeNFTokenAcceptOffer : Transaction
    {
        /// <summary>
        /// (Optional) Identifies the NFTokenOffer that offers to sell the NFToken.
        /// </summary>
        public required string NFTokenSellOffer { get; set; }

        /// <summary>
        /// (Optional) Identifies the NFTokenOffer that offers to buy the NFToken.
        /// </summary>
        public required string NFTokenBuyOffer { get; set; }

        /// <summary>
        /// (Optional) This field is only valid in brokered mode, and specifies the amount that the broker keeps as part of their fee for bringing the two offers together; the remaining amount is sent to the seller of the NFToken being bought.
        /// <para/>If specified, the fee must be such that, before applying the transfer fee, the amount that the seller would receive is at least as much as the amount indicated in the sell offer.
        /// </summary>
        public object NFTokenBrokerFee { get; set; } = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrokeredModeNFTokenAcceptOffer"/> class.
        /// </summary>
        protected BrokeredModeNFTokenAcceptOffer() : base(TransactionType.NFTokenAcceptOffer)
        {
        }
    }

    /// <summary>
    /// Represents a transaction that is used to accept offers to buy or sell an <see cref="NFToken"/>.
    /// This mode allow two distinct offers, one offering to buy a given <see cref="NFToken"/>
    /// and the other offering to sell the same <see cref="NFToken"/>, to be accepted in an atomic fashion.
    /// </summary>
    [JsonDerivedType(typeof(XrpBrokeredModeNFTokenAcceptOffer), typeDiscriminator: nameof(XrpBrokeredModeNFTokenAcceptOffer))]
    public sealed class XrpBrokeredModeNFTokenAcceptOffer : BrokeredModeNFTokenAcceptOffer
    {
        /// <summary>
        /// This field is only valid in brokered mode, and specifies the amount that the broker keeps as part of their fee for bringing the two offers together;
        /// the remaining amount is sent to the seller of the NFToken being bought.
        /// <para/>If specified, the fee must be such that, before applying the transfer fee,
        /// the amount that the seller would receive is at least as much as the amount indicated in the sell offer.
        /// </summary>
        public new required string NFTokenBrokerFee { get; set; }
    }

    /// <summary>
    /// Represents a transaction that is used to accept offers to buy or sell an <see cref="NFToken"/>.
    /// This mode allow two distinct offers, one offering to buy a given <see cref="NFToken"/>
    /// and the other offering to sell the same <see cref="NFToken"/>, to be accepted in an atomic fashion.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenBrokeredModeNFTokenAcceptOffer), typeDiscriminator: nameof(FungibleTokenBrokeredModeNFTokenAcceptOffer))]
    public sealed class FungibleTokenBrokeredModeNFTokenAcceptOffer : BrokeredModeNFTokenAcceptOffer
    {
        /// <summary>
        /// This field is only valid in brokered mode,
        /// and specifies the amount that the broker keeps as part of their fee for bringing the two offers together;
        /// the remaining amount is sent to the seller of the NFToken being bought.
        /// <para/>If specified, the fee must be such that, before applying the transfer fee,
        /// the amount that the seller would receive is at least as much as the amount indicated in the sell offer.
        /// </summary>
        public new required TokenAmount NFTokenBrokerFee { get; set; }
    }

    /// <summary>
    /// Represents a transaction that is used to accept offers to buy an <see cref="NFToken"/>.
    /// </summary>
    [JsonDerivedType(typeof(DirectModeNFTokenBuyOffer), typeDiscriminator: nameof(DirectModeNFTokenBuyOffer))]
    public class DirectModeNFTokenBuyOffer : Transaction
    {
        /// <summary>
        /// (Optional) Identifies the NFTokenOffer that offers to buy the NFToken.
        /// </summary>
        public required string NFTokenBuyOffer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectModeNFTokenBuyOffer"/> class.
        /// </summary>
        public DirectModeNFTokenBuyOffer() : base(TransactionType.NFTokenAcceptOffer)
        {
        }
    }

    /// <summary>
    /// Represents a transaction that is used to accept offers to sell an <see cref="NFToken"/>.
    /// </summary>
    [JsonDerivedType(typeof(DirectModeNFTokenSellOffer), typeDiscriminator: nameof(DirectModeNFTokenSellOffer))]
    public class DirectModeNFTokenSellOffer : Transaction
    {
        /// <summary>
        /// (Optional) Identifies the NFTokenOffer that offers to sell the NFToken.
        /// </summary>
        public required string NFTokenSellOffer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectModeNFTokenSellOffer"/> class.
        /// </summary>
        public DirectModeNFTokenSellOffer() : base(TransactionType.NFTokenAcceptOffer)
        {
        }
    }
}
