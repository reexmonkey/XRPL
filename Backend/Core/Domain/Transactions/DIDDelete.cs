namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that deletes the sender's decentralized identifier (DID).
    /// </summary>
    public class DIDDelete : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DIDDelete"/> class.
        /// </summary>
        public DIDDelete() : base(TransactionType.DIDDelete)
        {
        }
    }
}