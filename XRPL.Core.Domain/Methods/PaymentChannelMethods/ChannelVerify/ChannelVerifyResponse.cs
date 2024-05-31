using System.Text.Json.Serialization;
using XRPL.Core.Domain.Methods.TransactionMethods.Tx;

namespace XRPL.Core.Domain.Methods.PaymentChannelMethods.ChannelVerify
{
    /// <summary>
    /// Represents a response to a request that checks the validity of a signature that can be used to redeem a specific amount of XRP from a payment channel.
    /// </summary>
    public class ChannelVerifyResponse : ResponseBase<ChannelVerifyResult>
    {
    }

    /// <summary>
    /// Represents a <see cref="TxResult"/> with a 256-bit hash of the transaction.
    /// </summary>
    public sealed class ChannelVerifyResult : TxResult
    {
        /// <summary>
        /// If true, the signature is valid for the stated amount, channel, and public key.
        /// </summary>
        [JsonPropertyName("signature_verified")]
        public bool SignatureVerified { get; set; }
    }
}
