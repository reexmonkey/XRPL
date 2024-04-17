using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to a transaction history request.
    /// </summary>
    [DataContract]
    public class TxHistoryResponse : ResponseBase<TxHistoryResult>
    {
    }

    /// <summary>
    /// Specifies a result of an <see cref="TxHistoryResponse"/> object.
    /// </summary>
    [DataContract]
    public class TxHistoryResult : ResultBase
    {
        /// <summary>
        /// The value of start used in the request.
        /// </summary>
        [DataMember(Name = "index")]
        public uint Index { get; set; }

        /// <summary>
        /// Array of transaction objects.
        /// </summary>
        [DataMember(Name = "txs")]
        public string? Txs { get; set; }
    }
}