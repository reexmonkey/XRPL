﻿using System.Runtime.Serialization;
using XRPL.Core.Domain.Contracts;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a request to retrieve a list of validated transactions that involve a given account.
    /// </summary>
    [DataContract]
    public class GatewayBalancesRequest : RequestBase<GatewayBalancesParameters>, IRelateTo<GatewayBalancesResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GatewayBalancesRequest"/> class.
        /// </summary>
        public GatewayBalancesRequest() : base("gateway_balances")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="GatewayBalancesRequest"/> object.
    /// </summary>
    [DataContract]
    public class GatewayBalancesParameters : ParameterBase
    {
        /// <summary>
        /// The Address to check. This should be the issuing address
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// (Optional) If true, only accept an address or public key for the account parameter. Defaults to false.
        /// </summary>
        [DataMember(Name = "strict")]
        public bool Strict { get; set; }

        /// <summary>
        /// (Optional) An operational address to exclude from the balances issued, or an array of such addresses.
        /// </summary>
        [DataMember(Name = "hotwallet")]
        public string[]? Hotwallet { get; set; }

        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use.
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger version to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public int? LedgerIndex { get; set; }
    }
}