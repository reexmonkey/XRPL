using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a response that encapsulates a list of offers made by a given account that are outstanding as of a particular ledger version.
    /// </summary>
    public record AccountOffersResponse : Response
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        [JsonPropertyName("result")]
        public required AccountOffersResult Result { get; set; }
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountOffersResponse"/> object.
    /// </summary>
    public record AccountOffersResult : Result
    {
        /// <summary>
        /// Unique Address identifying the account that made the offers
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// Array of objects, where each object represents an offer made by this account that is outstanding as of the requested ledger version.
        /// If the number of offers is large, only returns up to limit at a time.
        /// </summary>
        [JsonPropertyName("offers")]
        public required AccountOffer[] Offers { get; init; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger version that was used when retrieving this data.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// (Omitted if ledger_current_index provided instead) The ledger index of the ledger version that was used when retrieving this data, as requested.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; init; }

        /// <summary>
        /// (Omitted if ledger_hash or ledger_index provided) The ledger index of the current in-progress ledger version, which was used when retrieving this data.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; init; }

        /// <summary>
        /// Server-defined value for pagination. Pass this to the next call to resume getting results where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }
    }

    /// <summary>
    /// Specifies an an offer made by an account that is outstanding as of the requested ledger version.
    /// <para/>If the number of offers is large, only returns up to limit at a time.
    /// </summary>
    public abstract record AccountOffer
    {
        /// <summary>
        /// Options set for this offer entry as bit-flags.
        /// </summary>
        [JsonPropertyName("flags")]
        public uint Flags { get; init; }

        /// <summary>
        /// Sequence number of the transaction that created this entry. (Transaction sequence numbers are relative to accounts.)
        /// </summary>
        [JsonPropertyName("seq")]
        public uint Seq { get; init; }

        /// <summary>
        /// The amount the account accepting the offer receives, as a <see cref="string"/> representing an amount in XRP,
        /// or a token specification object (<see cref="TokenAmount"/>).
        /// </summary>
        [JsonPropertyName("taker_gets")]
        public CurrencyAmount TakerGets { get; init; } = null!;

        /// <summary>
        /// The amount the account accepting the offer provides, as a <see cref="string"/> representing an amount in XRP,
        /// or a token specification object (<see cref="TokenAmount"/>).
        /// </summary>
        [JsonPropertyName("taker_pays")]
        public CurrencyAmount TakerPays { get; init; } = null!;

        /// <summary>
        /// The exchange rate of the offer, as the ratio of the original taker_pays divided by the original taker_gets.
        /// When executing offers, the offer with the most favorable (lowest) quality is consumed first;
        /// offers with the same quality are executed from oldest to newest.
        /// </summary>
        [JsonPropertyName("quality")]
        public string? Quality { get; init; }

        /// <summary>
        /// (May be omitted) A time after which this offer is considered unfunded, as the number of seconds since the Ripple Epoch.
        /// </summary>
        [JsonPropertyName("expiration")]
        public uint? Expiration { get; init; }
    }
}
