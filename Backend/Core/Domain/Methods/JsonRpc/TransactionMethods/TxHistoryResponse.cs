using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.TransactionMethods
{
    /// <summary>
    /// Represents a response to a transaction history request.
    /// </summary>

    public record TxHistoryResponse : Result
    {
    }

    /// <summary>
    /// Specifies a result of an <see cref="TxHistoryResponse"/> object.
    /// </summary>

    public record TxHistoryResult : Result
    {
        /// <summary>
        /// The value of start used in the request.
        /// </summary>
        [JsonPropertyName("index")]
        public uint Index { get; init; }

        /// <summary>
        /// Array of transaction objects.
        /// </summary>
        [JsonPropertyName("txs")]
        public string? Txs { get; init; }
    }
}