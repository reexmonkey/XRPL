using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to a transaction method request that creates a signature that can be used to redeem a specific amount of XRP from a payment channel.
    /// </summary>
    [DataContract]
    public class ChannelAuthorizeResponse : ResponseBase<ChannelAuthorizeResult>
    {
    }


    /// <summary>
    /// Represents a <see cref="TxResult"/> with a 256-bit hash of the transaction.
    /// </summary>
    public sealed class ChannelAuthorizeResult : TxResult
    {
        /// <summary>
        /// The signature for this claim, as a hexadecimal value. 
        /// <para/>To process the claim, the destination account of the payment channel must send a PaymentChannelClaim transaction with this signature, the exact Channel ID, XRP amount, and public key of the channel.
        /// </summary>
        [JsonPropertyName("signature")]
        public string? Signature { get; set; }
    }

}