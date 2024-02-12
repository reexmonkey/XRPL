using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a collection of NFTs owned by the same account.
    /// <para/>An account can have multiple <see cref="NFTokenPage"/> entries, which form a doubly linked list.
    /// </summary>
    public class NFTokenPage : LedgerEntryBase
    {
        /// <summary>
        /// The locator of the next page, if any. Details about this field and how it should be used are outlined below.
        /// </summary>
        public string? NextPageMin { get; set; }

        /// <summary>
        /// The collection of NFToken objects contained in this <see cref="NFTokenPage"/> object.
        /// <para/>This specification places an upper bound of 32 NFToken objects per page. Objects are sorted from low to high with the NFTokenID used as the sorting parameter.
        /// </summary>
        public NFToken[]? NFTokens { get; set; }

        /// <summary>
        /// The locator of the previous page, if any. Details about this field and how it should be used are outlined below.
        /// </summary>
        public string? PreviousPageMin { get; set; }

        /// <summary>
        /// Identifies the transaction ID of the transaction that most recently modified this NFTokenPage object.
        /// </summary>
        public string? PreviousTxnID { get; set; }

        /// <summary>
        /// The sequence of the ledger that contains the transaction that most recently modified this NFTokenPage object.
        /// </summary>
        public uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTokenPage"/> class.
        /// </summary>
        public NFTokenPage()
        {
            LedgerEntryType = "NFTokenPage";
        }
    }
}