using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.TransactionMethods.TxHistory
{
    /// <summary>
    /// Represents a response to a transaction history request.
    /// </summary>

    public class TxHistoryResponse : ResponseBase<TxHistoryResult>
    {
    }

    /// <summary>
    /// Specifies a result of an <see cref="TxHistoryResponse"/> object.
    /// </summary>

    public class TxHistoryResult : ResultBase
    {
        /// <summary>
        /// The value of start used in the request.
        /// </summary>
        [JsonPropertyName("index")]
        public uint Index { get; set; }

        /// <summary>
        /// Array of transaction objects.
        /// </summary>
        [JsonPropertyName("txs")]
        public string? Txs { get; set; }
    }
}