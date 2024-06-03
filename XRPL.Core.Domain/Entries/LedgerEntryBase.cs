namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Specifies a ledger entry that contains a set of common fields.
    /// </summary>
    public abstract class LedgerEntryBase
    {
        /// <summary>
        /// The type of ledger entry. Valid ledger entry types include <see cref="AccountRoot"/>, Offer, RippleState, and others.
        /// </summary>
        public required string LedgerEntryType { get; set; }

        /// <summary>
        /// Set of bit-flags for this ledger entry.
        /// </summary>
        public required uint Flags { get; set; }
    }
}