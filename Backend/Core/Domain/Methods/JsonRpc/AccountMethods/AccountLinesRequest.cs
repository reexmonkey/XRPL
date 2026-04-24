using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a request to return information about an account's trust lines, which contain balances in all non-XRP currencies and assets.
    /// <para/>All information retrieved is relative to a particular version of the ledger.
    /// </summary>
    public record AccountLinesRequest : Request, IExpect<AccountLinesResponse>
    {
        /// <summary>
        /// A one-item array containing a nested JSON object with the parameters to this method. You may omit this field if the method does not require any parameters.
        /// </summary>
        [JsonPropertyName("params")]
        public AccountLinesParameters[]? Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountLinesRequest"/> record.
        /// </summary>
        public AccountLinesRequest() : base("account_lines")
        {
        }
    }

    /// <summary>
    /// Represents parameters of an <see cref="AccountLinesRequest"/> object.
    /// </summary>
    public record AccountLinesParameters : Parameter
    {
        /// <summary>
        /// Look up trust lines connected to this account.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// If true, don't return trust lines where this account's side is in the default state. The default is false.
        /// </summary>
        [JsonPropertyName("ignore_default")]
        public bool? IgnoreDefault { get; init; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; init; }

        /// <summary>
        /// (Optional) Limit the number of trust lines to retrieve.
        /// <para/>The server may return less than the specified limit, even if there are more pages of results.
        /// Must be within the inclusive range 10 to 400.
        /// Positive values outside this range are replaced with the closest valid option. The default is 200.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; init; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }

        /// <summary>
        /// (Optional) A second account; if provided, filter results to trust lines connecting the two accounts.
        /// </summary>
        [JsonPropertyName("peer")]
        public string? Peer { get; init; }
    }
}
