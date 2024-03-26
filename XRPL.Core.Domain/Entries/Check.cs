using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Specifies a ledger entry that describes a check, similar to a paper personal check,
    /// which can be cashed by its destination to get money from its sender.
    /// </summary>
    public abstract class Check<TTokenAmount> : LedgerEntryBase
        where TTokenAmount : class
    {
        /// <summary>
        /// The sender of the <see cref="Check{TToken}"/>. Cashing the <see cref="Check{TToken}"/> debits this address's balance.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// The intended recipient of the Check. Only this address can cash the Check, using a CheckCash transaction.
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// A hint indicating which page of the destination's owner directory links to this object, in case the directory consists of multiple pages.
        /// </summary>
        public string? DestinationNode { get; set; }

        /// <summary>
        /// An arbitrary tag to further specify the destination for this Check, such as a hosted recipient at the destination address.
        /// </summary>
        public uint DestinationTag { get; set; }

        /// <summary>
        /// Indicates the time after which this <see cref="Check{TToken}"/> is considered expired. See Specifying Time for details.
        /// </summary>
        public uint Expiration { get; set; }

        /// <summary>
        /// Arbitrary 256-bit hash provided by the sender as a specific reason or identifier for this <see cref="Check{TToken}"/>.
        /// </summary>
        public string? InvoiceID { get; set; }

        /// <summary>
        /// A hint indicating which page of the sender's owner directory links to this object, in case the directory consists of multiple pages.
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
        /// The maximum amount of token this <see cref="Check"/> can debit the sender.
        /// <para/> If the <see cref="Check"/> is successfully cashed, the destination is credited in the same token for up to this amount.
        /// </summary>
        public TTokenAmount? SendMax { get; set; }

        /// <summary>
        /// The sequence number of the CheckCreate transaction that created this check.
        /// </summary>
        public uint Sequence { get; set; }

        /// <summary>
        /// An arbitrary tag to further specify the source for this <see cref="Check{TToken}"/>, such as a hosted recipient at the sender's address.
        /// </summary>
        public uint SourceTag { get; set; }

        /// <summary>
        /// Initializes the new instance of the <see cref="Check{TToken}"/> class.
        /// </summary>
        public Check()
        {
            LedgerEntryType = "Check";
        }
    }

    /// <summary>
    /// Represents an XRP check.
    /// </summary>
    public sealed class XRPCheck : Check<string>
    {
    }

    /// <summary>
    /// Reprsents a token check.
    /// </summary>
    public sealed class CurrencyAmountCheck : Check<CurrencyAmount>
    {
    }
}