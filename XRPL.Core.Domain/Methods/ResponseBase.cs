using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods
{
    /// <summary>
    /// Specifies a response that encapsulates information in a <typeparamref name="TResult"/> object received from a rippled server.
    /// </summary>
    /// <typeparam name="TResult">The type of result to encapsulate.</typeparam>
    public abstract class ResponseBase<TResult> : ResponseBase
        where TResult : ResultBase
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        [JsonPropertyName("result")]
        public new required TResult Result { get; set; }
    }

    /// <summary>
    /// Specifies a response that encapsulates information received from a rippled server.
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        public ResultBase Result { get; set; } = null!;

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
    /// Specifies the result of a query.
    /// </summary>
    public abstract class ResultBase
    {
        /// <summary>
        /// The value success indicates the request was successfully received and understood by the server.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }

    /// <summary>
    /// Represents a warning.
    /// </summary>
    public abstract class Warning
    {
        /// <summary>
        /// A unique numeric code for this warning message.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// A human-readable string describing the cause of this message.
        /// <para/>Do not write software that relies the contents of this message; use the id (and details, if applicable) to identify the warning instead.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// Represents a warning that indicates that the one or more amendments to the XRP Ledger protocol are scheduled to become enabled,
    /// but the current server does not have an implementation for those amendments.
    /// If those amendments become enabled, the current server will become amendment blocked,
    /// so you should upgrade to the latest rippled version as soon as possible.
    /// <para/> The server only sends this warning if the client is connected as an admin.
    /// </summary>
    public class UnsupportedAmmendmentWarning : Warning
    {
        /// <summary>
        /// Additional information about this warning.
        /// </summary>
        [JsonPropertyName("details")]
        public required UnsupportedAmmendmentWarningDetails Details { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedAmmendmentWarning"/> class.
        /// </summary>
        public UnsupportedAmmendmentWarning()
        {
            Id = 1001;
            Message = "Unsupported amendments have reached majority";
        }
    }

    /// <summary>
    /// Represents a warning detail that indicates that the one or more amendments to the XRP Ledger protocol are scheduled to become enabled,
    /// but the current server does not have an implementation for those amendments.
    /// If those amendments become enabled, the current server will become amendment blocked,
    /// so you should upgrade to the latest rippled version as soon as possible.
    /// </summary>
    public class UnsupportedAmmendmentWarningDetails
    {
        /// <summary>
        /// The time that the first unsupported amendment is expected to become enabled, in seconds since the Ripple Epoch.
        /// </summary>
        [JsonPropertyName("expected_date")]
        public required uint ExpectedDate { get; set; }

        /// <summary>
        /// The timestamp, in UTC, when the first unsupported amendment is expected to become enabled.
        /// </summary>
        [JsonPropertyName("expected_date")]
        public required string ExpectedDateUTC { get; set; }
    }

    /// <summary>
    /// Represents a warning that indicates that the server answering the request is running Reporting Mode.
    /// Certain API methods are not available or behave differently because
    /// Reporting Mode does not connect to the peer-to-peer network and does not track ledger data that has not yet been validated.
    /// </summary>
    public class ServerIsAmmendmentBlockedWarning : Warning
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerIsAmmendmentBlockedWarning"/> class.
        /// </summary>
        public ServerIsAmmendmentBlockedWarning()
        {
            Id = 1002;
            Message = "This server is amendment blocked";
        }
    }

    /// <summary>
    /// This warning indicates that the server answering the request is running Reporting Mode.
    /// Certain API methods are not available or behave differently because
    /// Reporting Mode does not connect to the peer-to-peer network and does not track ledger data that has not yet been validated.
    /// <para/>It is generally safe to ignore this warning.
    /// </summary>
    public class ReportingServerWarning : Warning
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingServerWarning"/> class.
        /// </summary>
        public ReportingServerWarning()
        {
            Id = 1003;
            Message = "This is a reporting server";
        }
    }
}
