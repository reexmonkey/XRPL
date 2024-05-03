using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that claims XRP from a payment channel, adjust the payment channel's expiration, or both.
    /// <para/>This transaction can be used differently depending on the transaction sender's role in the specified channel:
    /// <para/>The source address of a channel can:
    /// <para/>- Send XRP from the channel to the destination with or without a signed Claim.
    /// <para/>- Set the channel to expire as soon as the channel's SettleDelay has passed.
    /// <para/>- Clear a pending Expiration time.
    /// <para/>- Close a channel immediately, with or without processing a claim first. The source address cannot close the channel immediately if the channel has XRP remaining.
    /// <para/>The destination address of a channel can:
    /// <para/>- Receive XRP from the channel using a signed Claim.
    /// <para/>- Close the channel immediately after processing a Claim, refunding any unclaimed XRP to the channel's source.
    /// <para/>Any address sending this transaction can:
    /// <para/>- Cause a channel to be closed if its Expiration or CancelAfter time is older than the previous ledger's close time. Any validly-formed PaymentChannelClaim transaction has this effect regardless of the contents of the transaction.
    /// </summary>
    public class PaymentChannelClaim : Transaction
    {
        /// <summary>
        /// The unique ID of the channel, as a 64-character hexadecimal string.
        /// </summary>
        public required uint Channel { get; set; }

        /// <summary>
        /// (Optional) Total amount of XRP, in drops, delivered by this channel after processing this claim. 
        /// <para/>Required to deliver XRP. 
        /// Must be more than the total amount delivered by the channel so far, but not greater than the Amount of the signed claim. 
        /// Must be provided except when closing the channel.
        /// </summary>
        public string? Balance { get; set; }

        /// <summary>
        /// (Optional) The amount of XRP, in drops, authorized by the Signature. 
        /// <para/>This must match the amount in the signed message. 
        /// This is the cumulative amount of XRP that can be dispensed by the channel, including XRP previously redeemed.
        /// </summary>
        public string? Amount { get; set; }

        /// <summary>
        /// (Optional) The signature of this claim, as hexadecimal. 
        /// <para/>The signed message contains the channel ID and the amount of the claim. 
        /// Required unless the sender of the transaction is the source address of the channel.
        /// </summary>
        public string? Signature { get; set; }

        /// <summary>
        /// (Optional) The public key used for the signature, as hexadecimal. 
        /// <para/>This must match the PublicKey stored in the ledger for the channel. 
        /// Required unless the sender of the transaction is the source address of the channel and the Signature field is omitted. 
        /// (The transaction includes the public key so that rippled can check the validity of the signature before trying to apply the transaction to the ledger.)
        /// </summary>
        public string? PublicKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentChannelClaim"/> class.
        /// </summary>
        public PaymentChannelClaim() : base(TransactionType.PaymentChannelClaim)
        {
        }
    }

    /// <summary>
    /// Represents flags of a <see cref="PaymentChannelClaim"/> transaction.
    /// </summary>
    public enum PaymentChannelClaimFlags
    {
        /// <summary>
        /// Clear the channel's Expiration time. 
        /// <para/>(Expiration is different from the channel's immutable CancelAfter time.) 
        /// Only the source address of the payment channel can use this flag.
        /// </summary>
        tfRenew = 0x00010000,

        /// <summary>
        /// Request to close the channel. 
        /// <para/>Only the channel source and destination addresses can use this flag. 
        /// This flag closes the channel immediately if it has no more XRP allocated to it after processing the current claim, 
        /// or if the destination address uses it. 
        /// If the source address uses this flag when the channel still holds XRP, 
        /// this schedules the channel to close after SettleDelay seconds have passed. 
        /// (Specifically, this sets the Expiration of the channel to the close time of the previous ledger plus the channel's SettleDelay time, unless the channel already has an earlier Expiration time.) If the destination address uses this flag when the channel still holds XRP, any XRP that remains after processing the claim is returned to the source address.
        /// </summary>
        tfClose = 0x00020000
    }
}