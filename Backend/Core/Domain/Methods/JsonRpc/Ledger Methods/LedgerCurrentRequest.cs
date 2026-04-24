using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    /// <summary>
    /// Represents a request that returns the unique identifiers of the current in-progress ledger. 
    /// <para/>This command is mostly useful for testing, because the ledger returned is still in flux.
    /// </summary>
    public record LedgerCurrentRequest : Request, IExpect<LedgerCurrentResponse>
    {
        /// <summary>
        /// Gets the collection of parameters used to configure the ledger operation.
        /// </summary>
        [JsonPropertyName("params")]
        public LedgerCurrentParameter[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LedgerCurrentRequest"/> record.
        /// </summary>
        public LedgerCurrentRequest() : base("ledger_current")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of a <see cref="LedgerCurrentRequest"/> object.
    /// </summary>
    public record LedgerCurrentParameter : Parameter
    {
    }
}
