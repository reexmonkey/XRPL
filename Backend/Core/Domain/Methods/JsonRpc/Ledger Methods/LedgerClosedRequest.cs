using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    /// <summary>
    /// Represents a request that returns the unique identifiers of the most recently closed ledger. (This ledger is not necessarily validated and immutable yet.)
    /// </summary>
    public record LedgerClosedRequest : Request, IExpect<LedgerClosedResponse>
    {
        /// <summary>
        /// Gets the collection of parameters used to configure the ledger operation.
        /// </summary>
        [JsonPropertyName("params")]
        public LedgerClosedParameter[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LedgerClosedRequest"/> record.
        /// </summary>
        public LedgerClosedRequest() : base("ledger_closed")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of a <see cref="LedgerClosedRequest"/> object.
    /// </summary>
    public record LedgerClosedParameter : Parameter
    {
    }
}
