using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Specifies a result-specific reponse to a query.
    /// </summary>
    /// <typeparam name="TResult">The type of result.</typeparam>
    public abstract class ResponseBase<TResult>
        where TResult : ResultBase
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        [DataMember(Name = "result")]
        public TResult? Result { get; set; }

        /// <summary>
        /// May contain one or more important warnings.
        /// </summary>
        [DataMember(Name = "warnings")]
        public Warning[]? Warnings { get; set; }

        /// <summary>
        /// If true, this request and response have been forwarded from a Reporting Mode server to a P2P Mode server (and back) because the request requires data that is not available in Reporting Mode. The default is false.
        /// </summary>
        [DataMember(Name = "forwarded")]
        public bool? Forwarded { get; set; }
    }

    /// <summary>
    /// Represents a warning.
    /// </summary>
    public class Warning
    {
        /// <summary>
        /// A unique numeric code for this warning message.
        /// </summary>
        [DataMember(Name = "id")]
        public uint Id { get; set; }

        /// <summary>
        /// A human-readable string describing the cause of this message.
        /// <para/>Do not write software that relies the contents of this message; use the id (and details, if applicable) to identify the warning instead.
        /// </summary>
        [DataMember(Name = "message")]
        public string? Message { get; set; }

        /// <summary>
        /// Additional information about this warning. The contents vary depending on the type of warning.
        /// </summary>
        [DataMember(Name = "details")]
        public object? Details { get; set; }
    }

    /// <summary>
    /// Specifies the result to a query.
    /// </summary>
    public abstract class ResultBase
    {
        /// <summary>
        /// The value success indicates the request was successfully received and understood by the server.
        /// </summary>
        [DataMember(Name = "status")]
        public string? Status { get; set; }
    }
}