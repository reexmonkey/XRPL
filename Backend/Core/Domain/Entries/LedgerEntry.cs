namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Specifies a ledger entry that contains a set of common fields.
    /// </summary>
    public abstract class LedgerEntry
    {
        /// <summary>
        /// The unique ID for this ledger entry. In JSON, this field is represented with different names depending on the context and API method. (Note, even though this is specified as "optional" in
        /// the code, every ledger entry should have one unless it's legacy data from very early in the XRP Ledger's history.)
        /// </summary>
        public required uint Index { get; set; }

        /// <summary>
        /// The type of ledger entry. Valid ledger entry types include <see cref="AccountRoot"/>, Offer, RippleState, and others.
        /// </summary>
        public required string LedgerEntryType { get; set; }

        /// <summary>
        /// Set of bit-flags for this ledger entry.
        /// </summary>
        public required virtual uint Flags { get; set; }
    }

    /// <summary>
    /// Provides a base class for representing metadata associated with a ledger entry.
    /// </summary>
    /// <remarks>This abstract class is intended to be extended by specific implementations to customize
    /// ledger entry metadata. Use derived types to define additional attributes or behaviors relevant to particular
    /// ledger entry scenarios.</remarks>
    public abstract class LedgerEntryMeta;

}