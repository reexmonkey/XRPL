using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a request that provides a quick way to check the status of the Default Ripple field for an account and the No Ripple flag of its trust lines,
    /// compared with the recommended settings.
    /// </summary>
    [DataContract]
    public class NoRippleCheckRequest : RequestBase<NoRippleCheckParameters>, IExpect<NoRippleCheckResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoRippleCheckRequest"/> class.
        /// </summary>
        public NoRippleCheckRequest() : base("noripple_check")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="NoRippleCheckRequest"/> object.
    /// </summary>
    [DataContract]
    public class NoRippleCheckParameters : ParameterBase
    {
        /// <summary>
        /// A unique identifier for the account, most commonly the account's address.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// Whether the address refers to a gateway or user. Recommendations depend on the role of the account.
        /// <para/>Issuers must have Default Ripple enabled and must disable No Ripple on all trust lines.
        /// Users should have Default Ripple disabled, and should enable No Ripple on all trust lines.
        /// </summary>
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        /// <summary>
        /// If true, include an array of suggested transactions, as JSON objects, that you can sign and submit to fix the problems. The default is false.
        /// </summary>
        [JsonPropertyName("transactions")]
        public bool Transactions { get; set; }

        /// <summary>
        /// (Optional) The maximum number of trust line problems to include in the results. Defaults to 300.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint Limit { get; set; } = 300;

        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger version to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; set; }
    }
}