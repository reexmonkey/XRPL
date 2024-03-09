using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response that encapsulates a list of validated transactions that involve a given account.
    /// </summary>
    [DataContract]
    public class AccountTxResponse : ResponseBase<AccountTxResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="AccountTxResponse"/> object.
    /// </summary>
    [DataContract]
    [KnownType(typeof(BinaryAccountTransaction))]
    [KnownType(typeof(JsonAccountTransaction))]
    public class AccountTxResult : ResultBase
    {
        /// <summary>
        /// Unique Address identifying the related account
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// The ledger index of the earliest ledger actually searched for transactions.
        /// </summary>
        [DataMember(Name = "ledger_index_min")]
        public int? LedgerIndexMin { get; set; }

        /// <summary>
        /// The ledger index of the most recent ledger actually searched for transactions.
        /// </summary>
        [DataMember(Name = "ledger_index_max")]
        public int? LedgerIndexMax { get; set; }

        /// <summary>
        /// The limit value used in the request. (This may differ from the actual limit value enforced by the server.)
        /// </summary>
        [DataMember(Name = "limit")]
        public uint? Limit { get; set; }

        /// <summary>
        /// Server-defined value indicating the response is paginated. Pass this to the next call to resume where this call left off.
        /// </summary>
        [DataMember(Name = "marker")]
        public object? Marker { get; set; }

        /// <summary>
        /// Array of transactions matching the request's criteria, as explained below.
        /// </summary>
        [DataMember(Name = "transactions")]
        public AccountTransaction[]? Transactions { get; set; }

        /// <summary>
        /// If included and set to true, the information in this response comes from a validated ledger version.
        /// <para/>Otherwise, the information is subject to change
        /// </summary>
        [DataMember(Name = "validated")]
        public bool Validated { get; set; }
    }

    [DataContract]
    public abstract class AccountTransaction
    {
        /// <summary>
        /// The ledger index of the ledger version that included this transaction.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// Whether or not the transaction is included in a validated ledger.
        /// Any transaction not yet in a validated ledger is subject to change.
        /// </summary>
        [DataMember(Name = "validated")]
        public bool Validated { get; set; }
    }

    [DataContract]
    public sealed class BinaryAccountTransaction : AccountTransaction
    {
        /// <summary>
        /// The hex string of the transaction metadata.
        /// </summary>
        [DataMember(Name = "meta")]
        public string? Meta { get; set; }

        /// <summary>
        /// Unique hashed String representing the transaction.
        /// </summary>
        [DataMember(Name = "tx_blob")]
        public string? TxBlob { get; set; }
    }

    [DataContract]
    public sealed class JsonAccountTransaction : AccountTransaction
    {
        /// <summary>
        /// The transaction metadata is included in JSON format.
        /// </summary>
        [DataMember(Name = "meta")]
        public string? Meta { get; set; }

        /// <summary>
        /// JSON object defining the transaction.
        /// </summary>
        [DataMember(Name = "tx")]
        public Transaction? Tx { get; set; }
    }
}