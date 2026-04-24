using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.TransactionMethods
{
    /// <summary>
    /// Represents a request that retrieves some of the most recent transactions made.
    /// </summary>

    public record TxHistoryRequest : Request, IExpect<TxHistoryResponse>
    {
        [JsonPropertyName("params")]
        public TxHistoryParameter[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TxHistoryRequest"/> record.
        /// </summary>
        public TxHistoryRequest() : base("tx_history")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="TxHistoryRequest"/> object.
    /// </summary>

    public record TxHistoryParameter : Parameter
    {
        /// <summary>
        /// Number of transactions to skip over.
        /// </summary>
        [JsonPropertyName("start")]
        public string? Start { get; init; }
    }
}
