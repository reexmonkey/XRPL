using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that deletes the <see cref="DID"/> ledger entry associated with the specified Account field.
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
