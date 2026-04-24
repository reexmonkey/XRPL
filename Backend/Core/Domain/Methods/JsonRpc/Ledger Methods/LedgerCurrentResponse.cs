using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    /// <summary>
    /// Represents the response to a <see cref="LedgerCurrentRequest"/>, containing the result of the operation,
    /// which includes information about the current in-progress ledger such as its hash and index.
    /// </summary>
    public record LedgerCurrentResponse : Response
    {
        /// <summary>
        /// Gets the result of the ledger closure operation, including the outcome and any relevant details.
        /// </summary>
        public required LedgerCurrentResult Result { get; init; }
    }

    /// <summary>
    ///
    /// </summary>
    public record LedgerCurrentResult: Result
    {
        /// <summary>
        /// The ledger index of this ledger version.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int LedgerIndex { get; init; }
    }
}
