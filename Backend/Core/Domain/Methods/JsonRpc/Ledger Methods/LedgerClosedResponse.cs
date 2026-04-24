using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    /// <summary>
    /// Represents the response to a request for closing a ledger in the XRPL.
    /// </summary>
    public record LedgerClosedResponse : Response
    {
        /// <summary>
        /// Gets the result of the ledger closure operation, including the outcome and any relevant details.
        /// </summary>
        public required LedgerClosedResult Result { get; init; }
    }

    /// <summary>
    /// Represents the result of a ledger closure operation, containing information about the closed ledger such as its hash and index.
    /// </summary>
    public record LedgerClosedResult: Result
    {
        /// <summary>
        /// The unique Hash of this ledger version, in hexadecimal.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }


        /// <summary>
        /// The ledger index of this ledger version.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int LedgerIndex { get; init; }
    }
}
