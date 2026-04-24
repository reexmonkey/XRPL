namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Delete a permissioned domain that you own.
    /// </summary>
    public class PermissionedDomainDelete : Transaction
    {
        /// <summary>
        /// 	The ledger entry ID of the Permissioned Domain entry to delete.
        /// </summary>
        public required string DomainID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionedDomainDelete"/> class.
        /// </summary>
        public PermissionedDomainDelete() : base(TransactionType.PermissionedDomainDelete)
        {
        }
    }
}
