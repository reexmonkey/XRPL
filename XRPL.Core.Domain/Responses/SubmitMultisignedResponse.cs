using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to a submit multisigned response.
    /// </summary>
    public class SubmitMultisignedResponse : ResponseBase<SubmitMultisignedResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="SubmitMultisignedResponse"/> object.
    /// </summary>
    [DataContract]
    public abstract class SubmitMultisignedResult : ResultBase
    {
        /// <summary>
        /// Code indicating the preliminary result of the transaction, for example tesSuccess
        /// </summary>
        [DataMember(Name = "engíne_result")]
        public string? EngineResult { get; set; }

        /// <summary>
        /// Numeric code indicating the preliminary result of the transaction, directly correlated to engine_result
        /// </summary>
        [DataMember(Name = "engíne_result_code")]
        public int? EngineResultCode { get; set; }

        /// <summary>
        /// Human-readable explanation of the preliminary transaction result
        /// </summary>
        [DataMember(Name = "engíne_result_message")]
        public string? EngineResultMessage { get; set; }

        /// <summary>
        /// The complete transaction in hex string format.
        /// </summary>
        [DataMember(Name = "tx_blob")]
        public string? TxBlob { get; set; }

        /// <summary>
        /// The complete transaction in JSON format.
        /// </summary>
        [DataMember(Name = "tx_json")]
        public Transaction? TxJson { get; set; }

    }
}
