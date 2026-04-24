using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// An MPToken entry tracks <see cref="MPT"/>s held by an account that is not the token issuer.
    /// </summary>
    public class MPToken : LedgerEntry
    {
        private MPTokenFlags flags;

        /// <summary>
        /// The owner (holder) of these MPTs.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// The MPTokenIssuance identifier.
        /// </summary>
        public required string MPTokenIssuanceID { get; set; }

        /// <summary>
        /// The amount of tokens currently held by the owner. The minimum is 0 and the maximum is 2^63-1.
        /// </summary>
        public required string MPTAmount { get; set; }

        /// <summary>
        /// The amount of tokens currently locked up (for example, in escrow).
        /// </summary>
        public string? LockedAmount { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The sequence of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string OwnerNode { get; set; }

        /// <summary>
        /// Set of bit-flags for this ledger entry.
        /// </summary>

        public required override uint Flags { get => (uint)flags; set => flags = (MPTokenFlags)value; }

        /// <summary>
        /// Initializes a new instance of the MPToken class.
        /// </summary>
        public MPToken() => LedgerEntryType = nameof(MPToken);
    }

    /// <summary>
    /// Defines flags that represent the state and authorization of a Multi-Purpose Token (MPT) associated with an account.
    /// </summary>
    /// <remarks>
    /// These flags are used to indicate whether the MPT is locked or authorized for use in transactions. The lsfMPTLocked flag prevents the MPT from being used in transactions other than sending
    /// value back to the issuer, while the lsfMPTAuthorized flag indicates that the holder has been authorized by the issuer to use the MPT.
    /// </remarks>
    public enum MPTokenFlags : uint
    {
        /// <summary>
        /// If enabled, indicates that the MPT owned by this account is currently locked and cannot be used in any XRP transactions other than sending value back to the issuer.
        /// </summary>
        lsfMPTLocked = 0x00000001,

        /// <summary>
        /// (Only applicable for allow-listing) If set, indicates that the issuer has authorized the holder for the MPT. This flag can be set using a MPTokenAuthorize transaction; it can also be
        /// "un-set" using a MPTokenAuthorize transaction specifying the tfMPTUnauthorize flag.
        /// </summary>
        lsfMPTAuthorized = 0x00000002
    }

    /// <summary>
    /// Represents metadata associated with an <see cref="MPToken"/> ledger entry.
    /// </summary>
    public class MPTokenMeta : LedgerEntryMeta
    {
        /// <summary>
        /// The owner (holder) of these MPTs.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// The MPTokenIssuance identifier.
        /// </summary>
        public string? MPTokenIssuanceID { get; set; }

        /// <summary>
        /// The amount of tokens currently held by the owner. The minimum is 0 and the maximum is 2^63-1.
        /// </summary>
        public string? MPTAmount { get; set; }

        /// <summary>
        /// The amount of tokens currently locked up (for example, in escrow).
        /// </summary>
        public string? LockedAmount { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? OwnerNode { get; set; }
    }
}
