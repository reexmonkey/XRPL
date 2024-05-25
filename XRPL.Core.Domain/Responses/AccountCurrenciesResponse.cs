using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response that encapsulates a list of currencies that an account can send or receive, based on its trust lines.
    /// </summary>
    [DataContract]
    public class AccountCurrenciesResponse : ResponseBase<AccountCurrenciesResponseResult>
    {
    }

    /// <summary>
    /// Represents the result of <see cref="AccountChannelsResponse"/> object.
    /// </summary>
    [DataContract]
    public class AccountCurrenciesResponseResult : ResultBase
    {
        /// <summary>
        /// The identifying hash of the ledger version used to retrieve this data, as hex.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The ledger index of the ledger version used to retrieve this data.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// Array of Token Codes for currencies that this account can receive.
        /// </summary>
        [JsonPropertyName("receive_currencies")]
        public string[]? ReceiveCurrencies { get; set; }

        /// <summary>
        /// Array of Token Codes for currencies that this account can send.
        /// </summary>
        [JsonPropertyName("send_currencies")]
        public string[]? SendCurrencies { get; set; }

        /// <summary>
        /// If true, this data comes from a validated ledger.
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }
}