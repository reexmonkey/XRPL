using System.Runtime.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a request that retrieves information on a single transaction, by its identifying hash.
    /// </summary>
    [DataContract]
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
    [DataContract]
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
    [DataContract]
    public class TxParameters : ParameterBase
    {
        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public uint LedgerIndex { get; set; }

        /// <summary>
        /// Unique hash of the transaction you are looking up
        /// </summary>
        [DataMember(Name = "tx_hash")]
        public uint TxHash { get; set; }
    }
}