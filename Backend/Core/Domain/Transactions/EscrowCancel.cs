namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that returns escrowed XRP to the sender.
    /// <para/> Any account may submit an EscrowCancel transaction.
    /// <para/> - If the corresponding EscrowCreate transaction did not specify a CancelAfter time, the EscrowCancel transaction fails.
    /// <para/> - Otherwise the EscrowCancel transaction fails if the CancelAfter time is after the close time of the most recently-closed ledger.
    /// </summary>
    public class EscrowCancel : Transaction
    {
        /// <summary>
        /// Address of the source account that funded the escrow payment.
        /// </summary>
        public required string Owner { get; set; }

        /// <summary>
        /// Transaction sequence (or Ticket number) of <see cref="EscrowCreate"/> transaction that created the escrow to cancel.
        /// </summary>
        public required string OfferSequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EscrowCancel"/> class.
        /// </summary>
        public EscrowCancel() : base(TransactionType.EscrowCancel)
        {
        }
    }
}