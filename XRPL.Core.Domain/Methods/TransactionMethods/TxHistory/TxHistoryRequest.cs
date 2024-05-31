using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.TransactionMethods.TxHistory
{
    /// <summary>
    /// Represents a request that retrieves some of the most recent transactions made.
    /// </summary>

    public class TxHistoryRequest : RequestBase<TxHistoryParameters>, IExpect<TxHistoryResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxHistoryRequest"/> class.
        /// </summary>
        public TxHistoryRequest() : base("tx_history")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="TxHistoryRequest"/> object.
    /// </summary>

    public class TxHistoryParameters : ParameterBase
    {
        /// <summary>
        /// Number of transactions to skip over.
        /// </summary>
        [JsonPropertyName("start")]
        public string? Start { get; set; }
    }
}