﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Models
{
    public class Escrow : LedgerEntryBase
    {
        /// <summary>
        /// The address of the owner (sender) of this escrow. This is the account that provided the XRP, and gets it back if the escrow is canceled.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// The amount of XRP, in drops, currently held in the escrow.
        /// </summary>
        public string? Amount { get; set; }

        /// <summary>
        /// The escrow can be canceled if and only if this field is present and the time it specifies has passed.
        /// <para/>Specifically, this is specified as seconds since the Ripple Epoch and it "has passed" if it's earlier than the close time of the previous validated ledger.
        /// </summary>
        public uint CancelAfter { get; set; }

        /// <summary>
        /// A PREIMAGE-SHA-256 crypto-condition, as hexadecimal.
        /// <para/> If present, the EscrowFinish transaction must contain a fulfillment that satisfies this condition.
        /// </summary>
        public string? Condition { get; set; }

        /// <summary>
        /// The destination address where the XRP is paid if the escrow is successful.
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// A hint indicating which page of the destination's owner directory links to this object, #
        /// in case the directory consists of multiple pages.
        /// <para/>Omitted on escrows created before enabling the fix1523 amendment.
        /// </summary>
        public string? DestinationNode { get; set; }

        /// <summary>
        /// An arbitrary tag to further specify the destination for this escrow, such as a hosted recipient at the destination address.
        /// </summary>
        public uint DestinationTag { get; set; }

        /// <summary>
        /// The time, in seconds since the Ripple Epoch, after which this escrow can be finished.
        /// <para/>Any EscrowFinish transaction before this time fails.
        /// <para/>(Specifically, this is compared with the close time of the previous validated ledger.)
        /// </summary>
        public uint FinishAfter { get; set; }

        /// <summary>
        /// A hint indicating which page of the sender's owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public string? PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this entry.
        /// </summary>
        public uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// An arbitrary tag to further specify the source for this escrow, such as a hosted recipient at the owner's address
        /// </summary>
        public uint SourceTag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Escrow"/> class.
        /// </summary>
        public Escrow()
        {
            LedgerEntryType = "0x0075";
        }
    }
}