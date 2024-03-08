using System.Runtime.Serialization;
using XRPL.Core.Domain.Contracts;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a request to return information about an account's trust lines, which contain balances in all non-XRP currencies and assets.
    /// <para/>All information retrieved is relative to a particular version of the ledger.
    /// </summary>
    [DataContract]
    public class AccountLinesRequest : RequestBase<AccountInfoRequestParameters>, IRelateTo<AccountLinesResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfoRequest"/> class.
        /// </summary>
        public AccountLinesRequest() : base("account_lines")
        {
        }
    }

    /// <summary>
    /// Represents parameters to return information about an account's trust lines, which contain balances in all non-XRP currencies and assets.
    /// </summary>
    [DataContract]
    public class AccountLinesParameters : ParameterBase
    {
        /// <summary>
        /// Look up trust lines connected to this account.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// (Optional) A second account; if provided, filter results to trust lines connecting the two accounts.
        /// </summary>
        [DataMember(Name = "peer")]
        public string? Peer { get; set; }

        /// <summary>
        /// (Optional) Limit the number of trust lines to retrieve.
        /// <para/>The server may return less than the specified limit, even if there are more pages of results.
        /// Must be within the inclusive range 10 to 400.
        /// Positive values outside this range are replaced with the closest valid option. The default is 200.
        /// </summary>
        [DataMember(Name = "limit")]
        public uint Limit { get; set; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [DataMember(Name = "marker")]
        public object? Marker { get; set; }
    }
}