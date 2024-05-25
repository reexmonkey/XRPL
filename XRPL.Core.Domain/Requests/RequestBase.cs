using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a JSON-RPC request to a rippled server.
    /// </summary>
    [DataContract]
    public abstract class RequestBase
    {
        /// <summary>
        /// The name of the API method.
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBase{T}"/> class with the name of the API method.
        /// </summary>
        /// <param name="method">The name of the API method</param>
        protected RequestBase(string method)
        {
            if (string.IsNullOrEmpty(method))
                throw new ArgumentException($"'{nameof(method)}' cannot be null or empty.", nameof(method));

            Method = method;
        }
    }

    /// <summary>
    /// Represents a paramterized JSON-RPC request to a rippled server.
    /// </summary>
    /// <typeparam name="TParameters"></typeparam>
    [DataContract]
    public abstract class RequestBase<TParameters> : RequestBase
        where TParameters : ParameterBase
    {
        /// <summary>
        /// A one-item array containing a nested JSON object with the parameters to this method. You may omit this field if the method does not require any parameters.
        /// </summary>
        [JsonPropertyName("params")]
        public TParameters[]? Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBase{T}"/> class with the name of the API method.
        /// </summary>
        /// <param name="method">The name of the API method</param>
        protected RequestBase(string method) : base(method)
        {
        }
    }

    /// <summary>
    /// Represents a parameter of a <see cref="RequestBase"/>
    /// </summary>
    [DataContract]
    public abstract class ParameterBase
    {
        /// <summary>
        /// The API version to use. If omitted, use version 1
        /// </summary>
        [JsonPropertyName("api_version")]
        public uint? ApiVersion { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterBase"/> class.
        /// </summary>
        protected ParameterBase()
        {
            ApiVersion = 1u;
        }
    }
}