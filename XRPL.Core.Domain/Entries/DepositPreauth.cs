using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a type that tracks a preauthorization from one account to another. 
    /// <para/> DepositPreauth transactions create these entries.
    /// <para/> This has no effect on processing of transactions unless the account that provided the preauthorization requires Deposit Authorization. 
    /// In that case, the account that was preauthorized can send payments and other transactions directly to the account that provided the preauthorization
    /// Preauthorizations are one-directional, and have no effect on payments going the opposite direction.
    /// </summary>
    public class DepositPreauth : LedgerEntryBase
    {
        /// <summary>
        /// The account that granted the preauthorization.
        /// <para/> (The destination of the preauthorized payments.)
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// The account that received the preauthorization.
        /// <para/>(The sender of the preauthorized payments.)
        /// </summary>
        public string? Authorize { get; set; }

        /// <summary>
        /// A hint indicating which page of the sender's owner directory links to this object, in case the directory consists of multiple pages.
        /// <para/>Note: The object does not contain a direct link to the owner directory containing it, since that value can be derived from the Account.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this object.
        /// </summary>
        public string? PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositPreauth"/> class.
        /// </summary>
        public DepositPreauth()
        {
            LedgerEntryType = "DepositPreauth";
        }
    }
}