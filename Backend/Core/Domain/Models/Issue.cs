using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents a currency without an amount.
    /// </summary>
    public abstract record Issue;

    public record XRPIssue : Issue
    {
        /// <summary>
        /// The currency code of the asset.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; init; }
    }

    public record TokenIssue : Issue
    {
        /// <summary>
        /// The currency code of the asset. Cannot be XRP.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; init; }

        /// <summary>
        /// Generally, the account that issues this token.
        /// <para/>
        /// In special cases, this can refer to the account that holds the token instead (for example, in a Clawback transaction).
        /// </summary>
        [JsonPropertyName("issuer")]
        public required string Issuer { get; set; }
    }

    public record MPTIssue : Issue
    {
        /// <summary>
        /// Arbitrary unique identifier for a Multi-purpose Token.
        /// </summary>
        [JsonPropertyName("mpt_issuance_id")]
        public required string MptIssuanceId { get; set; }
    }
}