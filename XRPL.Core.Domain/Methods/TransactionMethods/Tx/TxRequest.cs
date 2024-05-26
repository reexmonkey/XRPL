using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.TransactionMethods.Tx
{
    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash.
    /// </summary>

    public class TxRequest : RequestBase<TxParameters>, IExpect<HashTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxRequest"/> class.
        /// </summary>
        public TxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>

    public class CtidTxRequest : RequestBase<TxParameters>, IExpect<CtidTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxRequest"/> class.
        /// </summary>
        public CtidTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="TxRequest"/> object.
    /// </summary>

    public class TxParameters : ParameterBase
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
        public uint TxHash { get; set; }
    }
}