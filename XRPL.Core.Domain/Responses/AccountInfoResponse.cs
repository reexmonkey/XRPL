using System.Runtime.Serialization;
using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response that encapsulates information about an account, its activity, and its XRP balance.
    /// </summary>
    [DataContract]
    public class AccountInfoResponse : ResponseBase<AccountInfoResult>
    {
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountInfoResponse"/> object.
    /// </summary>
    [DataContract]
    public class AccountInfoResult : ResultBase
    {
        /// <summary>
        /// The AccountRoot ledger object with this account's information, as stored in the ledger.
        /// </summary>
        [DataMember(Name = "account_data")]
        public AccountRoot? AccountData { get; set; }

        /// <summary>
        /// The account's flag statuses (see below), based on the <see cref="AccountRoot.Flags"/> field of the account.
        /// </summary>
        [DataMember(Name = "account_flags")]
        public AccountFlags? AccountFlags { get; set; }

        /// <summary>
        /// <para/>API v1: (Omitted unless the request specified <see cref="SignerLists"/>
        /// and at least one <see cref="SignerList"/> is associated with the account.)
        /// Array of <see cref="SignerList"/> ledger objects associated with this account for Multi-Signing.
        /// Since an account can own at most one <see cref="SignerList"/>, this array must have exactly one member if it is present.
        /// The field is nested under <see cref="AccountData"/>.
        /// <para/>API v2: Identical to API v1, but the field is returned in the root response instead.
        /// Clio implements the API v2 behavior in all cases.
        /// </summary>
        [DataMember(Name = "signer_lists")]
        public SignerList[]? SignerLists { get; set; }

        /// <summary>
        /// (Omitted if ledger_index is provided instead) The ledger index of the current in-progress ledger,
        /// which was used when retrieving this information.
        /// </summary>
        [DataMember(Name = "ledger_current_index")]
        public int? LedgerCurrentIndex { get; set; }

        /// <summary>
        /// (Omitted if ledger_current_index is provided instead) The ledger index of the ledger version used when retrieving this information.
        /// <para/>The information does not contain any changes from ledger versions newer than this one.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// (Omitted unless queue specified as true and querying the current open ledger.)
        /// Information about queued transactions sent by this account. This information describes the state of the local rippled server,
        /// which may be different from other servers in the peer-to-peer XRP Ledger network.
        /// Some fields may be omitted because the values are calculated "lazily" by the queuing mechanism.
        /// </summary>
        [DataMember(Name = "queue_data")]
        public QueueData? QueueData { get; set; }

        /// <summary>
        /// True if this data is from a validated ledger version; if omitted or set to false, this data is not final.
        /// </summary>
        [DataMember(Name = "validated")]
        public bool Validated { get; set; }
    }

    /// <summary>
    /// Represents the statuses of an account based on the <see cref="AccountRoot.Flags"/> field of the account.
    /// </summary>
    public class AccountFlags
    {
        /// <summary>
        /// If true, the account allows rippling on its trust lines by default.
        /// </summary>
        [DataMember(Name = "defaultRipple")]
        public bool DefaultRipple { get; set; }

        /// <summary>
        /// If true, the account is using Deposit Authorization and does not accept any payments from unknown parties.
        /// </summary>
        [DataMember(Name = "depositAuth")]
        public bool DepositAuth { get; set; }

        /// <summary>
        /// If true, the account's master key pair is disabled.
        /// </summary>
        [DataMember(Name = "disableMasterKey")]
        public bool DisableMasterKey { get; set; }

        /// <summary>
        /// If true, the account does not allow others to send Checks to it. (Requires the DisallowIncoming amendment)
        /// </summary>
        [DataMember(Name = "disallowIncomingCheck")]
        public bool DisallowIncomingCheck { get; set; }

        /// <summary>
        /// If true, the account does not allow others to make NFT buy or sell offers to it. (Requires the DisallowIncoming amendment)
        /// </summary>
        [DataMember(Name = "disallowIncomingNFTokenOffer")]
        public bool DisallowIncomingNFTokenOffer { get; set; }

        /// <summary>
        /// If true, the account does not allow others to make Payment Channels to it. (Requires the DisallowIncoming amendment)
        /// </summary>
        [DataMember(Name = "disallowIncomingPayChan")]
        public bool DisallowIncomingPayChan { get; set; }

        /// <summary>
        /// If true, the account does not allow others to make trust lines to it. (Requires the DisallowIncoming amendment)
        /// </summary>
        [DataMember(Name = "disallowIncomingTrustline")]
        public bool DisallowIncomingTrustline { get; set; }

        /// <summary>
        /// If true, the account does not want to receive XRP from others.
        /// <para/>(This is advisory, and not enforced at a protocol level.)
        /// </summary>
        [DataMember(Name = "disallowIncomingXRP")]
        public bool DisallowIncomingXRP { get; set; }

        /// <summary>
        /// If true, all tokens issued by the account are currently frozen.
        /// </summary>
        [DataMember(Name = "globalFreeze")]
        public bool GlobalFreeze { get; set; }

        /// <summary>
        /// If true, the account has permanently given up the abilities to freeze individual trust lines or end a global freeze.
        /// <para/>See No Freeze for details.
        /// </summary>
        [DataMember(Name = "noFreeze")]
        public bool NoFreeze { get; set; }

        /// <summary>
        /// If false, the account can send a special key reset transaction with a transaction cost of 0.
        /// <para/>The protocol turns this flag on and off automatically; it is not controlled by a user-facing setting.
        /// </summary>
        [DataMember(Name = "passwordSpent")]
        public bool PasswordSpent { get; set; }

        /// <summary>
        /// If true, the account is using Authorized Trust Lines to limit who can hold the tokens it issues.
        /// </summary>
        [DataMember(Name = "requireAuthorization")]
        public bool RequireAuthorization { get; set; }

        /// <summary>
        /// If true, the account requires a destination tag on all payments it receives.
        /// </summary>
        [DataMember(Name = "requireDestinationTag")]
        public bool RequireDestinationTag { get; set; }
    }

    /// <summary>
    /// Represents information about queued transactions sent by an account.
    /// </summary>
    public class QueueData
    {
        /// <summary>
        /// Number of queued transactions from this address.
        /// </summary>
        [DataMember(Name = "txn_count")]
        public int TxnCount { get; set; }

        /// <summary>
        /// (May be omitted) Whether a transaction in the queue changes this address's ways of authorizing transactions.
        /// If true, this address can queue no further transactions until that transaction has been executed or dropped from the queue.
        /// </summary>
        [DataMember(Name = "auth_change_queued")]
        public bool? AuthChangeQueued { get; set; }

        /// <summary>
        /// (May be omitted) The lowest Sequence Number among transactions queued by this address.
        /// </summary>
        [DataMember(Name = "lowest_sequence")]
        public int? LowestSequence { get; set; }

        /// <summary>
        /// (May be omitted) The highest Sequence Number among transactions queued by this address.
        /// </summary>
        [DataMember(Name = "highest_sequence")]
        public int? HighestSequence { get; set; }

        /// <summary>
        /// (May be omitted) Integer amount of drops of XRP that could be debited from this address
        /// if every transaction in the queue consumes the maximum amount of XRP possible.
        /// </summary>
        [DataMember(Name = "max_spend_drops_total")]
        public string? MaxSpendDropsTotal { get; set; }

        /// <summary>
        /// (May be omitted) Information about each queued transaction from this address.
        /// </summary>
        [DataMember(Name = "transactions")]
        public QueueDataTransaction[]? Transactions { get; set; }
    }

    /// <summary>
    /// Represents information about each queued transaction from this address.
    /// </summary>
    [DataContract]
    public class QueueDataTransaction
    {
        /// <summary>
        /// Whether this transaction changes this address's ways of authorizing transactions.
        /// </summary>
        [DataMember(Name = "auth_change")]
        public bool AuthChange { get; set; }

        /// <summary>
        /// The Transaction Cost of this transaction, in drops of XRP.
        /// </summary>
        [DataMember(Name = "fee")]
        public string? Fee { get; set; }

        /// <summary>
        /// The transaction cost of this transaction, relative to the minimum cost for this type of transaction, in fee levels.
        /// </summary>
        [DataMember(Name = "fee_level")]
        public string? FeeLevel { get; set; }

        /// <summary>
        /// The maximum amount of XRP, in drops, this transaction could send or destroy.
        /// </summary>
        [DataMember(Name = "max_spend_drops\t")]
        public string? MaxSpendDrops { get; set; }

        /// <summary>
        /// The Sequence Number of this transaction.
        /// </summary>
        [DataMember(Name = "seq")]
        public int Seq { get; set; }
    }
}