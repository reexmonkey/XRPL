using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a response that retrieves a list of currencies that an account can send or receive, based on its trust lines. 
    /// <para/>(This is not a thoroughly confirmed list, but it can be used to populate user interfaces.)
    /// </summary>
    public record AccountCurrenciesResponse : Response
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        [JsonPropertyName("result")]
        public required AccountCurrenciesResponseResult Result { get; set; }
    }


    /// <summary>
    /// Represents the response result containing information about the currencies associated with an account, including
    /// the ledger version used for retrieval.
    /// </summary>
    public record AccountCurrenciesResponseResult : Result
    {
        /// <summary>
        /// The identifying hash of the ledger version used to retrieve this data, as hex.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The ledger index of the ledger version used to retrieve this data.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public required int LedgerIndex { get; init; }

        /// <summary>
        /// Array of Token Codes for currencies that this account can receive.
        /// </summary>
        [JsonPropertyName("receive_currencies")]
        public required string[] ReceiveCurrencies { get; init; }

        /// <summary>
        /// Array of Token Codes for currencies that this account can send.
        /// </summary>
        [JsonPropertyName("send_currencies")]
        public required string[] SendCurrencies { get; init; }

        /// <summary>
        /// If true, this data comes from a validated ledger.
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; init; }
    }
}
