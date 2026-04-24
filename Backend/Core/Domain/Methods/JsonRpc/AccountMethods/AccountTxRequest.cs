using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a request that retrieves a list of validated transactions that involve a given account.
    /// </summary>
    public record AccountTxRequest : Request, IExpect<AccountTxResponse>
    {
        /// <summary>
        /// Gets the collection of parameters used to specify additional details for the account transaction.
        /// </summary>
        /// <remarks>This property holds an array of transaction parameters that can be provided to
        /// customize the behavior or filtering of the account transaction request. The array may be null if no
        /// parameters are specified.</remarks>

        [JsonPropertyName("params")]
        public AccountTxParameters[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTxRequest"/> record.
        /// </summary>
        public AccountTxRequest() : base("account_tx")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountTxRequest"/> object.
    /// </summary>

    public record AccountTxParameters : Parameter
    {
        /// <summary>
        /// A unique identifier for the account, most commonly the account's address.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// API v1: (Optional) Use to specify the earliest ledger to include transactions from.
        /// A value of -1 instructs the server to use the earliest validated ledger version available.
        /// <para/>API v2: Identical to v1, but also returns a lgrIdxMalformed error if a value is specified beyond the range of ledgers the server has.
        /// </summary>
        [JsonPropertyName("ledger_index_min")]
        public int? LedgerIndexMin { get; init; }

        /// <summary>
        /// API v1: (Optional) Use to specify the most recent ledger to include transactions from. A value of -1 instructs the server to use the most recent validated ledger version available.
        /// <para/>API v2: Identical to v1, but also returns a lgrIdxMalformed error if a value is specified beyond the range of ledgers the server has.
        /// </summary>
        [JsonPropertyName("ledger_index_max")]
        public int? LedgerIndexMax { get; init; }

        /// <summary>
        /// (Optional) Use to look for transactions from a single ledger only.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// (Optional) Use to look for transactions from a single ledger only.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; init; }

        /// <summary>
        /// API v1: (Optional) Defaults to false. If set to true, returns transactions as hex strings instead of JSON.
        /// <para/>API v2: Identical to v1, but also returns an invalidParams error if you provide a non-boolean value.
        /// </summary>
        [JsonPropertyName("binary")]
        public bool? Binary { get; init; }

        /// <summary>
        /// API v1: (Optional) Defaults to false. If set to true, returns values indexed with the oldest ledger first. Otherwise, the results are indexed with the newest ledger first.
        /// (Each page of results may not be internally ordered, but the pages are overall ordered.)
        /// <para/>API v2: Identical to v1, but also returns an invalidParams error if you provide a non-boolean value.
        /// </summary>
        [JsonPropertyName("forward")]
        public bool? Forward { get; init; }

        /// <summary>
        /// (Optional) Default varies. Limit the number of transactions to retrieve. The server is not required to honor this value.
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; init; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// <para/>This value is stable even if there is a change in the server's range of available ledgers.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }
    }
}
