using System.Text.Json.Serialization;
using System.Transactions;

namespace XRPL.Core.Domain.Methods.TransactionMethods.Submit
{
    /// <summary>
    /// Represents a response to a submit response.
    /// </summary>
    public class SubmitResponse : ResponseBase<SubmitResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="SubmitResponse"/> object.
    /// <para/>Caution: If this command results in an error message, the message can contain the secret key from the request. (This can only happen in sign-and-submit mode.) Make sure that these errors are not visible to others.
    /// <para/>- Do not write an error including your secret key to a log file that can be seen by multiple people.
    /// <para/>- Do not paste an error including your secret key to a public place for debugging.
    /// <para/>- Do not display an error message including your secret key on a website, even by accident.
    /// </summary>
    public class SubmitResult : ResultBase
    {
        /// <summary>
        /// Text result code indicating the preliminary result of the transaction, for example tesSUCCESS.
        /// </summary>
        [JsonPropertyName("engine_result")]
        public required string EngineResult { get; set; }

        /// <summary>
        /// Numeric version of the result code. Not recommended.
        /// </summary>
        [JsonPropertyName("engine_result_code")]
        [Obsolete("Not recommended.")]
        public int? EngineResultCode { get; set; }

        /// <summary>
        /// Human-readable explanation of the transaction's preliminary result.
        /// </summary>
        [JsonPropertyName("engine_result_message")]
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

        /// <summary>
        /// (Omitted in sign-and-submit mode) The value true indicates that the transaction was applied, queued, broadcast, or kept for later.
        /// The value false indicates that none of those happened,
        /// so the transaction cannot possibly succeed as long as you do not submit it again and have not already submitted it another time.
        /// </summary>
        [JsonPropertyName("accepted")]
        public bool? Accepted { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The next Sequence Number available for the sending account after all pending and queued transactions.
        /// </summary>
        [JsonPropertyName("account_sequence_available")]
        public uint? AccountSequenceAvailable { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode)
        /// The next Sequence Number for the sending account after all transactions that have been provisionally applied, but not transactions in the queue.
        /// </summary>
        [JsonPropertyName("account_sequence_available")]
        public uint? AccountSequenceNext { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode)
        /// The value true indicates that this transaction was applied to the open ledger.
        /// In this case, the transaction is likely, but not guaranteed, to be validated in the next ledger version.
        /// </summary>
        [JsonPropertyName("applied")]
        public bool? Applied { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode)
        /// The value true indicates this transaction was broadcast to peer servers in the peer-to-peer XRP Ledger network.
        /// (Note: if the server has no peers, such as in stand-alone mode, the server uses the value true for cases where it would have broadcast the transaction.) The value false indicates the transaction was not broadcast to any other servers.
        /// </summary>
        [JsonPropertyName("broadcast")]
        public bool? Broadcast { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The value true indicates that the transaction was kept to be retried later.
        /// </summary>
        [JsonPropertyName("kept")]
        public bool? Kept { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode)
        /// The value true indicates the transaction was put in the Transaction Queue, which means it is likely to be included in a future ledger version.
        /// </summary>
        [JsonPropertyName("queued")]
        public bool? Queued { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The ledger index of the newest validated ledger at the time of submission.
        /// This provides a lower bound on the ledger versions that the transaction can appear in as a result of this request.
        /// (The transaction could only have been validated in this ledger version or earlier if it had already been submitted before.)
        /// </summary>
        [JsonPropertyName("open_ledger_cost")]
        public string? OpenLedgerCost { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The ledger index of the newest validated ledger at the time of submission. This provides a lower bound on the ledger versions that the transaction can appear in as a result of this request. (The transaction could only have been validated in this ledger version or earlier if it had already been submitted before.)
        /// </summary>
        [JsonPropertyName("validated_ledger_index")]
        public int? ValidatedLedgerIndex { get; set; }
    }
}
