using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.TransactionMethods.Tx
{
    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash.
    /// </summary>
    public class CtidJsonTxRequest : RequestBase<TxParameters>, IExpect<CtidJsonTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtidJsonTxRequest"/> class.
        /// </summary>
        public CtidJsonTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    public class CtidBinaryTxRequest : RequestBase<TxParameters>, IExpect<CtidBinaryTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtidBinaryTxRequest"/> class.
        /// </summary>
        public CtidBinaryTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    public class HashJsonTxRequest : RequestBase<TxParameters>, IExpect<HashJsonTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtidJsonTxRequest"/> class.
        /// </summary>
        public HashJsonTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    public class HashBinaryTxRequest : RequestBase<TxParameters>, IExpect<HashBinaryTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HashBinaryTxRequest"/> class.
        /// </summary>
        public HashBinaryTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of any Tx object.
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
