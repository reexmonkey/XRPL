using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents a ledger entry type that contains a list of ammendments, which are currently active.
    /// </summary>
    public class Ammendments: LedgerEntryBase
    {
        /// <summary>
        /// Array of 256-bit amendment IDs for all currently enabled amendments. If omitted, there are no enabled amendments.
        /// </summary>
        [DataMember(Name = "Ammendments")]
        public string[]? AmendmentIDs { get; set; }

        /// <summary>
        /// A bit-map of boolean flags enabled for this object. Currently, the protocol defines no flags for Amendments objects. The value is always 0
        /// </summary>
        public override uint Flags { get => base.Flags; set => base.Flags = value; }

        /// <summary>
        /// The value 0x0066, mapped to the string Amendments, indicates that this object describes the status of amendments to the XRP Ledger.
        /// </summary>
        public override string? LedgerEntryType { get => base.LedgerEntryType; set => base.LedgerEntryType = value; }

        /// <summary>
        /// Array of objects describing the status of amendments that have majority support but are not yet enabled. 
        /// If omitted, there are no pending amendments with majority support
        /// </summary>
        public Majority[]? Majorities { get; set; }
    }

    /// <summary>
    /// Represents the status of an ammendment.
    /// </summary>
    public class Majority
    {
        /// <summary>
        /// The Amendment ID of the pending amendment.
        /// </summary>
        public string? Amendment { get; set; }

        /// <summary>
        /// The close_time field of the ledger version where this amendment most recently gained a majority.
        /// </summary>
        public uint? CloseTime { get; set; }
    }
}
