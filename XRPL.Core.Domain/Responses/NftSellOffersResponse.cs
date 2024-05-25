using System.Runtime.Serialization;
using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to a nft sell offers request.
    /// </summary>
    public class NftSellOffersResponse : ResponseBase<NftSellOffersResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="NftSellOffersResponse"/> object.
    /// </summary>
    [DataContract]
    public abstract class NftSellOffersResult : ResultBase
    {
        /// <summary>
        /// The NFToken these offers are for, as specified in the request.
        /// </summary>
        [DataMember(Name = "nft_id")]
        public required string NftId { get; set; }

        /// <summary>
        /// A list of buy offers for the token. Each of these is formatted as a Buy Offer (see below).
        /// </summary>
        [DataMember(Name = "offers")]
        public required SellOffers[] Offers { get; set; }

        /// <summary>
        /// (May be omitted) The limit, as specified in the request.
        /// </summary>
        [DataMember(Name = "limit")]
        public uint? Limit { get; set; }

        /// <summary>
        /// (May be omitted) Server-defined value indicating the response is paginated.
        /// Pass this to the next call to resume where this call left off.
        /// Omitted when there are no pages of information after this one.
        /// </summary>
        [DataMember(Name = "marker")]
        public object? Marker { get; set; }
    }
    /// <summary>
    /// Additional fields that each member of the BuyOffers array has.
    /// </summary>
    public class SellOffers : Offer
    {
        /// <summary>
        /// The amount offered to sell the NFT for, as a String representing an amount in drops of XRP,
        /// or an object representing an amount of a fungible token. (See Specifying Currency Amounts)
        /// </summary>
        [DataMember(Name = "amount")]
        public required string Amount { get; set; }

        /// <summary>
        /// A set of bit-flags for this offer. See NFTokenOffer flags for possible values.
        /// </summary>
        [DataMember(Name = "flags")]
        public override required uint Flags { get; set; } /*to be reviewed*/

        /// <summary>
        /// The ledger object ID of this offer.
        /// </summary>
        [DataMember(Name = "nft_offer_index")]
        public required string NftOfferIndex { get; set; }

        /// <summary>
        /// The account that placed this offer.
        /// </summary>
        [DataMember(Name = "owner")]
        public required string Ower { get; set; }

    }
}
