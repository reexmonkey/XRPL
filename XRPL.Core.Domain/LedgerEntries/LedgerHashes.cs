using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.LedgerEntries
{
    /// <summary>
    /// Represents a ledger entry that contains a history of prior ledgers that led up to this ledger version, in the form of their hashes. 
    /// <para/>Objects of this ledger type are modified automatically when closing a ledger. 
    /// (This is one of the only times a ledger's state data is modified without a transaction or pseudo-transaction.) 
    /// The LedgerHashes objects exist to make it possible to look up a previous ledger's hash with only the current ledger version and at most one lookup of a previous ledger version.
    /// </summary>
    public class LedgerHashes: LedgerEntryBase
    {
        /// <summary>
        /// An array of up to 256 ledger hashes. The contents depend on which sub-type of LedgerHashes object this is.
        /// </summary>
        public string[]? Hashes { get; set; }


        /// <summary>
        /// The Ledger Index of the last entry in this object's Hashes array.
        /// </summary>
        public uint LastLedgerSequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LedgerHashes"/> class.
        /// </summary>
        public LedgerHashes()
        {
            LedgerEntryType = "0x0068";
        }

    }
}
