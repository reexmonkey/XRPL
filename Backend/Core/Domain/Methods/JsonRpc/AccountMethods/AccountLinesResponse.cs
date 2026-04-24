using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{

    /// <summary>
    /// Represents the response returned for account lines in a JSON-RPC request.
    /// </summary>
    public record AccountLinesResponse : Response
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        [JsonPropertyName("result")]
        public required AccountLinesResult Result { get; set; }

    }

    /// <summary>
    /// Represents the result of an <see cref="AccountLinesResponse"/> object.
    /// </summary>
    public record AccountLinesResult : Result
    {
        /// <summary>
        /// Unique Address of the account this request corresponds to.
        /// <para/>This is the "perspective account" for purpose of the trust lines.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// Array of trust line objects, as described below.
        /// <para/>If the number of trust lines is large, only returns up to the limit at a time.
        /// </summary>
        [JsonPropertyName("lines")]
        public required TrustLine[] Lines { get; init; }

        /// <summary>
        /// (Omitted if ledger_index is provided instead) The ledger index of the current in-progress ledger,
        /// which was used when retrieving this information.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; init; }

        /// <summary>
        /// (Omitted if ledger_current_index is provided instead) The ledger index of the ledger version used when retrieving this information.
        /// <para/>The information does not contain any changes from ledger versions newer than this one.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; init; }

        /// <summary>
        /// The identifying Hash of the ledger version used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// Server-defined value for pagination. Pass this to the next call to resume getting results where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }

        /// <summary>
        /// The maximum number of trust lines retrieved. 
        /// The server may return fewer than the specified limit, even if more results are available. 
        /// If no limit was specified in the request, use a default limit of 200.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; init; }
    }

    /// <summary>
    /// Represents a trustline, which contains balances in all non-XRP currencies and assets.
    /// </summary>
    public record TrustLine
    {
        /// <summary>
        /// The unique Address of the counterparty to this trust line.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// Representation of the numeric balance currently held against this line.
        /// <para/>A positive balance means that the perspective account holds value; a negative balance means that the perspective account owes value.
        /// </summary>
        [JsonPropertyName("balance")]
        public required string Balance { get; init; }

        /// <summary>
        /// A currency code identifying what token this trust line can hold.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; init; }

        /// <summary>
        /// The maximum amount of the given token that this account is willing to owe the peer account
        /// </summary>
        [JsonPropertyName("limit")]
        public required string Limit { get; init; }

        /// <summary>
        /// The maximum amount of token that the counterparty account is willing to owe the perspective account
        /// </summary>
        [JsonPropertyName("limit_peer")]
        public required string LimitPeer { get; init; }

        /// <summary>
        /// Rate at which the account values incoming balances on this trust line, as a ratio of this value per 1 billion units.
        /// <para/>(For example, a value of 500 million represents a 0.5:1 ratio.) As a special case, 0 is treated as a 1:1 ratio
        /// </summary>
        [JsonPropertyName("quality_in")]
        public required uint QualityIn { get; init; }

        /// <summary>
        /// Rate at which the account values outgoing balances on this trust line, as a ratio of this value per 1 billion units.
        /// <para/>(For example, a value of 500 million represents a 0.5:1 ratio.) As a special case, 0 is treated as a 1:1 ratio.
        /// </summary>
        [JsonPropertyName("quality_out")]
        public required uint QualityOut { get; init; }

        /// <summary>
        /// (May be omitted) If true, this account has enabled the No Ripple flag for this trust line.
        /// <para/>If present and false, this account has disabled the No Ripple flag, but,
        /// because the account also has the Default Ripple flag disabled, that is not considered the default state.
        /// If omitted, the account has the No Ripple flag disabled for this trust line and Default Ripple enabled.
        /// </summary>
        [JsonPropertyName("no_ripple")]
        public bool? NoRipple { get; init; }

        /// <summary>
        /// (May be omitted) If true, the peer account has enabled the No Ripple flag for this trust line.
        /// If present and false, this account has disabled the No Ripple flag, but, because the account also has the Default Ripple flag disabled,
        /// that is not considered the default state.
        /// If omitted, the account has the No Ripple flag disabled for this trust line and Default Ripple enabled.
        /// </summary>
        [JsonPropertyName("no_ripple_peer")]
        public bool? NoRipplePeer { get; init; }

        /// <summary>
        /// (May be omitted) If true, this account has authorized this trust line. The default is false.
        /// </summary>
        [JsonPropertyName("authorized")]
        public bool Authorized { get; init; }

        /// <summary>
        /// (May be omitted) If true, the peer account has authorized this trust line. The default is false.
        /// </summary>
        [JsonPropertyName("peer_authorized")]
        public bool? PeerAuthorized { get; init; }

        /// <summary>
        /// (May be omitted) If true, this account has frozen this trust line. The default is false.
        /// </summary>
        [JsonPropertyName("freeze")]
        public bool? Freeze { get; init; }

        /// <summary>
        /// (May be omitted) If true, the peer account has frozen this trust line. The default is false.
        /// </summary>
        [JsonPropertyName("freeze_peer")]
        public bool? FreezePeer { get; init; }
    }
}
