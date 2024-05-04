using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that removes an Offer object from the XRP Ledger.
    /// </summary>
    public class OfferCancel : Transaction
    {
        /// <summary>
        /// The sequence number (or Ticket number) of a previous OfferCreate transaction.
        /// <para/>If specified, cancel any offer object in the ledger that was created by that transaction.
        /// It is not considered an error if the offer specified does not exist
        /// </summary>
        public required uint OfferSequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferCancel"/> class.
        /// </summary>
        public OfferCancel() : base(TransactionType.OfferCancel)
        {
        }
    }
}