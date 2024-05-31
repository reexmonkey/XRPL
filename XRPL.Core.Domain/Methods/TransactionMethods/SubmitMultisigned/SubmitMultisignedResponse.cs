using System.Text.Json.Serialization;
using System.Transactions;

namespace XRPL.Core.Domain.Methods.TransactionMethods.SubmitMultisigned
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
    public class SubmitMultisignedResult : ResultBase
    {
        /// <summary>
        /// Code indicating the preliminary result of the transaction, for example tesSuccess
        /// </summary>
        [JsonPropertyName("engíne_result")]
        public required string EngineResult { get; set; }

        /// <summary>
        /// Numeric code indicating the preliminary result of the transaction, directly correlated to engine_result
        /// </summary>
        [JsonPropertyName("engíne_result_code")]
        public required int EngineResultCode { get; set; }

        /// <summary>
        /// Human-readable explanation of the preliminary transaction result
        /// </summary>
        [JsonPropertyName("engíne_result_message")]
        public required string EngineResultMessage { get; set; }

        /// <summary>
        /// The complete transaction in hex string format.
        /// </summary>
        [JsonPropertyName("tx_blob")]
        public required string TxBlob { get; set; }

        /// <summary>
        /// The complete transaction in JSON format.
        /// </summary>
        [JsonPropertyName("tx_json")]
        public required Transaction TxJson { get; set; }
    }
}
