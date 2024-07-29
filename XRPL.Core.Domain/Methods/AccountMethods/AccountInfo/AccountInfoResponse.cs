using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountInfo
{
    /// <summary>
    /// Represents a response that encapsulates information about an account, its activity, and its XRP balance.
    /// </summary>

    public class AccountInfoResponse : ResponseBase<AccountInfoResult>
    {
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountInfoResponse"/> object.
    /// </summary>

    public class AccountInfoResult : ResultBase
    {
        /// <summary>
        /// The AccountRoot ledger object with this account's information, as stored in the ledger.
        /// </summary>
        [JsonPropertyName("account_data")]
        public required AccountRoot AccountData { get; set; }

        /// <summary>
        /// The account's flag statuses (see below), based on the <see cref="LedgerEntryBase.Flags"/> field of the account.
        /// </summary>
        [JsonPropertyName("account_flags")]
        public required AccountFlags AccountFlags { get; set; }

        /// <summary>
        /// <para/>API v1: (Omitted unless the request specified <see cref="SignerLists"/>
        /// and at least one <see cref="SignerList"/> is associated with the account.)
        /// Array of <see cref="SignerList"/> ledger objects associated with this account for Multi-Signing.
        /// Since an account can own at most one <see cref="SignerList"/>, this array must have exactly one member if it is present.
        /// The field is nested under <see cref="AccountData"/>.
        /// <para/>API v2: Identical to API v1, but the field is returned in the root response instead.
        /// Clio implements the API v2 behavior in all cases.
        /// </summary>
        [JsonPropertyName("signer_lists")]
        public required SignerList[] SignerLists { get; set; }

        /// <summary>
        /// (Omitted if ledger_index is provided instead) The ledger index of the current in-progress ledger,
        /// which was used when retrieving this information.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; set; }

        /// <summary>
        /// (Omitted if ledger_current_index is provided instead) The ledger index of the ledger version used when retrieving this information.
        /// <para/>The information does not contain any changes from ledger versions newer than this one.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// (Omitted unless queue specified as true and querying the current open ledger.)
        /// Information about queued transactions sent by this account. This information describes the state of the local rippled server,
        /// which may be different from other servers in the peer-to-peer XRP Ledger network.
        /// Some fields may be omitted because the values are calculated "lazily" by the queuing mechanism.
        /// </summary>
        [JsonPropertyName("queue_data")]
        public QueueData? QueueData { get; set; }

        /// <summary>
        /// True if this data is from a validated ledger version; if omitted or set to false, this data is not final.
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }

    /// <summary>
    /// Represents the statuses of an account based on the <see cref="LedgerEntryBase.Flags"/> field of the account.
    /// </summary>
    public class AccountFlags
    {
        /// <summary>
        /// If true, the account allows rippling on its trust lines by default.
        /// </summary>
        [JsonPropertyName("defaultRipple")]
        public bool DefaultRipple { get; set; }

        /// <summary>
        /// If true, the account is using Deposit Authorization and does not accept any payments from unknown parties.
        /// </summary>
        [JsonPropertyName("depositAuth")]
        public bool DepositAuth { get; set; }

        /// <summary>
        /// If true, the account's master key pair is disabled.
        /// </summary>
        [JsonPropertyName("disableMasterKey")]
        public bool DisableMasterKey { get; set; }

        /// <summary>
        /// If true, the account does not allow others to send Checks to it. (Requires the DisallowIncoming amendment)
        /// </summary>
        [JsonPropertyName("disallowIncomingCheck")]
        public bool DisallowIncomingCheck { get; set; }

        /// <summary>
        /// If true, the account does not allow others to make NFT buy or sell offers to it. (Requires the DisallowIncoming amendment)
        /// </summary>
        [JsonPropertyName("disallowIncomingNFTokenOffer")]
        public bool DisallowIncomingNFTokenOffer { get; set; }

        /// <summary>
        /// If true, the account does not allow others to make Payment Channels to it. (Requires the DisallowIncoming amendment)
        /// </summary>
        [JsonPropertyName("disallowIncomingPayChan")]
        public bool DisallowIncomingPayChan { get; set; }

        /// <summary>
        /// If true, the account does not allow others to make trust lines to it. (Requires the DisallowIncoming amendment)
        /// </summary>
        [JsonPropertyName("disallowIncomingTrustline")]
        public bool DisallowIncomingTrustline { get; set; }

        /// <summary>
        /// If true, the account does not want to receive XRP from others.
        /// <para/>(This is advisory, and not enforced at a protocol level.)
        /// </summary>
        [JsonPropertyName("disallowIncomingXRP")]
        public bool DisallowIncomingXRP { get; set; }

        /// <summary>
        /// If true, all tokens issued by the account are currently frozen.
        /// </summary>
        [JsonPropertyName("globalFreeze")]
        public bool GlobalFreeze { get; set; }

        /// <summary>
        /// If true, the account has permanently given up the abilities to freeze individual trust lines or end a global freeze.
        /// <para/>See No Freeze for details.
        /// </summary>
        [JsonPropertyName("noFreeze")]
        public bool NoFreeze { get; set; }

        /// <summary>
        /// If false, the account can send a special key reset transaction with a transaction cost of 0.
        /// <para/>The protocol turns this flag on and off automatically; it is not controlled by a user-facing setting.
        /// </summary>
        [JsonPropertyName("passwordSpent")]
        public bool PasswordSpent { get; set; }

        /// <summary>
        /// If true, the account is using Authorized Trust Lines to limit who can hold the tokens it issues.
        /// </summary>
        [JsonPropertyName("requireAuthorization")]
        public bool RequireAuthorization { get; set; }

        /// <summary>
        /// If true, the account requires a destination tag on all payments it receives.
        /// </summary>
        [JsonPropertyName("requireDestinationTag")]
        public bool RequireDestinationTag { get; set; }
    }

    /// <summary>
    /// Represents information about queued transactions sent by an account.
    /// </summary>
    public class QueueData
    {
        /// <summary>
        /// Whether this transaction changes this address's ways of authorizing transactions.
        /// </summary>
        [JsonPropertyName("auth_change")]
        public required bool AuthChange { get; set; }

        /// <summary>
        /// The transaction cost of this transaction, in drops of XRP.
        /// </summary>
        [JsonPropertyName("fee")]
        public required string Fee { get; set; }

        /// <summary>
        /// The transaction cost of this transaction, relative to the minimum cost for this type of transaction, in fee levels.
        /// </summary>
        [JsonPropertyName("fee_level")]
        public required string FeeLevel { get; set; }

        /// <summary>
        /// The maximum amount of XRP, in drops, this transaction could send or destroy.
        /// </summary>
        [JsonPropertyName("max_spend_drops")]
        public required string MaxSpendDrops { get; set; }

        /// <summary>
        /// The sequence number of this transaction.
        /// </summary>
        [JsonPropertyName("seq")]
        public required int Seq { get; set; }
    }
}
