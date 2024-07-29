using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountLines
{
    /// <summary>
    /// Represents a request to return information about an account's trust lines, which contain balances in all non-XRP currencies and assets.
    /// <para/>All information retrieved is relative to a particular version of the ledger.
    /// </summary>

    public class AccountLinesRequest : RequestBase<AccountLinesParameters>, IExpect<AccountLinesResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountLinesRequest"/> class.
        /// </summary>
        public AccountLinesRequest() : base("account_lines")
        {
        }
    }

    /// <summary>
    /// Represents parameters of an <see cref="AccountLinesRequest"/> object.
    /// </summary>

    public class AccountLinesParameters : ParameterBase
    {
        /// <summary>
        /// Look up trust lines connected to this account.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// (Optional) A second account; if provided, filter results to trust lines connecting the two accounts.
        /// </summary>
        [JsonPropertyName("peer")]
        public string? Peer { get; set; }

        /// <summary>
        /// (Optional) Limit the number of trust lines to retrieve.
        /// <para/>The server may return less than the specified limit, even if there are more pages of results.
        /// Must be within the inclusive range 10 to 400.
        /// Positive values outside this range are replaced with the closest valid option. The default is 200.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }
    }
}
