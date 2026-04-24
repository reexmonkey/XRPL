namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Delete a Multi-purpose Token (MPT) issuance. Only the issuer can delete an MPT issuance, and only if there are no holders of the MPT.
    /// </summary>
    public class MPTokenIssuanceDestroy : Transaction
    {
        /// <summary>
        /// Identifies the MPTokenIssuance object to be removed by the transaction.
        /// </summary>
        public required string MPTokenIssuanceID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MPTokenIssuanceDestroy"/> class.
        /// </summary>
        public MPTokenIssuanceDestroy() : base(TransactionType.MPTokenIssuanceDestroy)
        {
        }
    }
}