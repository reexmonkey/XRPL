using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response from the query to return information about an account's trust lines,
    /// which contain balances in all non-XRP currencies and assets.
    /// </summary>
    public class AccountLinesResponse : ResponseBase<AccountLinesResult>
    {
    }

    /// <summary>
    /// Represents the result of a query to return information about an account's trust lines,
    /// which contain balances in all non-XRP currencies and assets.
    /// </summary>
    public class AccountLinesResult : ResultBase
    {
        /// <summary>
        /// Unique Address of the account this request corresponds to.
        /// <para/>This is the "perspective account" for purpose of the trust lines.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// Array of trust line objects, as described below.
        /// <para/>If the number of trust lines is large, only returns up to the limit at a time.
        /// </summary>
        [DataMember(Name = "lines")]
        public TrustLine[]? Lines { get; set; }

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
        /// The identifying Hash of the ledger version used to generate this response.
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// Server-defined value for pagination. Pass this to the next call to resume getting results where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [DataMember(Name = "marker")]
        public object? Marker { get; set; }
    }

    /// <summary>
    /// Represents a trustline, which contains balances in all non-XRP currencies and assets.
    /// </summary>
    public class TrustLine
    {
        /// <summary>
        /// The unique Address of the counterparty to this trust line.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// Representation of the numeric balance currently held against this line.
        /// <para/>A positive balance means that the perspective account holds value; a negative balance means that the perspective account owes value.
        /// </summary>
        [DataMember(Name = "balance")]
        public string? Balance { get; set; }

        /// <summary>
        /// A Currency Code identifying what currency this trust line can hold.
        /// </summary>
        [DataMember(Name = "currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// The maximum amount of the given currency that this account is willing to owe the peer account
        /// </summary>
        [DataMember(Name = "limit")]
        public string? Limit { get; set; }

        /// <summary>
        /// The maximum amount of currency that the counterparty account is willing to owe the perspective account
        /// </summary>
        [DataMember(Name = "limit_peer")]
        public string? LimitPeer { get; set; }

        /// <summary>
        /// Rate at which the account values incoming balances on this trust line, as a ratio of this value per 1 billion units.
        /// <para/>(For example, a value of 500 million represents a 0.5:1 ratio.) As a special case, 0 is treated as a 1:1 ratio
        /// </summary>
        [DataMember(Name = "quality_in")]
        public uint QualityIn { get; set; }

        /// <summary>
        /// Rate at which the account values outgoing balances on this trust line, as a ratio of this value per 1 billion units.
        /// <para/>(For example, a value of 500 million represents a 0.5:1 ratio.) As a special case, 0 is treated as a 1:1 ratio.
        /// </summary>
        [DataMember(Name = "quality_out")]
        public uint? QualityOut { get; set; }

        /// <summary>
        /// (May be omitted) If true, this account has enabled the No Ripple flag for this trust line.
        /// <para/>If present and false, this account has disabled the No Ripple flag, but,
        /// because the account also has the Default Ripple flag disabled, that is not considered the default state.
        /// If omitted, the account has the No Ripple flag disabled for this trust line and Default Ripple enabled.
        /// </summary>
        [DataMember(Name = "no_ripple")]
        public bool? NoRipple { get; set; }

        /// <summary>
        /// (May be omitted) If true, the peer account has enabled the No Ripple flag for this trust line.
        /// If present and false, this account has disabled the No Ripple flag, but, because the account also has the Default Ripple flag disabled,
        /// that is not considered the default state.
        /// If omitted, the account has the No Ripple flag disabled for this trust line and Default Ripple enabled.
        /// </summary>
        [DataMember(Name = "no_ripple_peer")]
        public bool? NoRipplePeer { get; set; }

        /// <summary>
        /// (May be omitted) If true, this account has authorized this trust line. The default is false.
        /// </summary>
        [DataMember(Name = "authorized")]
        public bool Authorized { get; set; }

        /// <summary>
        /// (May be omitted) If true, the peer account has authorized this trust line. The default is false.
        /// </summary>
        [DataMember(Name = "peer_authorized")]
        public bool? PeerAuthorized { get; set; }

        /// <summary>
        /// (May be omitted) If true, this account has frozen this trust line. The default is false.
        /// </summary>
        [DataMember(Name = "freeze")]
        public bool? Freeze { get; set; }

        /// <summary>
        /// (May be omitted) If true, the peer account has frozen this trust line. The default is false.
        /// </summary>
        [DataMember(Name = "freeze_peer")]
        public bool? FreezePeer { get; set; }
    }
}