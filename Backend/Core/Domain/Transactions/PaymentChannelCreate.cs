using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    public class PaymentChannelCreate : Transaction
    {
        /// <summary>
        /// Amount of XRP, in drops, to deduct from the sender's balance and set aside in this channel.
        /// While the channel is open, the XRP can only go to the Destination address.
        /// When the channel closes, any unclaimed XRP is returned to the source account's balance.
        /// </summary>
        public required XRPAmount Amount { get; set; }

        /// <summary>
        /// The account that can receive money from this channel. This is also known as the "destination address" for the channel. Cannot be the same as the sender (Account).
        /// </summary>
        public required string Destination { get; set; }

        /// <summary>
        /// Amount of time, in seconds, the source address must wait before closing the channel if it has unclaimed funds.
        /// </summary>
        public required uint SettleDelay { get; set; }

        /// <summary>
        /// The 33-byte public key of the key pair the source will use to sign claims against this channel. This can be any secp256k1 or Ed25519 public key.
        /// </summary>
        public required string PublicKey { get; set; }

        /// <summary>
        /// The time, in seconds since the Ripple Epoch, when this channel expires.
        /// Any transaction that would modify the channel after this time closes the channel without otherwise affecting it.
        /// This value is immutable; the channel can be closed earlier than this time but cannot remain open after this time.
        /// </summary>
        public uint? CancelAfter { get; set; }

        /// <summary>
        /// Arbitrary tag to further specify the destination for this payment channel, such as a hosted recipient at the destination address.
        /// </summary>
        public string? DestinationTag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentChannelCreate"/> class.
        /// </summary>
        public PaymentChannelCreate() : base(TransactionType.PaymentChannelCreate)
        {
        }
    }
}
