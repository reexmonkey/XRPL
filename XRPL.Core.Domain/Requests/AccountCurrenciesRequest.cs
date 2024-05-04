using System.Runtime.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents the request to retrieve account currencies.
    /// </summary>
    [DataContract]
    public class AccountCurrenciesRequest : RequestBase<AccountCurrenciesParameters>, IExpect<AccountCurrenciesResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCurrenciesRequest"/> class.
        /// </summary>
        public AccountCurrenciesRequest() : base("account_currencies")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCurrenciesRequest"/> class with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters of the request.</param>
        public AccountCurrenciesRequest(AccountCurrenciesParameters[]? parameters) : this()
        {
            ArgumentNullException.ThrowIfNull(parameters);
            Parameters = parameters;
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountCurrenciesRequest"/> object.
    /// </summary>
    [DataContract]
    public class AccountCurrenciesParameters : ParameterBase
    {
        /// <summary>
        /// Look up currencies this account can send or receive.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use.
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public string? LedgerIndex { get; set; }
    }
}