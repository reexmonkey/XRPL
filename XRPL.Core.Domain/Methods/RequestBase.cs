using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods
{
    /// <summary>
    /// Represents a paramterized JSON-RPC request to a rippled server.
    /// </summary>
    /// <typeparam name="TParameters"></typeparam>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RequestBase{T}"/> class with the name of the API method.
    /// </remarks>
    /// <param name="method">The name of the API method</param>
    public abstract class RequestBase<TParameters>(string method) : RequestBase(method)
        where TParameters : ParameterBase
    {
        /// <summary>
        /// A one-item array containing a nested JSON object with the parameters to this method. You may omit this field if the method does not require any parameters.
        /// </summary>
        [JsonPropertyName("params")]
        public new TParameters[]? Parameters
        {
            get
            {
                if (base.Parameters == null) return default;
                var parameters = new List<TParameters>();
                foreach (var oparameter in base.Parameters)
                {
                    if (oparameter is not TParameters parameter) continue;
                    parameters.Add(parameter);
                }
                return [.. parameters];
            }
            set
            {
                if (value == null) base.Parameters = null;
                else
                {
                    base.Parameters = new ParameterBase[value.Length];
                    value.CopyTo(base.Parameters, 0);
                }
            }
        }
    }

    /// <summary>
    /// Represents a JSON-RPC request to a rippled server.
    /// </summary>
    public abstract class RequestBase
    {
        /// <summary>
        /// The name of the API method.
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; }

        /// <summary>
        /// A one-item array containing a nested JSON object with the parameters to this method. You may omit this field if the method does not require any parameters.
        /// </summary>
        [JsonPropertyName("params")]
        public ParameterBase[]? Parameters { get; set; }

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
    /// Represents a parameter of a <see cref="RequestBase"/>
    /// </summary>
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
