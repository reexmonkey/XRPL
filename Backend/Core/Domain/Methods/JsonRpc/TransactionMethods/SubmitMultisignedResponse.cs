using System.Text.Json.Serialization;
using System.Transactions;

namespace XRPL.Core.Domain.Methods.JsonRpc.TransactionMethods
{
    /// <summary>
    /// Represents a response to a submit multisigned response.
    /// </summary>
    public record SubmitMultisignedResponse : Response
    {
        [JsonPropertyName("result")]
        public required SubmitMultisignedResult Result { get; init; }
    }

    /// <summary>
    /// Represents a result of an <see cref="SubmitMultisignedResponse"/> object.
    /// </summary>
    public record SubmitMultisignedResult : Result
    {
        /// <summary>
        /// Code indicating the preliminary result of the transaction, for example tesSuccess
        /// </summary>
        [JsonPropertyName("engíne_result")]
        public required string EngineResult { get; init; }

        /// <summary>
        /// Numeric code indicating the preliminary result of the transaction, directly correlated to engine_result
        /// </summary>
        [JsonPropertyName("engíne_result_code")]
        public required int EngineResultCode { get; init; }

        /// <summary>
        /// Human-readable explanation of the preliminary transaction result
        /// </summary>
        [JsonPropertyName("engíne_result_message")]
        public required string EngineResultMessage { get; init; }

        /// <summary>
        /// The complete transaction in hex string format.
        /// </summary>
        [JsonPropertyName("tx_blob")]
        public required string TxBlob { get; init; }

        /// <summary>
        /// The complete transaction in JSON format.
        /// </summary>
        [JsonPropertyName("tx_json")]
        public required Transaction TxJson { get; init; }
    }
}