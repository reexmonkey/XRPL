using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a request that retrieves information about an account, its activity and its XRP balance.
    /// </summary>
    public record AccountInfoRequest : Request, IExpect<AccountInfoResponse>
    {
        /// <summary>
        /// A one-item array containing a nested JSON object with the parameters to this method. You may omit this field if the method does not require any parameters.
        /// </summary>
        [JsonPropertyName("params")]
        public AccountInfoRequestParameters[]? Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfoRequest"/> record.
        /// </summary>
        public AccountInfoRequest() : base("account_info")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountInfoRequest"/> object.
    /// </summary>

    public record AccountInfoRequestParameters : Parameter
    {
        /// <summary>
        /// The account to look up.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; init; }

        /// <summary>
        /// If true, return stats about queued transactions sent by this account. Can only be used when querying for the data from the current open ledger.
        /// </summary>
        [JsonPropertyName("queue")]
        public bool? Queue { get; init; }

        /// <summary>
        /// If true, return any signer list objects associated with this account.
        /// </summary>
        [JsonPropertyName("signer_lists")]
        public bool? SignerLists { get; init; }
    }
}
