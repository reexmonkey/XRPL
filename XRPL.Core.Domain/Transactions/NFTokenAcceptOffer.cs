using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that is used to accept offers to buy or sell an <see cref="NFToken"/>. It can either:
    /// <para/> Allow one offer to be accepted. This is called direct mode.
    /// <para/> - Allow two distinct offers, one offering to buy a given <see cref="NFToken"/> and the other offering to sell the same <see cref="NFToken"/>, to be accepted in an atomic fashion. This is called brokered mode.
    /// </summary>
    public class NFTokenAcceptOffer : Transaction
    {
        /// <summary>
        /// (Optional) Identifies the NFTokenOffer that offers to sell the NFToken.
        /// </summary>
        public string? NFTokenSellOffer { get; set; }

        /// <summary>
        /// (Optional) Identifies the NFTokenOffer that offers to buy the NFToken.
        /// </summary>
        public string? NFTokenBuyOffer { get; set; }

        /// <summary>
        /// (Optional) This field is only valid in brokered mode, and specifies the amount that the broker keeps as part of their fee for bringing the two offers together; the remaining amount is sent to the seller of the NFToken being bought.
        /// <para/>If specified, the fee must be such that, before applying the transfer fee, the amount that the seller would receive is at least as much as the amount indicated in the sell offer.
        /// </summary>
        public TokenAmount? NFTokenBrokerFee { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTokenAcceptOffer"/> class.
        /// </summary>
        public NFTokenAcceptOffer() : base(TransactionType.NFTokenAcceptOffer)
        {
        }
    }
}