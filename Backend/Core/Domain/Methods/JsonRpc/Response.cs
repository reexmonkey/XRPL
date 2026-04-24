using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc
{
    /// <summary>
    /// Specifies a response that encapsulates information received from a rippled server.
    /// </summary>
    public abstract record Response
    {
        /// <summary>
        /// (May be omitted) If this field is provided, the value is the string 'load'.
        /// <para/>This means the client is approaching the rate limiting threshold where the server will disconnect this client.
        /// </summary>
        [JsonPropertyName("warning")]
        public string? Warning { get; set; }

        /// <summary>
        /// May contain one or more important warnings.
        /// </summary>
        [JsonPropertyName("warnings")]
        public Warning[]? Warnings { get; set; }

        /// <summary>
        /// If true, this request and response have been forwarded from a Reporting Mode server to a P2P Mode server (and back) because the request requires data that is not available in Reporting Mode. The default is false.
        /// </summary>
        [JsonPropertyName("forwarded")]
        public bool? Forwarded { get; set; }
    }

    /// <summary>
    /// Represents the result of a query.
    /// </summary>
    public abstract record Result
    {
        /// <summary>
        /// The value success indicates the request was successfully received and understood by the server.
        /// <para/>"error" if the request caused an error
        /// </summary>
        [JsonPropertyName("status")]
        public required string Status { get; init; }

        /// <summary>
        /// A unique code for the type of error that occurred
        /// </summary>
        [JsonPropertyName("error")]
        public string? Error { get; init; }

        /// <summary>
        /// A copy of the request that prompted this error, in JSON format.
        /// <para/> Caution: If the request contained any account secrets, they are copied here!
        /// <para/> Note: The request is re-formatted in WebSocket format, regardless of the request made.
        /// </summary>
        [JsonPropertyName("request")]
        public object? Request { get; init; }
    }

    /// <summary>
    /// Represents a warning from the rippled server.
    /// </summary>
    public record Warning
    {
        /// <summary>
        /// A unique numeric code for this warning message.
        /// </summary>
        [JsonPropertyName("id")]
        public required uint Id { get; init; }

        /// <summary>
        /// A human-readable string describing the cause of this message.
        /// <para/>Do not write software that relies the contents of this message; use the id (and details, if applicable) to identify the warning instead.
        /// </summary>
        [JsonPropertyName("message")]
        public required string Message { get; init; }

        /// <summary>
        /// Additional information about this warning. The contents vary depending on the type of warning.
        /// </summary>
        [JsonPropertyName("details")]
        public object? Details { get; set; }
    }

    /// <summary>
    /// Represents the time and timestamp for the first unsupported amendment is expected to become enabled.
    /// </summary>
    public record ExpectedDateDetails
    {
        /// <summary>
        /// The time that the first unsupported amendment is expected to become enabled, in seconds since the Ripple Epoch.
        /// </summary>
        [JsonPropertyName("expected_date")]
        public required uint ExpectedDate { get; init; }

        /// <summary>
        /// The timestamp, in UTC, when the first unsupported amendment is expected to become enabled.
        /// </summary>
        [JsonPropertyName("expected_date_UTC")]
        public required string ExpectedDateUTC { get; init; }
    }

    [JsonSerializable(typeof(Warning))]
    [JsonSerializable(typeof(ExpectedDateDetails))]
    public partial class WarningContext : JsonSerializerContext;
}
