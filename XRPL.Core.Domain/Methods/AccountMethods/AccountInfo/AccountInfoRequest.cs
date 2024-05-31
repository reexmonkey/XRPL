using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountInfo
{
    /// <summary>
    /// Represents a request to retrieve information about an account, its activity and its XRP balance.
    /// </summary>

    public class AccountInfoRequest : RequestBase<AccountInfoRequestParameters>, IExpect<AccountInfoResponse>
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
    /// Represents the parameters of an <see cref="AccountInfoRequest"/> object.
    /// </summary>
    
    public class AccountInfoRequestParameters : ParameterBase
    {
        /// <summary>
        /// The account to look up.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// If true, return stats about queued transactions sent by this account. Can only be used when querying for the data from the current open ledger.
        /// </summary>
        [JsonPropertyName("queue")]
        public bool Queue { get; set; }

        /// <summary>
        /// If true, return any signer list objects associated with this account.
        /// </summary>
        [JsonPropertyName("signer_lists")]
        public bool SignerLists { get; set; }
    }
}
