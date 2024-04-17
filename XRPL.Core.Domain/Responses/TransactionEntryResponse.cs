using System.Runtime.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to a submit response.
    /// </summary>
    [DataContract]
    public class TransactionEntryResponse : ResponseBase<TransactionEntryResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="TransactionEntryResponse"/> object.
    /// </summary>
    [DataContract]
    public class TransactionEntryResult : ResultBase
    {
        /// <summary>
        /// The ledger index of the ledger version the transaction was found in; this is the same as the one from the request.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public uint LedgerIndex { get; set; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger version the transaction was found in; this is the same as the one from the request.
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The transaction metadata, which shows the exact results of the transaction in detail.
        /// </summary>
        [DataMember(Name = "metadata")]
        public TransactionMetadata? Metadata { get; set; }

        /// <summary>
        /// JSON representation of the Transaction object
        /// </summary>
        [DataMember(Name = "tx_json")]
        public Transaction? TxJson { get; set; }
    }
}