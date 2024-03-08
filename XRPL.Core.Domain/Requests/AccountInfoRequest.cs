using System.Runtime.Serialization;
using XRPL.Core.Domain.Contracts;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a request to retrieve information about an account, its activity and its XRP balance.
    /// </summary>
    [DataContract]
    public class AccountInfoRequest : RequestBase<AccountInfoRequestParameters>, IRelateTo<AccountInfoResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfoRequest"/> class.
        /// </summary>
        public AccountInfoRequest() : base("account_info")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfoRequest"/> class with specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters of the request.</param>
        public AccountInfoRequest(AccountInfoRequestParameters[]? parameters) : this()
        {
            ArgumentNullException.ThrowIfNull(parameters, nameof(parameters));
            Parameters = parameters;
        }
    }

    /// <summary>
    /// Represents the parameters of a request to retrieve information about an account, its activity and its XRP balance.
    /// </summary>
    [DataContract]
    public class AccountInfoRequestParameters : ParameterBase
    {
        /// <summary>
        /// The account to look up.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// If true, return stats about queued transactions sent by this account. Can only be used when querying for the data from the current open ledger.
        /// </summary>
        [DataMember(Name = "queue")]
        public bool Queue { get; set; }

        /// <summary>
        /// If true, return any signer list objects associated with this account.
        /// </summary>
        [DataMember(Name = "signer_lists")]
        public bool SignerLists { get; set; }
    }
}