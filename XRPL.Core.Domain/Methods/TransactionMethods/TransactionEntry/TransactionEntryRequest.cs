using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.TransactionMethods.TransactionEntry
{
    /// <summary>
    /// Represents a request that retrieves information on a single transaction from a specific ledger version.
    /// <para/>(The TxRequest method, by contrast, searches all ledgers for the specified transaction. We recommend using that method instead.)
    /// </summary>
    public class TransactionEntryRequest : RequestBase<TransactionEntryParameters>, IExpect<TransactionEntryResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionEntryRequest"/> class.
        /// </summary>
        public TransactionEntryRequest() : base("transaction_entry")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="TransactionEntryRequest"/> object.
    /// </summary>
    public class TransactionEntryParameters : ParameterBase
    {
        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public uint LedgerIndex { get; set; }

        /// <summary>
        /// Unique hash of the transaction you are looking up
        /// </summary>
        [JsonPropertyName("tx_hash")]
        public required uint TxHash { get; set; }
    }
}
