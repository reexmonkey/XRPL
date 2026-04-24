using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    /// <summary>
    /// Retrieve information about the public ledger.
    /// </summary>
    public record LedgerRequest : Request, IExpect<LedgerResponse>
    {
        /// <summary>
        /// Gets the collection of parameters used to configure the ledger operation.
        /// </summary>
        [JsonPropertyName("params")]
        public LedgerParameters[]? Parameters { get; init; }

        public LedgerRequest() : base("ledger")
        {
        }
    }

    /// <summary>
    /// Represents parameters for querying ledger information, including options for specifying ledger version,
    /// transaction details, and response formatting.
    /// </summary>
    /// <remarks>This record allows users to customize their requests for ledger data by providing various
    /// parameters that influence the response format and content. It is important to note that certain parameters may
    /// be ignored based on the values of others, such as 'Transactions' and 'Expand'.</remarks>
    public record LedgerParameters : Parameter
    {
        /// <summary>
        /// A 32-byte hex string for the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; init; }

        /// <summary>
        /// If true, return information on transactions in the specified ledger version.
        /// The default is false. Ignored if you did not specify a ledger version
        /// </summary>
        [JsonPropertyName("transactions")]
        public bool? Transactions { get; init; }

        /// <summary>
        /// Provide full JSON-formatted information for transaction/account information instead of only hashes.
        /// The default is false. Ignored unless you request transactions, accounts, or both.
        /// </summary>
        [JsonPropertyName("expand")]
        public bool? Expand { get; init; }

        /// <summary>
        /// If true, include owner_funds field in the metadata of OfferCreate transactions in the response.
        /// The default is false. Ignored unless transactions are included and expand is true.
        /// </summary>
        [JsonPropertyName("owner_funds")]
        public bool? OwnerFunds { get; init; }

        /// <summary>
        /// If true, and transactions and expand are both also true, return transaction information in binary format (hexadecimal string) instead of JSON format.
        /// </summary>
        [JsonPropertyName("binary")]
        public bool? Binary { get; init; }

        /// <summary>
        /// If true, and the command is requesting the current ledger, includes an array of queued transactions in the results.
        /// </summary>
        [JsonPropertyName("queue")]
        public bool? Queue { get; init; }
    }
}
