﻿using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountChannels
{
    /// <summary>
    /// Represents a request to get information about an account's payment channels.
    /// <para/>  This includes only channels where the specified account is the channel's source, not the destination.
    /// (A channel's "source" and "owner" are the same.)
    /// All information retrieved is relative to a particular version of the ledger
    /// </summary>
    public class AccountChannelsRequest : RequestBase<AccountChannelsParameters>, IExpect<AccountChannelsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountChannelsRequest"/> class.
        /// </summary>
        public AccountChannelsRequest() : base("account_channels")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountChannelsRequest"/> class with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters of the request.</param>
        public AccountChannelsRequest(AccountChannelsParameters[] parameters) : this()
        {
            ArgumentNullException.ThrowIfNull(parameters);
            Parameters = parameters;
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountChannelsRequest"/> object.
    /// </summary>
    public class AccountChannelsParameters : ParameterBase
    {
        /// <summary>
        /// Look up channels where this account is the channel's owner/source
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        /// <summary>
        /// A second account; if provided, filter results to payment channels whose destination is this account.
        /// </summary>
        [JsonPropertyName("destination_account")]
        public string? DestinationAccount { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// Limit the number of transactions to retrieve.
        /// <para/>Cannot be less than 10 or more than 400. Positive values outside this range are replaced with the closest valid option.
        /// The default is 200.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }
    }
}