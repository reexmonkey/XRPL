﻿using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountOffers
{
    /// <summary>
    /// Represents the request to retrieve a list of offers made by a given account that are outstanding as of a particular ledger version.
    /// </summary>

    public class AccountOffersRequest : RequestBase<AccountOffersParameters>, IExpect<AccountOffersResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountOffersRequest"/> class.
        /// </summary>
        public AccountOffersRequest() : base("account_offers")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountOffersRequest"/> object.
    /// </summary>

    public class AccountOffersParameters : ParameterBase
    {
        /// <summary>
        /// Look up offers placed by this account.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// (Optional) Limit the number of token pages to retrieve. Each page can contain up to 32 NFTs.
        /// <para/>The limit value cannot be lower than 20 or more than 400.
        /// Positive values outside this range are replaced with the closest valid option.
        /// The default is 100.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint Limit { get; set; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }
    }
}
