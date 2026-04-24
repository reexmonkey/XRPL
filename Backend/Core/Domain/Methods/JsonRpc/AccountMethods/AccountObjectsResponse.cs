using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents the response returned from an account objects query executed via the JSON-RPC API. Provides access to
    /// the result data specific to the command issued.
    /// </summary>
    /// <remarks>The structure and contents of the result depend on the particular command used in the query.
    /// Refer to the command documentation for details about the expected result format and fields.</remarks>
    public record AccountObjectsResponse : Response
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        [JsonPropertyName("result")]
        public required AccountObjectsResult Result { get; set; }
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountObjectsResponse"/> object.
    /// </summary>
    public record AccountObjectsResult : Result
    {
        /// <summary>
        /// Unique Address of the account this request corresponds to.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// Array of objects owned by this account. Each object is in its raw ledger format.
        /// </summary>
        [JsonPropertyName("account_objects")]
        public required LedgerEntry[] AccountObjects { get; init; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public required string LedgerHash { get; init; }

        /// <summary>
        /// (May be omitted) The ledger index of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; init; }

        /// <summary>
        /// (May be omitted) The ledger index of the current in-progress ledger version, which was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; init; }

        /// <summary>
        /// (May be omitted) The limit that was used in this request, if any.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; init; }

        /// <summary>
        /// Server-defined value for pagination. Pass this to the next call to resume getting results where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }

        /// <summary>
        /// If included and set to true, the information in this response comes from a validated ledger version.
        /// <para/>Otherwise, the information is subject to change
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; init; }
    }
}
