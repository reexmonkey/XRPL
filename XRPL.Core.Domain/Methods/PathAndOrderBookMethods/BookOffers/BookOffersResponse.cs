using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.BookOffers
{
    /// <summary>
    /// Represents a response to a book offer request.
    /// </summary>
    public class BookOffersResponse : ResponseBase<BookOffersResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="BookOffersResponse"/> object.
    /// </summary>
    public class BookOffersResult : ResultBase
    {
        /// <summary>
        ///(Omitted if ledger_current_index is provided)
        ///The ledger index of the current in-progress ledger version, which was used to retrieve this information.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public uint? LedegerCurrentIndex { get; set; }

        /// <summary>
        ///(Omitted if ledger_current_index provided)
        ///The ledger index of the ledger version that was used when retrieving this data, as requested.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public uint? LedgerIndex { get; set; }

        /// <summary>
        ///(May be omitted) The identifying hash of the ledger version that was used when retrieving this data, as requested.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerCount { get; set; }

        /// <summary>
        ///Array of offer objects, each of which has the fields of an Offer object
        /// </summary>
        [JsonPropertyName("offers")]
        public required OfferOfBookOffers[] Offers { get; set; }

    }

    ///<summary>
    ///Additional members that could be added to the Standard Offer fields.
    ///</summary>
    public class OfferOfBookOffers : Offer
    {
        ///<summary>
        ///Amount of the TakerGets currency the side placing the offer has available to be traded.
        ///(XRP is represented as drops; any other currency is represented as a decimal value.)
        ///If a trader has multiple offers in the same book, only the highest-ranked offer includes this field.
        ///</summary>
        [JsonPropertyName("owner_funds")]
        public required string OwnerFunds { get; set; }

        ///<summary>
        ///(Only included in partially-funded offers)
        ///The maximum amount of currency that the taker can get,
        ///given the funding status of the offer.
        ///</summary>
        [JsonPropertyName("taker_gets_funded")]
        public TokenAmount? TakerGetsFunded {  get; set; } 

        ///<summary>
        ///
        ///</summary>
        [JsonPropertyName("taker_pays_funded")]
        public TokenAmount? TakerPaysFunded { get; set; }

        ///<summary>
        ///The exchange rate, as the ratio taker_pays divided by taker_gets.
        ///For fairness, offers that have the same quality are automatically taken first-in, first-out.
        ///(In other words, if multiple people offer to exchange currency at the same rate, the oldest offer is taken first.)
        ///</summary>
        [JsonPropertyName("quality")]
        public required string Quality { get; set; }
    }
}
