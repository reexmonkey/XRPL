namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a Ticket, which tracks an account sequence number that has been set aside for future use.
    /// <para/>You can create new tickets with a TicketCreate transaction.
    /// </summary>
    public class Ticket : LedgerEntryBase
    {
        /// <summary>
        /// The account that owns this Ticket.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this entry.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The Sequence Number this Ticket sets aside.
        /// </summary>
        public required uint TicketSequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class.
        /// </summary>
        public Ticket()
        {
            LedgerEntryType = "Ticket";
        }
    }
}