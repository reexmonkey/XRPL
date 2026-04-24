using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents the request to retrieve a list of currencies that an account can send or receive, based on its trust lines.
    /// <para/>(This is not a thoroughly confirmed list, but it can be used to populate user interfaces.)
    /// </summary>
    public record AccountCurrenciesRequest : Request, IExpect<AccountCurrenciesResponse>
    {
        /// <summary>
        /// A one-item array containing a nested JSON object with the parameters to this method. You may omit this field if the method does not require any parameters.
        /// </summary>
        [JsonPropertyName("params")]
        public AccountCurrenciesParameters[]? Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCurrenciesRequest"/> record.
        /// </summary>
        public AccountCurrenciesRequest() : base("account_currencies")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountCurrenciesRequest"/> object.
    /// </summary>

    public record AccountCurrenciesParameters : Parameter
    {
        /// <summary>
        /// Look up currencies this account can send or receive.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; set; }
    }
}
