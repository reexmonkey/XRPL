namespace XRPL.Core.Domain.PseudoTransactions
{
    /// <summary>
    /// Specifies a pseudo-transaction.
    /// <para/>Pseudo-transactions are never submitted by users, nor propagated through the network. Instead, a server may choose to inject pseudo-transactions in a proposed ledger directly according to specific protocol rules. If enough servers propose the exact same pseudo-transaction, the consensus process approves it, and the pseudo-transaction is included in that ledger's transaction data.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="PseudoTransaction"/> class with a pseudo-transaction type.
    /// </remarks>
    /// <param name="transactionType">The type of pseudo-transaction.</param>
    public abstract class PseudoTransaction(PseudoTransactionType transactionType)
    {
        /// <summary>
        /// (Required) The unique address of the account that initiated the transaction.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// (Required; auto-fillable) Integer amount of XRP, in drops,
        /// to be destroyed as a cost for distributing this transaction to the network.
        /// <para/>Some transaction types have different minimum requirements.
        /// </summary>
        public required string Fee { get; set; } = "0";

        /// <summary>
        /// (Required; auto-fillable) The sequence number of the account sending the transaction.
        /// <para/>A transaction is only valid if the Sequence number is exactly 1 greater than the previous transaction from the same account. The special case 0 means the transaction is using a Ticket instead (Added by the TicketBatch amendment.).
        /// </summary>
        public required uint Sequence { get; set; } = 0;

        /// <summary>
        /// (Automatically added when signing) Hex representation of the public key that corresponds to the private key used to sign this transaction.
        /// <para/>If an empty string, indicates a multi-signature is present in the Signers field instead.
        /// </summary>
        public string SigningPubKey { get; set; } = string.Empty;

        /// <summary>
        /// (Automatically added when signing) The signature that verifies this transaction as originating from the account it says it is from.
        /// </summary>
        public string TxnSignature { get; set; } = string.Empty;

        /// <summary>
        /// The type of transaction.
        /// </summary>
        public required PseudoTransactionType TransactionType { get; set; } = transactionType;

        /// <summary>
        /// (Optional) Set of bit-flags for this transaction.
        /// <para/>The meaning of specific flags varies based on the transaction type.
        /// </summary>
        public virtual uint? Flags { get; set; }
    }

    /// <summary>
    /// Represents the type of operation a transaction is supposed to do.
    /// </summary>
    public enum PseudoTransactionType : ushort
    {
        /// <summary>
        /// An EnableAmendment pseudo-transaction marks a change in the status of a proposed amendment.
        /// </summary>
        EnableAmendment,

        /// <summary>
        /// A SetFee pseudo-transaction marks a change in transaction cost or reserve requirements as a result of Fee Voting.
        /// </summary>
        SetFee,

        /// <summary>
        /// A UNLModify pseudo-transaction marks a change to the Negative UNL, indicating that a trusted validator has gone offline or come back online.
        /// </summary>
        UNLModify = 0x0066,
    }
}
