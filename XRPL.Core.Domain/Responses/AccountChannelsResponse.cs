using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response that encapsulates information about an account's payment channels.
    /// </summary>
    [DataContract]
    public class AccountChannelsResponse : ResponseBase<AccountChannelsResult>
    {
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountChannelsResponse"/> object.
    /// </summary>
    [DataContract]
    public class AccountChannelsResult : ResultBase
    {
        /// <summary>
        /// The address of the source/owner of the payment channels. This corresponds to the account field of the request.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// Payment channels owned by this account.
        /// </summary>
        [JsonPropertyName("channels")]
        public Channel[]? Channels { get; set; }

        /// <summary>
        /// The identifying Hash of the ledger version used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The Ledger Index of the ledger version used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public uint LedgerIndex { get; set; }

        /// <summary>
        /// If true, the information in this response comes from a validated ledger version. Otherwise, the information is subject to change.
        /// </summary>
        [JsonPropertyName("validated")]
        public bool? Validated { get; set; }

        /// <summary>
        /// The limit to how many channel objects were actually returned by this request.
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Server-defined value for pagination. Pass this to the next call to resume getting results where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }
    }

    /// <summary>
    /// Represents a payment channel.
    /// </summary>
    [DataContract]
    public class Channel
    {
        /// <summary>
        /// The owner of the channel, as an address.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// The total amount of XRP, in drops allocated to this channel.
        /// </summary>
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        /// <summary>
        /// The total amount of XRP, in drops, paid out from this channel, as of the ledger version used.
        /// <para/>(You can calculate the amount of XRP left in the channel by subtracting balance from amount.)
        /// </summary>
        [JsonPropertyName("balance")]
        public string? Balance { get; set; }

        /// <summary>
        /// A unique ID for this channel, as a 64-character hexadecimal string.
        /// <para/>This is also the ID of the channel object in the ledger's state data.
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string? ChannelId { get; set; }

        /// <summary>
        /// The destination account of the channel, as an Address.
        /// <para/>Only this account can receive the XRP in the channel while it is open.
        /// </summary>
        [JsonPropertyName("destination_account")]
        public string? DestinationAccount { get; set; }

        /// <summary>
        /// The number of seconds the payment channel must stay open after the owner of the channel requests to close it.
        /// </summary>
        [JsonPropertyName("settle_delay")]
        public uint SettleDelay { get; set; }

        /// <summary>
        /// The public key for the payment channel in the XRP Ledger's base58 format.
        /// Signed claims against this channel must be redeemed with the matching key pair.
        /// </summary>
        [JsonPropertyName("public_key")]
        public string? PublicKey { get; set; }

        /// <summary>
        /// The public key for the payment channel in hexadecimal format, if one was specified at channel creation.
        /// Signed claims against this channel must be redeemed with the matching key pair.
        /// </summary>
        [JsonPropertyName("public_key_hex")]
        public string? PublicKeyHex { get; set; }

        /// <summary>
        /// Time, in seconds since the Ripple Epoch, when this channel is set to expire.
        /// <para/>This expiration date is mutable. If this is before the close time of the most recent validated ledger, the channel is expired.
        /// </summary>
        [JsonPropertyName("expiration")]
        public uint? Expiration { get; set; }

        /// <summary>
        /// Time, in seconds since the Ripple Epoch, of this channel's immutable expiration, if one was specified at channel creation.
        /// <para/>If this is before the close time of the most recent validated ledger, the channel is expired.
        /// </summary>
        [JsonPropertyName("cancel_after")]
        public uint? CancelAfter { get; set; }

        /// <summary>
        /// A 32-bit unsigned integer to use as a source tag for payments through this payment channel, if one was specified at channel creation.
        /// <para/>This indicates the payment channel's originator or other purpose at the source account.
        /// Conventionally, if you bounce payments from this channel, you should specify this value in the DestinationTag of the return payment.
        /// </summary>
        [JsonPropertyName("source_tag")]
        public uint? SourceTag { get; set; }

        /// <summary>
        /// A 32-bit unsigned integer to use as a destination tag for payments through this channel, if one was specified at channel creation.
        /// <para/>This indicates the payment channel's beneficiary or other purpose at the destination account.
        /// </summary>
        [JsonPropertyName("destination_tag")]
        public uint? DestinationTag { get; set; }
    }
}