using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Methods.JsonRpc.TransactionMethods
{
    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash.
    /// </summary>
    public record CtidJsonTxRequest : Request, IExpect<CtidJsonTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtidJsonTxRequest"/> record.
        /// </summary>
        public CtidJsonTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    public record CtidBinaryTxRequest : Request, IExpect<CtidBinaryTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtidBinaryTxRequest"/> record.
        /// </summary>
        public CtidBinaryTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    public record HashJsonTxRequest : RequestBase<TxParameters>, IExpect<HashJsonTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtidJsonTxRequest"/> record.
        /// </summary>
        public HashJsonTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash or its CTID.
    /// </summary>
    public record HashBinaryTxRequest : RequestBase<TxParameters>, IExpect<HashBinaryTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HashBinaryTxRequest"/> record.
        /// </summary>
        public HashBinaryTxRequest() : base("tx")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of any Tx object.
    /// </summary>
    public record TxParameters : Parameter
    {
        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public uint LedgerIndex { get; init; }

        /// <summary>
        /// Unique hash of the transaction you are looking up
        /// </summary>
        [JsonPropertyName("tx_hash")]
        public uint TxHash { get; init; }
    }
}