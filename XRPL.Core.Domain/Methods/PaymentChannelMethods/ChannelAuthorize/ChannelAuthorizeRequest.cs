using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.PaymentChannelMethods.ChannelAuthorize
{
    /// <summary>
    /// Represents a request to create a signature that can be used to redeem a specific amount of XRP from a payment channel.
    /// <para/>Warning: Do not send secret keys to untrusted servers or through unsecured network connections.
    /// (This includes the secret, seed, seed_hex, or passphrase fields of this request.)
    /// You should only use this method on a secure, encrypted network connection to a server you run or fully trust with your funds.
    /// Otherwise, eavesdroppers could use your secret key to sign claims and take all the money from this payment channel and anything else using the same key pair.
    /// </summary>
    public class ChannelAuthorizeRequest : RequestBase<ChannelAuthorizeParameters>, IExpect<ChannelAuthorizeResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelAuthorizeRequest"/> class.
        /// </summary>
        public ChannelAuthorizeRequest() : base("channel_authorize")
        {
        }
    }

    /// <summary>
    /// Specifies the parameters of an <see cref="ChannelAuthorizeRequest"/> object.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(SecretChannelAuthorizeParameters), typeDiscriminator: nameof(SecretChannelAuthorizeParameters))]
    [JsonDerivedType(typeof(SeedChannelAuthorizeParameters), typeDiscriminator: nameof(SeedChannelAuthorizeParameters))]
    [JsonDerivedType(typeof(SeedHexChannelAuthorizeParameters), typeDiscriminator: nameof(SeedHexChannelAuthorizeParameters))]
    [JsonDerivedType(typeof(PassphraseChannelAuthorizeParameters), typeDiscriminator: nameof(PassphraseChannelAuthorizeParameters))]
    public abstract class ChannelAuthorizeParameters : ParameterBase
    {
        /// <summary>
        /// The unique ID of the payment channel to use.
        /// </summary>
        [JsonPropertyName("channel_id")]
        public required string ChannelId { get; set; }

        /// <summary>
        /// Cumulative amount of XRP, in drops, to authorize.
        /// <para/>If the destination has already received a lesser amount of XRP from this channel, the signature created by this method can be redeemed for the difference.
        /// </summary>
        [JsonPropertyName("amount")]
        public required string Amount { get; set; }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="ChannelAuthorizeRequest"/> object.
    /// </summary>
    [JsonDerivedType(typeof(SecretChannelAuthorizeParameters), typeDiscriminator: nameof(SecretChannelAuthorizeParameters))]
    public sealed class SecretChannelAuthorizeParameters : ChannelAuthorizeParameters
    {
        /// <summary>
        /// The secret key to use to sign the claim.
        /// <para/>This must be the same key pair as the public key specified in the channel.
        /// </summary>
        [JsonPropertyName("secret")]
        public required string Secret { get; set; }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="ChannelAuthorizeRequest"/> object.
    /// </summary>
    [JsonDerivedType(typeof(SeedChannelAuthorizeParameters), typeDiscriminator: nameof(SeedChannelAuthorizeParameters))]
    public sealed class SeedChannelAuthorizeParameters : ChannelAuthorizeParameters
    {
        /// <summary>
        /// The secret seed to use to sign the claim.
        /// <para/>This must be the same key pair as the public key specified in the channel.
        /// Must be in the XRP Ledger's base58 format.
        /// </summary>
        [JsonPropertyName("seed")]
        public required string Seed { get; set; }

        /// <summary>
        /// (Optional) The signing algorithm of the cryptographic key pair provided.
        /// </summary>
        [JsonPropertyName("key_type")]
        public required KeyType KeyType { get; set; }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="ChannelAuthorizeRequest"/> object.
    /// </summary>
    [JsonDerivedType(typeof(SeedHexChannelAuthorizeParameters), typeDiscriminator: nameof(SeedHexChannelAuthorizeParameters))]
    public sealed class SeedHexChannelAuthorizeParameters : ChannelAuthorizeParameters
    {
        /// <summary>
        /// The secret seed to use to sign the claim.
        /// <para/>This must be the same key pair as the public key specified in the channel.
        /// Must be in hexadecimal format.
        /// </summary>
        [JsonPropertyName("seed_hex")]
        public string? SeedHex { get; set; }

        /// <summary>
        /// The signing algorithm of the cryptographic key pair provided.
        /// </summary>
        [JsonPropertyName("key_type")]
        public required KeyType KeyType { get; set; }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="ChannelAuthorizeRequest"/> object.
    /// </summary>
    [JsonDerivedType(typeof(PassphraseChannelAuthorizeParameters), typeDiscriminator: nameof(PassphraseChannelAuthorizeParameters))]
    public sealed class PassphraseChannelAuthorizeParameters : ChannelAuthorizeParameters
    {
        /// <summary>
        /// A string passphrase to use to sign the claim.
        /// <para/>This must be the same key pair as the public key specified in the channel.
        /// The key derived from this passphrase must match the public key specified in the channel.
        /// </summary>
        [JsonPropertyName("passphrase")]
        public required string Passphrase { get; set; }

        /// <summary>
        /// The signing algorithm of the cryptographic key pair provided.
        /// </summary>
        [JsonPropertyName("key_type")]
        public required KeyType KeyType { get; set; }
    }
}
