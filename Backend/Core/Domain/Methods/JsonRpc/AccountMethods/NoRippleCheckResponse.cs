using System.Text.Json.Serialization;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a response that encapsulates a list of validated transactions that involve a given account.
    /// </summary>

    public record NoRippleCheckResponse : Response
    {
        /// <summary>
        /// Gets the result of a <see cref="NoRippleCheckResponse"/> request.
        /// </summary>
        [JsonPropertyName("result")]
        public required NoRippleCheckResult Result { get; init; }
    }

    /// <summary>
    /// Represents a result of an <see cref="NoRippleCheckResponse"/> object.
    /// </summary>
    public record NoRippleCheckResult : Result
    {
        /// <summary>
        /// The ledger index of the ledger used to calculate these results.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int LedgerCurrentIndex { get; init; }

        /// <summary>
        /// Array of strings with human-readable descriptions of the problems.
        /// <para/>This includes up to one entry if the account's Default Ripple setting is not as recommended, plus up to limit entries for trust lines whose No Ripple setting is not as recommended.
        /// </summary>
        [JsonPropertyName("problems")]
        public string[] Problems { get; init; } = [];

        /// <summary>
        /// (May be omitted) If the request specified transactions as true, this is an array of JSON objects, each of which is the JSON form of a transaction that should fix one of the described problems.
        /// <para/>The length of this array is the same as the problems array, and each entry is intended to fix the problem described at the same index into that array.
        /// </summary>
        [JsonPropertyName("transactions")]
        public Transaction[]? Transactions { get; init; }
    }


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
    public partial class NoRippleCheckResultContext : JsonSerializerContext;
}
