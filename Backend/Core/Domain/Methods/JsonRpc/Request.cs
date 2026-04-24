using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc
{
    /// <summary>
    /// Represents a JSON-RPC request to a rippled server.
    /// </summary>
    public abstract record Request
    {
        /// <summary>
        /// The name of the API method.
        /// </summary>
        [JsonPropertyName("method")]
        public required string Method { get; init; }

        protected Request(string method)
        {
            Method = method;
        }
    }

    /// <summary>
    /// Represents a parameter of a <see cref="Request"/>
    /// </summary>
    public abstract record Parameter
    {
        /// <summary>
        /// The API version to use. If omitted, use version 1
        /// </summary>
        [JsonPropertyName("api_version")]
        public uint? ApiVersion { get; set; }
    }
}
