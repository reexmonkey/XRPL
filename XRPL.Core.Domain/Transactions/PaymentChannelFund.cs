using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that adds additional XRP to an open payment channel, and optionally update the expiration time of the channel.
    /// <para/>Only the source address of the channel can use this transaction.
    /// </summary>
    public class PaymentChannelFund : Transaction
    {
        /// <summary>
        /// The unique ID of the channel to fund, as a 64-character hexadecimal string.
        /// </summary>
        public required uint Channel { get; set; }

        /// <summary>
        /// Amount of XRP, in drops to add to the channel. 
        /// <para/>Must be a positive amount of XRP.
        /// </summary>
        public required string Amount { get; set; }

        /// <summary>
        /// (Optional) New Expiration time to set for the channel, in seconds since the Ripple Epoch.
        /// <para/>This must be later than either the current time plus the SettleDelay of the channel, or the existing Expiration of the channel.
        /// After the Expiration time, any transaction that would access the channel closes the channel without taking its normal action.
        /// Any unspent XRP is returned to the source address when the channel closes.
        /// (Expiration is separate from the channel's immutable CancelAfter time.)
        /// For more information, see the <see cref="PayChannel"/> ledger object type.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentChannelClaim"/> class.
        /// </summary>
        public PaymentChannelFund() : base(TransactionType.PaymentChannelClaim)
        {
        }
    }
}