using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Clients.Requests
{

    public abstract class ParameterBase
    {
        /// <summary>
        /// The API version to use. If omitted, use version 1
        /// </summary>
        public uint ApiVersion { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterBase"/> class.
        /// </summary>
        public ParameterBase()
        {
            ApiVersion = 1u; 
        }
    }

    /// <summary>
    /// Represents a JSON-RPC request to a rippled server.
    /// </summary>
    /// <typeparam name="TParameters"></typeparam>
    public abstract class RequestBase<TParameters>
        where TParameters : ParameterBase
    {
        /// <summary>
        /// The name of the API method.
        /// </summary>
        [DataMember(Name = "method")]
        public string Method { get;}

        /// <summary>
        /// A one-item array containing a nested JSON object with the parameters to this method. You may omit this field if the method does not require any parameters.
        /// </summary>
        [DataMember(Name = "params")]
        public TParameters[]? Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBase{T}"/> class with the name of the API method.
        /// </summary>
        /// <param name="method">The name of the API method</param>
        public RequestBase(string method)
        {
            if (string.IsNullOrEmpty(method))
                throw new ArgumentException($"'{nameof(method)}' cannot be null or empty.", nameof(method));

            Method = method;
        }
    }
}
