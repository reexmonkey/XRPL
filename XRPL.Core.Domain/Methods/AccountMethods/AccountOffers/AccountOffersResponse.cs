﻿using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountOffers
{
    /// <summary>
    /// Represents a response that encapsulates a list of offers made by a given account that are outstanding as of a particular ledger version.
    /// </summary>

    public class AccountOffersResponse : ResponseBase<AccountOffersResult>
    {
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountOffersResponse"/> object.
    /// </summary>

    public class AccountOffersResult : ResultBase
    {
        /// <summary>
        /// Unique Address identifying the account that made the offers
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        /// <summary>
        /// Array of objects, where each object represents an offer made by this account that is outstanding as of the requested ledger version.
        /// If the number of offers is large, only returns up to limit at a time.
        /// </summary>
        [JsonPropertyName("offers")]
        public required AccountOffer[] Offers { get; set; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger version that was used when retrieving this data.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Omitted if ledger_current_index provided instead) The ledger index of the ledger version that was used when retrieving this data, as requested.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// (Omitted if ledger_hash or ledger_index provided) The ledger index of the current in-progress ledger version, which was used when retrieving this data.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; set; }

        /// <summary>
        /// Server-defined value for pagination. Pass this to the next call to resume getting results where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }
    }

    /// <summary>
    /// Specifies an an offer made by an account that is outstanding as of the requested ledger version.
    /// <para/>If the number of offers is large, only returns up to limit at a time.
    /// </summary>
    public abstract class AccountOffer
    {
        /// <summary>
        /// Options set for this offer entry as bit-flags.
        /// </summary>
        [JsonPropertyName("flags")]
        public uint Flags { get; set; }

        /// <summary>
        /// Sequence number of the transaction that created this entry. (Transaction sequence numbers are relative to accounts.)
        /// </summary>
        [JsonPropertyName("seq")]
        public uint Seq { get; set; }

        /// <summary>
        /// The amount the account accepting the offer receives, as a <see cref="string"/> representing an amount in XRP,
        /// or a token specification object (<see cref="TokenAmount"/>).
        /// </summary>
        [JsonPropertyName("taker_gets")]
        public object TakerGets { get; set; } = null!;

        /// <summary>
        /// The amount the account accepting the offer provides, as a <see cref="string"/> representing an amount in XRP,
        /// or a token specification object (<see cref="TokenAmount"/>).
        /// </summary>
        [JsonPropertyName("taker_pays")]
        public object TakerPays { get; set; } = null!;

        /// <summary>
        /// The exchange rate of the offer, as the ratio of the original taker_pays divided by the original taker_gets.
        /// When executing offers, the offer with the most favorable (lowest) quality is consumed first;
        /// offers with the same quality are executed from oldest to newest.
        /// </summary>
        [JsonPropertyName("quality")]
        public string? Quality { get; set; }

        /// <summary>
        /// (May be omitted) A time after which this offer is considered unfunded, as the number of seconds since the Ripple Epoch.
        /// </summary>
        [JsonPropertyName("expiration")]
        public uint? Expiration { get; set; }
    }

    /// <summary>
    /// Specifies an an offer made by an account that is outstanding as of the requested ledger version.
    /// <para/>If the number of offers is large, only returns up to limit at a time.
    /// <para/> The account accepting the offer receives a <see cref="string"/> value representing the amount in XRP.
    /// <para/> The account accepting the offer provides a <see cref="TokenAmount"/> object representing the amount in a fungible token specification.
    /// </summary>
    public sealed class XrpForTokenAccountOffer : AccountOffer
    {
        /// <summary>
        /// The amount the account accepting the offer receives as a token specification object (<see cref="TokenAmount"/>).
        /// </summary>
        public new TokenAmount TakerGets { get => (TokenAmount)base.TakerGets; set => base.TakerGets = value; }

        /// <summary>
        /// The amount the account accepting the offer provides a <see cref="string"/> representing an amount in XRP.
        /// </summary>
        public new string TakerPays { get => (string)base.TakerPays; set => base.TakerPays = value; }
    }

    /// <summary>
    /// Specifies an an offer made by an account that is outstanding as of the requested ledger version.
    /// <para/>If the number of offers is large, only returns up to limit at a time.
    /// <para/> The account accepting the offer receives a <see cref="TokenAmount"/> object representing the amount in a fungible token specification.
    /// <para/> The account accepting the offer provides a <see cref="string"/> value representing the amount in XRP.
    /// </summary>
    public sealed class TokenForXrpAccountOffer : AccountOffer
    {
        /// <summary>
        /// The amount the account accepting the offer receives as a <see cref="string"/> representing an amount in XRP.
        /// </summary>
        [JsonPropertyName("taker_gets")]
        public new string TakerGets { get => (string)base.TakerGets; set => base.TakerGets = value; }

        /// <summary>
        /// The amount the account accepting the offer provides a token specification object (<see cref="TokenAmount"/>).
        /// </summary>
        [JsonPropertyName("taker_pays")]
        public new TokenAmount TakerPays { get => (TokenAmount)base.TakerPays; set => base.TakerPays = value; }
    }

    /// <summary>
    /// Specifies an an offer made by an account that is outstanding as of the requested ledger version.
    /// <para/>If the number of offers is large, only returns up to limit at a time.
    /// <para/> The account accepting the offer receives a <see cref="TokenAmount"/> object representing the amount in a token specification.
    /// <para/> The account accepting the offer provides a <see cref="TokenAmount"/> representing the amount in a fungible token specification.
    /// </summary>
    public sealed class TokenForTokenAccountOffer : AccountOffer
    {
        /// <summary>
        /// The amount the account accepting the offer receives as a token specification object (<see cref="TokenAmount"/>).
        /// </summary>
        public new TokenAmount TakerGets { get => (TokenAmount)base.TakerGets; set => base.TakerGets = value; }

        /// <summary>
        /// The amount the account accepting the offer provides a token specification object (<see cref="TokenAmount"/>).
        /// </summary>
        [JsonPropertyName("taker_pays")]
        public new TokenAmount TakerPays { get => (TokenAmount)base.TakerPays; set => base.TakerPays = value; }
    }
}
