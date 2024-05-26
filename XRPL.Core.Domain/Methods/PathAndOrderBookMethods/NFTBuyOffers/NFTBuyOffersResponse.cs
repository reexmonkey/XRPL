using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.NFTBuyOffers
{
    /// <summary>
    /// Represents a response to a nft buy offers request.
    /// </summary>
    public class NFTBuyOffersResponse : ResponseBase<NFTBuyOffersResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="NFTBuyOffersResponse"/> object.
    /// </summary>
    
    public abstract class NFTBuyOffersResult : ResultBase
    {
        /// <summary>
        /// The NFToken these offers are for, as specified in the request.
        /// </summary>
        [JsonPropertyName("nft_id")]
        public required string NFTId { get; set; }

        /// <summary>
        /// A list of buy offers for the token. Each of these is formatted as a Buy Offer (see below).
        /// </summary>
        [JsonPropertyName("offers")]
        public required BuyOffer[] Offers { get; set; }

        /// <summary>
        /// (May be omitted) The limit, as specified in the request.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; }

        /// <summary>
        /// (May be omitted) Server-defined value indicating the response is paginated.
        /// Pass this to the next call to resume where this call left off.
        /// Omitted when there are no pages of information after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }
    }

    /// <summary>
    /// Additional fields that each member of the BuyOffers array has.
    /// </summary>
    public class BuyOffer
    {
        /// <summary>
        /// The amount offered to buy the NFT for, as a String representing an amount in drops of XRP,
        /// or an object representing an amount of a fungible token. (See Specifying Currency Amounts)
        /// </summary>
        [JsonPropertyName("amount")]
        public required string Amount { get; set; }

        /// <summary>
        /// A set of bit-flags for this offer. See NFTokenOffer flags for possible values.
        /// </summary>
        [JsonPropertyName("flags")]
        public required uint Flags { get; set; }

        /// <summary>
        /// The ledger object ID of this offer.
        /// </summary>
        [JsonPropertyName("nft_offer_index")]
        public required string NFTOfferIndex { get; set; }

        /// <summary>
        /// The account that placed this offer.
        /// </summary>
        [JsonPropertyName("owner")]
        public required string Ower { get; set; }

    }
}

