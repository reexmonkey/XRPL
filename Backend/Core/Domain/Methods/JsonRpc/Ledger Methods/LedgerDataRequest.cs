using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    /// <summary>
    /// The ledger_data method retrieves contents of the specified ledger.
    /// <para/>You can iterate through several calls to retrieve the entire contents of a single ledger version.
    /// </summary>
    public record LedgerDataRequest : Request, IExpect<LedgerDataResponse>
    {
        /// <summary>
        /// Gets the collection of parameters used to configure the ledger operation.
        /// </summary>
        [JsonPropertyName("params")]
        public LedgerDataParameter[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LedgerDataRequest"/> record.
        /// </summary>
        public LedgerDataRequest() : base("ledger_data")
        {
        }
    }

    /// <summary>
    /// Represents the set of parameters used to request ledger data from the server.
    /// </summary>
    /// <remarks>This record provides options for specifying which ledger to query, how results are formatted,
    /// pagination, and filtering by entry type. It is typically used when constructing requests to retrieve ledger
    /// entries from a distributed ledger system.</remarks>
    public record LedgerDataParameter : Parameter
    {
        /// <summary>
        /// A 20-byte hex string identifying the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; init; }

        /// <summary>
        /// If true, return ledger entries as hexadecimal strings instead of JSON. The default is false.
        /// </summary>
        [JsonPropertyName("binary")]
        public bool? Binary { get; init; }

        /// <summary>
        /// Limit the number of ledger entries to retrieve.
        /// <para/>The server may return fewer than this number of entries. Cannot be more than 2048 (when requesting binary) or 256 (when requesting JSON).
        /// Positive values outside this range are replaced with the closest valid option. The default is the maximum.
        /// </summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; init; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }

        /// <summary>
        /// Filter results to a specific type of ledger entry.
        /// <para/>This field accepts canonical names of ledger entry types (case insensitive) or short names.
        /// If omitted, return ledger entries of all types.
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; init; }
    }

}
