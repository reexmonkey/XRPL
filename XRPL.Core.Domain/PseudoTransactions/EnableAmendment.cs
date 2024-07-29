namespace XRPL.Core.Domain.PseudoTransactions
{
    /// <summary>
    /// Represents a pseudo-transaction that marks a change in the status of a proposed amendment when it:
    /// <para/>- Gains supermajority approval from validators.
    /// <para/>- Loses supermajority approval.
    /// <para/>- Is enabled on the XRP Ledger protocol.
    /// </summary>
    public class EnableAmendment : PseudoTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnableAmendment"/> class.
        /// </summary>
        public EnableAmendment() : base(PseudoTransactionType.EnableAmendment)
        {
        }

        /// <summary>
        /// (Required; auto-fillable) Integer amount of XRP, in drops,
        /// to be destroyed as a cost for distributing this transaction to the network.
        /// <para/>Some transaction types have different minimum requirements.
        /// </summary>
        public required string Amendment { get; set; }

        /// <summary>
        /// (Required; auto-fillable) The sequence number of the account sending the transaction.
        /// <para/>A transaction is only valid if the Sequence number is exactly 1 greater than the previous transaction from the same account. 
        /// The special case 0 means the transaction is using a Ticket instead (Added by the TicketBatch amendment.).
        /// </summary>
        public required uint LedgerSequence { get; set; }
    }

    /// <summary>
    /// Represents the status of the amendment at the time of the ledger including the pseudo-transaction.
    /// </summary>
    public enum EnableAmendmentFlags : uint
    {
        /// <summary>
        /// Support for this amendment increased to at least 80% of trusted validators starting with this ledger version.
        /// </summary>
        tfGotMajority = 0x00010000,

        /// <summary>
        /// Support for this amendment decreased to less than 80% of trusted validators starting with this ledger version.
        /// </summary>
        tfLostMajority = 0x00020000
    }
}