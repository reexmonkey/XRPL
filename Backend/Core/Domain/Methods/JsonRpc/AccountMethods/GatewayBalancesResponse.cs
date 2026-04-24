using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a response that encapsulates a list of validated transactions that involve a given account.
    /// </summary>
    public record GatewayBalancesResponse : Response
    {
        /// <summary>
        /// Gets the result of a <see cref="GatewayBalancesResponse"/> request.
        /// </summary>
        [JsonPropertyName("result")]
        public required GatewayBalancesResult Result { get; init; }
    }

    /// <summary>
    /// Represents a result of an <see cref="GatewayBalancesResponse"/> object.
    /// </summary>
    public record GatewayBalancesResult : Result
    {
        /// <summary>
        /// The address of the account that issued the balances.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// (Omitted if empty) Total amounts issued to addresses not excluded, as a map of currencies to the total value issued.
        /// </summary>
        [JsonPropertyName("obligations")]
        public Dictionary<string, string> Obligations { get; init; } = [];

        /// <summary>
        /// (Omitted if empty) Amounts issued to the hotwallet addresses from the request.
        /// <para/>The keys are addresses and the values are arrays of currency amounts they hold.
        /// </summary>
        [JsonPropertyName("balances")]
        public CurrencyAmount[] Balances { get; init; } = [];

        /// <summary>
        /// (Omitted if empty) Total amounts held that are issued by others.
        /// <para/>In the recommended configuration, the issuing address should have none.
        /// </summary>
        [JsonPropertyName("assets")]
        public CurrencyAmount[] Assets { get; init; } = [];

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger version that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// (May be omitted) The ledger index of the ledger version that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; init; }

        /// <summary>
        /// (Omitted if ledger_current_index is provided) The ledger index of the current in-progress ledger version, which was used to retrieve this information.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; init; }
    }
}
