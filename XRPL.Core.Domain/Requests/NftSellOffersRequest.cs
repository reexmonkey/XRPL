using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// The nft_sell_offers method returns a list of sell offers for a given NFToken object.
    /// </summary>
    public class NFTSellOffersRequest : RequestBase<NFTSellOffersParameters>, IExpect<NFTSellOffersResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NFTSellOffersRequest"/> class.
        /// </summary>
        public NFTSellOffersRequest() : base("nft_sell_offers")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="NFTBuyOffersRequest"/> object.
    /// </summary>
    [DataContract]
    public class NFTSellOffersParameters : ParameterBase
    {
        /// <summary>
        /// The unique identifier of a NFToken object.
        /// </summary>
        [JsonPropertyName("nft_id")]
        public required string NFTId { get; set; }

        ///<summary>
        ///(Optional) A 20-byte hex string for the ledger version to use.
        ///</summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        ///<summary>
        ///(Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        ///</summary>
        [JsonPropertyName("ledger_index")]
        public uint? LedgerIndex { get; set; }

        ///<summary>
        ///(Optional) Limit the number of NFT sell offers to retrieve.
        ///This value cannot be lower than 50 or more than 500.
        ///Positive values outside this range are replaced with the closest valid option. The default is 250.
        ///</summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; }

        ///<summary>
        ///(Optional) Value from a previous paginated response. Resume retrieving data where that response left off.
        ///</summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }
    }
}
