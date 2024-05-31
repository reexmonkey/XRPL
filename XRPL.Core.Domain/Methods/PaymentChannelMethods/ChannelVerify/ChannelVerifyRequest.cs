using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.PaymentChannelMethods.ChannelVerify
{
    /// <summary>
    /// Represents a request to check the validity of a signature that can be used to redeem a specific amount of XRP from a payment channel.
    /// </summary>
    public class ChannelVerifyRequest : RequestBase<ChannelVerifyParameters>, IExpect<ChannelVerifyResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelVerifyRequest"/> class.
        /// </summary>
        public ChannelVerifyRequest() : base("channel_authorize")
        {
        }
    }

    /// <summary>
    /// Specifies the parameters of a <see cref="ChannelVerifyRequest"/> object.
    /// </summary>
    public class ChannelVerifyParameters : ParameterBase
    {
        /// <summary>
        /// The amount of XRP, in drops, the provided signature authorizes.
        /// </summary>
        [JsonPropertyName("amount")]
        public required string Amount { get; set; }

        /// <summary>
        /// The Channel ID of the channel that provides the XRP. This is a 64-character hexadecimal string.
        /// </summary>
        [JsonPropertyName("channel_id")]
        public required string ChannelId { get; set; }

        /// <summary>
        /// The public key of the channel and the key pair that was used to create the signature, in hexadecimal or the XRP Ledger's base58 format.
        /// </summary>
        [JsonPropertyName("public_key")]
        public required string PublicKey { get; set; }

        /// <summary>
        /// The signature to verify, in hexadecimal.
        /// </summary>
        [JsonPropertyName("signature")]
        public required string Signature { get; set; }
    }
}
