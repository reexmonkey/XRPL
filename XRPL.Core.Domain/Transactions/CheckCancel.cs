using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that cancels an unredeemed <see cref="Check"/>, removing it from the ledger without sending any money. 
    /// The source or the destination of the check can cancel a <see cref="Check"/> at any time using this transaction type. 
    /// If the <see cref="Check"/> has expired, any address can cancel it.
    /// </summary>
    public class CheckCancel : Transaction
    {
        /// <summary>
        /// The ID of the Check ledger object to cancel, as a 64-character hexadecimal string.
        /// </summary>
        public required string CheckID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckCancel"/> class.
        /// </summary>
        protected CheckCancel() : base(TransactionType.CheckCancel)
        {
        }
    }
}