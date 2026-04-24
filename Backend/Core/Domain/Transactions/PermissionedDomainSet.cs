using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    public class PermissionedDomainSet : Transaction
    {
        /// <summary>
        /// The ledger entry ID of an existing permissioned domain to modify. If omitted, creates a new permissioned domain.
        /// </summary>
        public string? DomainID { get; set; }

        /// <summary>
        /// A list of 1 to 10 Accepted Credentials objects that grant access to this domain.
        /// The list does not need to be sorted, but it cannot contain duplicates.
        /// When modifying an existing domain, this list replaces the existing list.
        /// </summary>
        public required AcceptedCredential[] AcceptedCredentials { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionedDomainSet"/> class.
        /// </summary>
        public PermissionedDomainSet() : base(TransactionType.PermissionedDomainSet)
        {
        }
    }
}
