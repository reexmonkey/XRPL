using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Specifies a ledger entry that contains a set of common fields.
    /// </summary>
    public abstract class LedgerEntryBase
    {
        /// <summary>
        /// The unique ID for this ledger entry.
        /// <para/> In JSON, this field is represented with different names depending on the context and API method. 
        /// (Note, even though this is specified as "optional" in the code, every ledger entry should have one unless it's legacy data from very early in the XRP Ledger's history.)
        /// </summary>
        public virtual string? Index { get; set; }

        /// <summary>
        /// The unique ID for this ledger entry.
        /// <para/> In JSON, this field is represented with different names depending on the context and API method. 
        /// (Note, even though this is specified as "optional" in the code, every ledger entry should have one unless it's legacy data from very early in the XRP Ledger's history.)
        /// </summary>
        public virtual string? LedgerIndex { get => Index; set => Index = value; }

        /// <summary>
        /// The type of ledger entry. Valid ledger entry types include <see cref="AccountRoot"/>, Offer, RippleState, and others.
        /// </summary>
        public virtual string? LedgerEntryType { get; set; }

        /// <summary>
        /// Set of bit-flags for this ledger entry.
        /// </summary>
        public virtual uint Flags { get; set; }
    }
}
