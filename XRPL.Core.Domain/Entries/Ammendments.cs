using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a ledger entry that describes a list of currently active ammendments.
    /// </summary>
    public class Ammendments : LedgerEntryBase
    {
        /// <summary>
        /// Array of 256-bit amendment IDs for all currently enabled amendments. If omitted, there are no enabled amendments.
        /// </summary>
        [DataMember(Name = "Ammendments")]
        public string[]? AmendmentIDs { get; set; }

        /// <summary>
        /// Array of objects describing the status of amendments that have majority support but are not yet enabled.
        /// If omitted, there are no pending amendments with majority support
        /// </summary>
        public Majority[]? Majorities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ammendments"/> class.
        /// </summary>
        public Ammendments()
        {
            LedgerEntryType = "Amendments";
        }
    }

    /// <summary>
    /// Represents the status of an ammendment.
    /// </summary>
    public class Majority
    {
        /// <summary>
        /// The Amendment ID of the pending amendment.
        /// </summary>
        public required string Amendment { get; set; }

        /// <summary>
        /// The close_time field of the ledger version where this amendment most recently gained a majority.
        /// </summary>
        public required uint CloseTime { get; set; }
    }
}