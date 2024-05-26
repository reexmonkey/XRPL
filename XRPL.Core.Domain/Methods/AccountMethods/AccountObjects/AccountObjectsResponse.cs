using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountObjects
{
    /// <summary>
    /// Represents a response that encapsulates the raw ledger format for all ledger entries owned by an account.
    /// </summary>

    public class AccountObjectsResponse : ResponseBase<AccountObjectsResult>
    {
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountObjectsResponse"/> object.
    /// </summary>

    public class AccountObjectsResult : ResultBase
    {
        /// <summary>
        /// Unique Address of the account this request corresponds to.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// Array of objects owned by this account. Each object is in its raw ledger format.
        /// </summary>
        [JsonPropertyName("account_objects")]
        public LedgerEntryBase[]? AccountObjects { get; set; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (May be omitted) The ledger index of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// (May be omitted) The ledger index of the current in-progress ledger version, which was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; set; }

        /// <summary>
        /// (May be omitted) The limit that was used in this request, if any.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; }

        /// <summary>
        /// Server-defined value for pagination. Pass this to the next call to resume getting results where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }

        /// <summary>
        /// If included and set to true, the information in this response comes from a validated ledger version.
        /// <para/>Otherwise, the information is subject to change
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }
}