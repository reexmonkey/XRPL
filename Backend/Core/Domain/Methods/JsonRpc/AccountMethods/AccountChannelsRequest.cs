using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a request to get information about an account's payment channels.
    /// <para/> This includes only channels where the specified account is the channel's source, not the destination.
    /// (A channel's "source" and "owner" are the same.)
    /// All information retrieved is relative to a particular version of the ledger
    /// </summary>
    public record AccountChannelsRequest : Request, IExpect<AccountChannelsResponse>
    {
        /// <summary>
        /// A one-item array containing a nested JSON object with the parameters to this method. You may omit this field if the method does not require any parameters.
        /// </summary>
        [JsonPropertyName("params")]
        public AccountChannelsParameters[]? Parameters { get; set; }

        public AccountChannelsRequest() : base("account_channels")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountChannelsRequest"/> object.
    /// </summary>
    public record AccountChannelsParameters : Parameter
    {
        /// <summary>
        /// Look up channels where this account is the channel's owner/source
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// A second account; if provided, filter results to payment channels whose destination is this account.
        /// </summary>
        [JsonPropertyName("destination_account")]
        public string? DestinationAccount { get; init; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; init; }

        /// <summary>
        /// Limit the number of transactions to retrieve.
        /// <para/>Cannot be less than 10 or more than 400. Positive values outside this range are replaced with the closest valid option.
        /// The default is 200.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; init; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }
    }

    [JsonSerializable(typeof(AccountChannelsParameters))]
    [JsonSerializable(typeof(string))]
    public partial class AccountChannelsParametersContext : JsonSerializerContext;
}
