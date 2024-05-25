﻿using System.Runtime.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// The nft_buy_offers method returns a list of buy offers for a given NFToken object.
    /// </summary>
    [DataContract]

    public class NftBuyOffersRequest : RequestBase<NftBuyOffersParameters>, IExpect<NftBuyOffersResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NftBuyOffersRequest"/> class.
        /// </summary>
        public NftBuyOffersRequest() : base("nft_buy_offers")
        { 
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="NftBuyOffersRequest"/> object.
    /// </summary>
    [DataContract]
    public class NftBuyOffersParameters : ParameterBase
    {
        /// <summary>
        /// The unique identifier of a NFToken object.
        /// </summary>
        [DataMember(Name = "nft_id")]
        public required string NftId { get; set; }

        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public uint? LedgerIndex { get; set; }

        /// <summary>
        /// (Optional) Limit the number of NFT buy offers to retrieve.
        /// This value cannot be lower than 50 or more than 500.
        /// Positive values outside this range are replaced with the closest valid option. The default is 250.
        /// </summary>
        [DataMember(Name = "limit")]
        public uint? Limit { get; set; }

        /// <summary>
        /// (Optional) Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [DataMember(Name = "marker")]
        public object? Marker { get; set; }
    }
}