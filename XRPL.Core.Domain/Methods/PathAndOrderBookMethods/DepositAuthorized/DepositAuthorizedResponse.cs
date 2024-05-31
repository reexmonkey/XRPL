using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.DepositAuthorized
{
    /// <summary>
    /// Represents a response to a deposit authorized request.
    /// </summary>
    public class DepositAuthorizedResponse : ResponseBase<DepositAuthorizedResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="DepositAuthorizedResponse"/> object.
    /// </summary>
    public class DepositAuthorizedResult : ResultBase
    {
        /// <summary>
        /// Whether the specified source account is authorized to send payments directly to the destination account.
        /// If true, either the destination account does not require Deposit Authorization or the source account is preauthorized.
        /// </summary>
        [JsonPropertyName("deposit_authorized")]
        public required bool DepositAuthorized { get; set; }

        /// <summary>
        /// The destination account specified in the request.
        /// </summary>
        [JsonPropertyName("destination_account")]
        public required string DestinationAccount { get; set; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (May be omitted) The ledger index of the ledger version that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public uint? LedgerIndex { get; set; }

        /// <summary>
        /// (May be omitted) The ledger index of the current in-progress ledger version, which was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public uint? LedgerCurrentIndex { get; set; }

        /// <summary>
        /// The source account specified in the request.
        /// </summary>
        [JsonPropertyName("source_account")]
        public required string SourceAccount { get; set; }

        /// <summary>
        /// (May be omitted) If true, the information comes from a validated ledger version.
        /// </summary>
        [JsonPropertyName("validated")]
        public bool? Validated { get; set; }
    }
}
