using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that deletes the <see cref="DID"/> ledger entry associated with the specified Account field.
    /// </summary>
    public class DIDSet : Transaction
    {
        /// <summary>
        /// The public attestations of identity credentials associated with the DID.
        /// </summary>
        public string? Data { get; set; }

        /// <summary>
        /// The DID document associated with the DID.
        /// </summary>
        public string? DIDDocument { get; set; }

        /// <summary>
        /// The Universal Resource Identifier associated with the DID.
        /// </summary>
        public Uri? Uri { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DIDSet"/> class.
        /// </summary>
        public DIDSet() : base(TransactionType.DIDSet)
        {
        }
    }
}