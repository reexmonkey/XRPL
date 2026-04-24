using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a request that calculates the total balances issued by a given account, optionally excluding amounts held by operational addresses.
    /// </summary>
    public record GatewayBalancesRequest : Request, IExpect<GatewayBalancesResponse>
    {

        /// <summary>
        /// Gets the array of parameters used to configure the gateway balances request.
        /// </summary>
        /// <remarks>This property may return null if no parameters are specified. Each element in the
        /// array defines criteria for querying gateway balances.</remarks>
        [JsonPropertyName("params")]
        public GatewayBalancesParameters[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GatewayBalancesRequest"/> record.
        /// </summary>
        public GatewayBalancesRequest() : base("gateway_balances")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="GatewayBalancesRequest"/> object.
    /// </summary>
    public record GatewayBalancesParameters : Parameter
    {
        /// <summary>
        /// The Address to check. This should be the issuing address
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// If true, only accept an address or public key for the account parameter. Defaults to false.
        /// </summary>
        [JsonPropertyName("strict")]
        public bool? Strict { get; init; }

        /// <summary>
        /// An operational address to exclude from the balances issued, or an array of such addresses.
        /// </summary>
        [JsonPropertyName("hotwallet")]
        public string[]? Hotwallet { get; init; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The ledger index of the ledger version to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; init; }
    }
}