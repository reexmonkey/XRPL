using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.LedgerEntries
{
    /// <summary>
    /// Represents a ledger entry that contains the current base transaction cost and reserve amounts as determined by fee voting. 
    /// <para/>Each ledger version contains at most one FeeSettings entry.
    /// </summary>
    public class FeeSettings: LedgerEntryBase
    {
        /// <summary>
        /// The transaction cost of the "reference transaction" in drops of XRP as hexadecimal.
        /// </summary>
        public string? BaseFee { get; set; }

        /// <summary>
        /// The BaseFee translated into "fee units".
        /// </summary>
        public uint ReferenceFeeUnits { get; set; }

        /// <summary>
        /// The base reserve for an account in the XRP Ledger, as drops of XRP.
        /// </summary>
        public uint ReserveBase { get; set; }

        /// <summary>
        /// The incremental owner reserve for owning objects, as drops of XRP.
        /// </summary>
        public uint ReserveIncrement { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeSettings"/> class.
        /// </summary>
        public FeeSettings()
        {
            LedgerEntryType = " 0x0073";
        }
    }
}
