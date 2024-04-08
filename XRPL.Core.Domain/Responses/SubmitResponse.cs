using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to a submit response.
    /// </summary>
    [DataContract]
    public class SubmitResponse : ResponseBase<SubmitResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="SubmitResponse"/> object.
    /// </summary>
    [DataContract]
    public abstract class SubmitResult : ResultBase
    {
        /// <summary>
        /// Text result code indicating the preliminary result of the transaction, for example tesSUCCESS.
        /// </summary>
        [DataMember(Name = "engine_result")]
        public int EngineResult { get; set; }

        /// <summary>
        /// Numeric version of the result code. Not recommended.
        /// </summary>
        [DataMember(Name = "engine_result_code")]
        public int? EngineResultCode { get; set; }

        /// <summary>
        /// Human-readable explanation of the transaction's preliminary result.
        /// </summary>
        [DataMember(Name = "engine_result_message")]
        public string? EngineResultMessage { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The value true indicates that the transaction was applied, queued, broadcast, or kept for later.
        /// The value false indicates that none of those happened,
        /// so the transaction cannot possibly succeed as long as you do not submit it again and have not already submitted it another time.
        /// </summary>
        [DataMember(Name = "accepted")]
        public bool? Accepted { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The next Sequence Number available for the sending account after all pending and queued transactions.
        /// </summary>
        [DataMember(Name = "account_sequence_available")]
        public uint? AccountSequenceAvailable { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode)
        /// The next Sequence Number for the sending account after all transactions that have been provisionally applied, but not transactions in the queue.
        /// </summary>
        [DataMember(Name = "account_sequence_available")]
        public uint? AccountSequenceNext { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode)
        /// The value true indicates that this transaction was applied to the open ledger.
        /// In this case, the transaction is likely, but not guaranteed, to be validated in the next ledger version.
        /// </summary>
        [DataMember(Name = "applied")]
        public bool? Applied { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode)
        /// The value true indicates this transaction was broadcast to peer servers in the peer-to-peer XRP Ledger network.
        /// (Note: if the server has no peers, such as in stand-alone mode, the server uses the value true for cases where it would have broadcast the transaction.) The value false indicates the transaction was not broadcast to any other servers.
        /// </summary>
        [DataMember(Name = "broadcast")]
        public bool? Broadcast { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The value true indicates that the transaction was kept to be retried later.
        /// </summary>
        [DataMember(Name = "kept")]
        public bool? Kept { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode)
        /// The value true indicates the transaction was put in the Transaction Queue, which means it is likely to be included in a future ledger version.
        /// </summary>
        [DataMember(Name = "queued")]
        public bool? Queued { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The ledger index of the newest validated ledger at the time of submission.
        /// This provides a lower bound on the ledger versions that the transaction can appear in as a result of this request.
        /// (The transaction could only have been validated in this ledger version or earlier if it had already been submitted before.)
        /// </summary>
        [DataMember(Name = "open_ledger_cost")]
        public string? OpenLedgerCost { get; set; }

        /// <summary>
        /// (Omitted in sign-and-submit mode) The ledger index of the newest validated ledger at the time of submission. This provides a lower bound on the ledger versions that the transaction can appear in as a result of this request. (The transaction could only have been validated in this ledger version or earlier if it had already been submitted before.)
        /// </summary>
        [DataMember(Name = "validated_ledger_index")]
        public int? ValidatedLedgerIndex { get; set; }
    }

    public sealed class BinarySubmitResult : SubmitResult
    {
        /// <summary>
        /// The complete transaction in hex string format.
        /// </summary>
        [DataMember(Name = "tx_blob")]
        public string? TxBlob { get; set; }
    }

    public sealed class JsonSubmitResult : SubmitResult
    {
        /// <summary>
        /// The complete transaction in JSON format.
        /// </summary>
        [DataMember(Name = "tx_json")]
        public Transaction? TxJson { get; set; }
    }
}