namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that deletes a price oracle. Only the owner of the price oracle can send this transaction.
    /// </summary>
    public class OracleDelete : Transaction
    {
        /// <summary>
        /// The identifying number of the price oracle, which must be unique per owner.
        /// </summary>
        public required string OracleDocumentID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OracleDelete"/> class.
        /// </summary>
        public OracleDelete() : base(TransactionType.OracleDelete)
        {
        }
    }
}