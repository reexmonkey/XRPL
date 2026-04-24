using System.Text.Json.Serialization;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents the response to an account transaction request, containing the result of the operation.
    /// </summary>
    public record AccountTxResponse : Response
    {
        /// <summary>
        /// Gets the result of an <see cref="AccountTxResponse"/> request.
        /// </summary>
        [JsonPropertyName("result")]
        public required AccountTxResult Result { get; init; }
    }

    /// <summary>
    /// Represents a result of an <see cref="AccountTxResponse"/> object.
    /// </summary>
    public record AccountTxResult : Result
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
        public required int LedgerIndexMin { get; set; }

        /// <summary>
        /// The ledger index of the most recent ledger actually searched for transactions.
        /// </summary>
        [JsonPropertyName("ledger_index_max")]
        public required int LedgerIndexMax { get; set; }

        /// <summary>
        /// The limit value used in the request. (This may differ from the actual limit value enforced by the server.)
        /// </summary>
        [JsonPropertyName("limit")]
        public required uint Limit { get; set; }

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
    public abstract record AccountTransaction
    {
        /// <summary>
        /// The ledger index of the ledger version that included this transaction.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; set; }

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
    public record BinaryAccountTransaction : AccountTransaction
    {
        /// <summary>
        /// The hex string of the transaction metadata.
        /// </summary>
        [JsonPropertyName("meta")]
        public required string Meta { get; init; }

        /// <summary>
        /// Unique hashed string representing the transaction.
        /// </summary>
        [JsonPropertyName("tx_blob")]
        public required string TxBlob { get; set; }
    }

    /// <summary>
    /// Represents a JSON-based transaction matching the criteria of an <see cref="AccountTxRequest"/>.
    /// </summary>
    public record JsonAccountTransaction : AccountTransaction
    {
        /// <summary>
        /// The transaction metadata is included in JSON format.
        /// </summary>
        [JsonPropertyName("meta")]
        public required TransactionMetadata Meta { get; init; }

        /// <summary>
        /// JSON object defining the transaction.
        /// </summary>
        [JsonPropertyName("tx_json")]
        public Transaction? TxJson { get; set; }
    }

    [JsonSerializable(typeof(AccountTxResult))]
    [JsonSerializable(typeof(BinaryAccountTransaction))]
    [JsonSerializable(typeof(JsonAccountTransaction))]
    public partial class AccountTxResultContext : JsonSerializerContext;

    [JsonSerializable(typeof(JsonAccountTransaction))]
    [JsonSerializable(typeof(AccountDelete))]
    [JsonSerializable(typeof(AccountSet))]
    [JsonSerializable(typeof(AMMBid))]
    [JsonSerializable(typeof(AMMClawback))]
    [JsonSerializable(typeof(AMMCreate))]
    [JsonSerializable(typeof(AMMCreate))]
    [JsonSerializable(typeof(AMMDelete))]
    [JsonSerializable(typeof(AMMDeposit))]
    [JsonSerializable(typeof(AMMVote))]
    [JsonSerializable(typeof(AMMWithdraw))]
    [JsonSerializable(typeof(CheckCancel))]
    [JsonSerializable(typeof(CheckCash))]
    [JsonSerializable(typeof(CheckCreate))]
    [JsonSerializable(typeof(Clawback))]
    [JsonSerializable(typeof(CredentialAccept))]
    [JsonSerializable(typeof(CredentialCreate))]
    [JsonSerializable(typeof(CredentialDelete))]
    [JsonSerializable(typeof(DepositPreauth))]
    [JsonSerializable(typeof(DIDDelete))]
    [JsonSerializable(typeof(DIDSet))]
    [JsonSerializable(typeof(EscrowCancel))]
    [JsonSerializable(typeof(EscrowCreate))]
    [JsonSerializable(typeof(EscrowFinish))]
    [JsonSerializable(typeof(MPTokenIssuanceCreate))]
    [JsonSerializable(typeof(MPTokenIssuanceDestroy))]
    [JsonSerializable(typeof(MPTokenIssuanceSet))]
    [JsonSerializable(typeof(NFTokenAcceptOffer))]
    [JsonSerializable(typeof(DirectNFTokenAcceptOffer))]
    [JsonSerializable(typeof(BrokeredNFTokenAcceptOffer))]
    [JsonSerializable(typeof(NFTokenBurn))]
    [JsonSerializable(typeof(NFTokenCancelOffer))]
    [JsonSerializable(typeof(NFTokenCreateOffer))]
    [JsonSerializable(typeof(NFTokenMint))]
    [JsonSerializable(typeof(NFTokenModify))]
    [JsonSerializable(typeof(OfferCancel))]
    [JsonSerializable(typeof(OfferCreate))]
    [JsonSerializable(typeof(OracleDelete))]
    [JsonSerializable(typeof(OracleSet))]
    [JsonSerializable(typeof(Payment))]
    [JsonSerializable(typeof(PaymentChannelClaim))]
    [JsonSerializable(typeof(PaymentChannelCreate))]
    [JsonSerializable(typeof(PaymentChannelFund))]
    [JsonSerializable(typeof(PermissionedDomainDelete))]
    [JsonSerializable(typeof(PermissionedDomainSet))]
    [JsonSerializable(typeof(SetRegularKey))]
    [JsonSerializable(typeof(SignerListSet))]
    [JsonSerializable(typeof(TicketCreate))]
    [JsonSerializable(typeof(TrustSet))]
    public partial class JsonAccountTransactionContext : JsonSerializerContext;
}
