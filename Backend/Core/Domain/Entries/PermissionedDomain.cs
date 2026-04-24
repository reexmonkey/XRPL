using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    public class PermissionedDomain : LedgerEntry
    {
        /// <summary>
        /// A list of 1 to 10 Credential objects that grant access to this domain. The array is stored sorted by issuer.
        /// </summary>
        public required AcceptedCredential[] AcceptedCredentials { get; set; }

        /// <summary>
        /// The address of the account that owns this domain.
        /// </summary>
        public required string Owner { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The Sequence value of the OfferCreate transaction that created this offer.
        /// </summary>
        public uint Sequence { get; set; }

        public PermissionedDomain() => LedgerEntryType = nameof(PermissionedDomain);
    }

    /// <summary>
    /// Represents metadata associated with a <see cref="PermissionedDomain"/> ledger entry.
    /// </summary>
    public class PermissionedDomainMeta : LedgerEntryMeta
    {
        /// <summary>
        /// A list of 1 to 10 Credential objects that grant access to this domain. The array is stored sorted by issuer.
        /// </summary>
        public AcceptedCredential[]? AcceptedCredentials { get; set; }

        /// <summary>
        /// The address of the account that owns this domain.
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// The Sequence value of the OfferCreate transaction that created this offer.
        /// </summary>
        public uint? Sequence { get; set; }
    }
}
