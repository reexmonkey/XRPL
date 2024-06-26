﻿namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a ledger entry holds references to, or data associated with, a single DID.
    /// </summary>
    public class DID : LedgerEntryBase
    {
        /// <summary>
        /// The account that controls the DID.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// The W3C standard DID document associated with the DID. 
        /// <para/>The DIDDocument field isn't checked for validity and is limited to a maximum length of 256 bytes.
        /// </summary>
        public string? DIDDocument { get; set; }

        /// <summary>
        /// The public attestations of identity credentials associated with the DID. 
        /// <para/>The Data field isn't checked for validity and is limited to a maximum length of 256 bytes.
        /// </summary>
        public string? Data { get; set; }

        /// <summary>
        /// A hint indicating which page of the sender's owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this object.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The Universal Resource Identifier that points to the corresponding DID document or the data associated with the DID. 
        /// <para/>This field can be an HTTP(S) URL or IPFS URI. 
        /// This field isn't checked for validity and is limited to a maximum length of 256 bytes.
        /// </summary>
        public string? URI { get; set; }

        /// <summary>
        /// Initialzes a new instance of the <see cref="DID"/> class.
        /// </summary>
        public DID()
        {
            LedgerEntryType = "DID";
        }
    }
}
