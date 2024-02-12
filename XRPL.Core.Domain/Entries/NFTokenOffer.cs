using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents an offer to buy, sell or transfer an NFT.
    /// </summary>
    public class NFTokenOffer : LedgerEntryBase
    {
        /// <summary>
        /// Amount expected or offered for the NFToken.
        /// <para/>If the token has the lsfOnlyXRP flag set, the amount must be specified in XRP.
        /// Sell offers that specify assets other than XRP must specify a non-zero amount.
        /// Sell offers that specify XRP can be 'free' (that is, the Amount field can be equal to "0").
        /// </summary>
        public string? Amount { get; set; }

        /// <summary>
        /// The AccountID for which this offer is intended. If present, only that account can accept the offer.
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// The time after which the offer is no longer active.
        /// </para>The value is the number of seconds since the Ripple Epoch.
        /// </summary>
        public uint Expiration { get; set; }

        /// <summary>
        /// The NFTokenID of the NFToken object referenced by this offer.
        /// </summary>
        public string? NFTokenID { get; set; }

        /// <summary>
        /// Internal bookkeeping, indicating the page inside the token buy or sell offer directory, as appropriate, where this token is being tracked.
        /// <para/>This field allows the efficient deletion of offers.
        /// </summary>
        public string? NFTokenOfferNode { get; set; }

        /// <summary>
        /// Owner of the account that is creating and owns the offer.
        /// <para/> Only the current Owner of an NFToken can create an offer to sell an NFToken, but any account can create an offer to buy an NFToken.
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// Internal bookkeeping, indicating the page inside the owner directory where this token is being tracked.
        /// <para/>This field allows the efficient deletion of offers.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// Identifying hash of the transaction that most recently modified this object.
        /// </summary>
        public string? PreviousTxnID { get; set; }

        /// <summary>
        /// Index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTokenOffer"/> class.
        /// </summary>
        public NFTokenOffer()
        {
            Flags = 1;
            LedgerEntryType = "NFTokenOffer";
        }
    }
}