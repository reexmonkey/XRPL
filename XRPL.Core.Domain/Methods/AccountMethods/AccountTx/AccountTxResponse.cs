using System.Text.Json.Serialization;
using System.Transactions;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountTx
{
    /// <summary>
    /// Represents a response that encapsulates a list of validated transactions that involve a given account.
    /// </summary>
    public class AccountTxResponse : ResponseBase<AccountTxResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="AccountTxResponse"/> object.
    /// </summary>
    public class AccountTxResult : ResultBase
    {
        /// <summary>
        /// Unique Address identifying the related account
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        /// <summary>
        /// The ledger index of the earliest ledger actually searched for transactions.
        /// </summary>
        [JsonPropertyName("ledger_index_min")]
        public int? LedgerIndexMin { get; set; }

        /// <summary>
        /// The ledger index of the most recent ledger actually searched for transactions.
        /// </summary>
        [JsonPropertyName("ledger_index_max")]
        public int? LedgerIndexMax { get; set; }

        /// <summary>
        /// The limit value used in the request. (This may differ from the actual limit value enforced by the server.)
        /// </summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; }

        /// <summary>
        /// Server-defined value indicating the response is paginated. Pass this to the next call to resume where this call left off.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }

        /// <summary>
        /// Array of transactions matching the request's criteria, as explained below.
        /// </summary>
        [JsonPropertyName("transactions")]
        public AccountTransaction[]? Transactions { get; set; }

        /// <summary>
        /// If included and set to true, the information in this response comes from a validated ledger version.
        /// <para/>Otherwise, the information is subject to change
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }

    /// <summary>
    /// Specifies a transaction matching the criteria of an <see cref="AccountTxRequest"/>.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(BinaryAccountTransaction), typeDiscriminator: "binary")]
    [JsonDerivedType(typeof(JsonAccountTransaction), typeDiscriminator: "json")]
    public abstract class AccountTransaction
    {
        /// <summary>
        /// The ledger index of the ledger version that included this transaction.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// If <see cref="AccountTxParameters.Binary"/> is True, then this is a hex string of the transaction metadata. 
        /// Otherwise, the transaction metadata is included in JSON format.
        /// </summary>
        public virtual string Meta { get; set; } = null!;

        /// <summary>
        /// Whether or not the transaction is included in a validated ledger.
        /// Any transaction not yet in a validated ledger is subject to change.
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }

    /// <summary>
    /// Represents a binary transaction matching the criteria of an <see cref="AccountTxRequest"/>.
    /// </summary>
    [JsonDerivedType(typeof(BinaryAccountTransaction), typeDiscriminator: "binary")]
    public class BinaryAccountTransaction : AccountTransaction
    {
        /// <summary>
        /// The hex string of the transaction metadata.
        /// </summary>
        [JsonPropertyName("meta")]
        public override required string Meta { get => base.Meta; set => base.Meta = value; }

        /// <summary>
        /// Unique hashed string representing the transaction.
        /// </summary>
        [JsonPropertyName("tx_blob")]
        public string? TxBlob { get; set; }
    }

    /// <summary>
    /// Represents a JSON-based transaction matching the criteria of an <see cref="AccountTxRequest"/>.
    /// </summary>
    [JsonDerivedType(typeof(JsonAccountTransaction), typeDiscriminator: "json")]
    public sealed class JsonAccountTransaction : AccountTransaction
    {
        /// <summary>
        /// The transaction metadata is included in JSON format.
        /// </summary>
        [JsonPropertyName("meta")]
        public override required string Meta { get => base.Meta; set => base.Meta = value; }

        /// <summary>
        /// JSON object defining the transaction.
        /// </summary>
        [JsonPropertyName("tx")]
        public Transaction? Tx { get; set; }
    }
}