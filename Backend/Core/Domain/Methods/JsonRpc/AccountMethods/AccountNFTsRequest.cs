using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a request to return a list of NFToken objects for the specified account.
    /// </summary>

    public record AccountNFTsRequest : Request, IExpect<AccountNFTsResponse>
    {

        /// <summary>
        /// Gets the array of parameters used to filter or customize the account NFTs request.
        /// </summary>
        /// <remarks>Each element in the array specifies criteria or options that influence how account
        /// NFTs are retrieved. Use this property to provide additional filtering or detail for the request as
        /// needed.</remarks>
        [JsonPropertyName("params")]
        public AccountNFTsParameters[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountNFTsRequest"/> record.
        /// </summary>
        public AccountNFTsRequest() : base("account_nfts")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountNFTsRequest"/> object.
    /// </summary>
    public record AccountNFTsParameters : Parameter
    {
        /// <summary>
        /// The unique identifier of an account, typically the account's Address.
        /// <para/>The request returns a list of NFTs owned by this account.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; init; }

        /// <summary>
        /// (Optional) Limit the number of token pages to retrieve. Each page can contain up to 32 NFTs.
        /// <para/>The limit value cannot be lower than 20 or more than 400.
        /// Positive values outside this range are replaced with the closest valid option.
        /// The default is 100.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint Limit { get; init; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }
    }
}
