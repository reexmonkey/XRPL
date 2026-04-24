using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents the API method that returns information about an account's Payment Channels.
    /// This includes only channels where the specified account is the channel's source, not the destination.
    /// </summary>
    /// <remarks>(A channel's "source" and "owner" are the same.) All information retrieved is relative to a particular version of the ledger.</remarks>
    public record AccountChannelsResponse : Response
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        [JsonPropertyName("result")]
        public required AccountChannelsResult Result { get; set; }
    }

    /// <summary>
    /// Represents the result of an account channels response
    /// specified account.
    /// </summary>
    public record AccountChannelsResult : Result
    {
        /// <summary>
        /// The address of the source/owner of the payment channels. This corresponds to the account field of the request.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// Payment channels owned by this account.
        /// </summary>
        [JsonPropertyName("channels")]
        public required Channel[] Channels { get; init; }

        /// <summary>
        /// The identifying Hash of the ledger version used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The Ledger Index of the ledger version used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public uint LedgerIndex { get; init; }

        /// <summary>
        /// If true, the information in this response comes from a validated ledger version. Otherwise, the information is subject to change.
        /// </summary>
        [JsonPropertyName("validated")]
        public bool? Validated { get; init; }

        /// <summary>
        /// The limit to how many channel objects were actually returned by this request.
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; init; }

        /// <summary>
        /// Server-defined value for pagination. Pass this to the next call to resume getting results where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }
    }

    /// <summary>
    /// Represents a payment channel.
    /// </summary>
    public record Channel
    {
        /// <summary>
        /// The owner of the channel, as an address.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// The total amount of XRP, in drops allocated to this channel.
        /// </summary>
        [JsonPropertyName("amount")]
        public required string Amount { get; init; }

        /// <summary>
        /// The total amount of XRP, in drops, paid out from this channel, as of the ledger version used.
        /// <para/>(You can calculate the amount of XRP left in the channel by subtracting balance from amount.)
        /// </summary>
        [JsonPropertyName("balance")]
        public required string Balance { get; init; }

        /// <summary>
        /// A unique ID for this channel, as a 64-character hexadecimal string.
        /// <para/>This is also the ID of the channel object in the ledger's state data.
        /// </summary>
        [JsonPropertyName("channel_id")]
        public required string ChannelId { get; init; }

        /// <summary>
        /// The destination account of the channel, as an Address.
        /// <para/>Only this account can receive the XRP in the channel while it is open.
        /// </summary>
        [JsonPropertyName("destination_account")]
        public required string DestinationAccount { get; init; }

        /// <summary>
        /// The number of seconds the payment channel must stay open after the owner of the channel requests to close it.
        /// </summary>
        [JsonPropertyName("settle_delay")]
        public uint SettleDelay { get; init; }

        /// <summary>
        /// The public key for the payment channel in the XRP Ledger's base58 format.
        /// Signed claims against this channel must be redeemed with the matching key pair.
        /// </summary>
        [JsonPropertyName("public_key")]
        public string? PublicKey { get; init; }

        /// <summary>
        /// The public key for the payment channel in hexadecimal format, if one was specified at channel creation.
        /// Signed claims against this channel must be redeemed with the matching key pair.
        /// </summary>
        [JsonPropertyName("public_key_hex")]
        public string? PublicKeyHex { get; init; }

        /// <summary>
        /// Time, in seconds since the Ripple Epoch, when this channel is set to expire.
        /// <para/>This expiration date is mutable. If this is before the close time of the most recent validated ledger, the channel is expired.
        /// </summary>
        [JsonPropertyName("expiration")]
        public uint? Expiration { get; init; }

        /// <summary>
        /// Time, in seconds since the Ripple Epoch, of this channel's immutable expiration, if one was specified at channel creation.
        /// <para/>If this is before the close time of the most recent validated ledger, the channel is expired.
        /// </summary>
        [JsonPropertyName("cancel_after")]
        public uint? CancelAfter { get; init; }

        /// <summary>
        /// A 32-bit unsigned integer to use as a source tag for payments through this payment channel, if one was specified at channel creation.
        /// <para/>This indicates the payment channel's originator or other purpose at the source account.
        /// Conventionally, if you bounce payments from this channel, you should specify this value in the DestinationTag of the return payment.
        /// </summary>
        [JsonPropertyName("source_tag")]
        public uint? SourceTag { get; init; }

        /// <summary>
        /// A 32-bit unsigned integer to use as a destination tag for payments through this channel, if one was specified at channel creation.
        /// <para/>This indicates the payment channel's beneficiary or other purpose at the destination account.
        /// </summary>
        [JsonPropertyName("destination_tag")]
        public uint? DestinationTag { get; init; }
    }


    [JsonSerializable(typeof(AccountChannelsResult))]
    [JsonSerializable(typeof(string))]
    public partial class AccountChannelsResultContext : JsonSerializerContext;
}
