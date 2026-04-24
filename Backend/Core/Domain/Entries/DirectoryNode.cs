namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// The DirectoryNode ledger entry type provides a list of links to other entries in the ledger's state data.
    /// <para/>
    /// A single conceptual Directory　takes the form of a doubly linked list, with one or more DirectoryNode entries each containing up to 32 IDs of other entries. The first DirectoryNode entry is
    /// called the root of the directory, and all entries other than the root can be added or deleted as necessary.
    /// <para/>
    /// There are two kinds of Directories:
    /// <para/>
    /// Owner directories list other entries owned by an account, such as RippleState (trust line) or Offer entries.
    /// <para/>
    /// Offer directories list the offers available in the decentralized exchange. A single Offer directory contains all the offers that have the same exchange rate for the same token (currency code
    /// and issuer).
    /// </summary>
    public class DirectoryNode : LedgerEntry
    {
        protected DirectoryNodeFlags flags;

        /// <summary>
        /// (Offer directories only) The ledger entry ID of a permissioned domain. If present, this order book belongs to the corresponding Permissioned DEX. Otherwise, this order book is part of the
        /// open DEX.
        /// </summary>
        public string? DomainID { get; set; }

        /// <summary>
        /// The contents of this Directory: an array of IDs of other objects.
        /// </summary>
        public required string[] Indexes { get; set; }

        /// <summary>
        /// If this Directory consists of multiple pages, this ID links to the next object in the chain, wrapping around at the end.
        /// </summary>
        public uint IndexNext { get; set; }

        /// <summary>
        /// If this Directory consists of multiple pages, this ID links to the previous object in the chain, wrapping around at the beginning.
        /// </summary>
        public uint IndexPrevious { get; set; }

        /// <summary>
        /// The address of the account that owns the objects in this directory.
        /// <para/>
        /// (Owner Directories only)
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// The ID of root object for this directory.
        /// </summary>
        public required string RootIndex { get; set; }

        /// <summary>
        /// The currency code of the TakerGets amount from the offers in this directory.
        /// <para/>
        /// (Offer Directories only)
        /// </summary>
        public string? TakerGetsCurrency { get; set; }

        /// <summary>
        /// The issuer of the TakerGets amount from the offers in this directory.
        /// <para/>
        /// (Offer Directories only)
        /// </summary>
        public string? TakerGetsIssuer { get; set; }

        /// <summary>
        /// The currency code of the TakerPays amount from the offers in this directory.
        /// <para/>
        /// (Offer Directories only)
        /// </summary>
        public string? TakerPaysCurrency { get; set; }

        /// <summary>
        /// The issuer of the TakerPays amount from the offers in this directory.
        /// <para/>
        /// (Offer Directories only)
        /// </summary>
        public string? TakerPaysIssuer { get; set; }

        public override required uint Flags { get => (uint)flags; set => flags = (DirectoryNodeFlags)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryNode"/> class.
        /// </summary>
        public DirectoryNode() => LedgerEntryType = nameof(DirectoryNode);
    }

    /// <summary>
    /// Defines flags that indicate the types of offers present in a directory.
    /// </summary>
    /// <remarks>Owner directories and offer directories for fungible tokens do not use flags; their Flags value is always 0.</remarks>
    public enum DirectoryNodeFlags : uint
    {
        /// <summary>
        /// This directory contains NFT buy offers.
        /// </summary>
        lsfNFTokenBuyOffers = 0x00000001,

        /// <summary>
        /// This directory contains NFT sell offer
        /// </summary>
        lsfNFTokenSellOffers = 0x00000002
    }

    /// <summary>
    /// Represents metadata associated with a <see cref="DirectoryNode"/> ledger entry.
    /// </summary>
    public class DirectoryNodeMeta : LedgerEntryMeta
    {
        /// <summary>
        /// (Offer directories only) The ledger entry ID of a permissioned domain. If present, this order book belongs to the corresponding Permissioned DEX. Otherwise, this order book is part of the
        /// open DEX.
        /// </summary>
        public string? DomainID { get; set; }

        /// <summary>
        /// The contents of this Directory: an array of IDs of other objects.
        /// </summary>
        public string[]? Indexes { get; set; }

        /// <summary>
        /// If this Directory consists of multiple pages, this ID links to the next object in the chain, wrapping around at the end.
        /// </summary>
        public uint? IndexNext { get; set; }

        /// <summary>
        /// If this Directory consists of multiple pages, this ID links to the previous object in the chain, wrapping around at the beginning.
        /// </summary>
        public uint? IndexPrevious { get; set; }

        /// <summary>
        /// The address of the account that owns the objects in this directory.
        /// <para/>
        /// (Owner Directories only)
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// The ID of root object for this directory.
        /// </summary>
        public string? RootIndex { get; set; }

        /// <summary>
        /// The currency code of the TakerGets amount from the offers in this directory.
        /// <para/>
        /// (Offer Directories only)
        /// </summary>
        public string? TakerGetsCurrency { get; set; }

        /// <summary>
        /// The issuer of the TakerGets amount from the offers in this directory.
        /// <para/>
        /// (Offer Directories only)
        /// </summary>
        public string? TakerGetsIssuer { get; set; }

        /// <summary>
        /// The currency code of the TakerPays amount from the offers in this directory.
        /// <para/>
        /// (Offer Directories only)
        /// </summary>
        public string? TakerPaysCurrency { get; set; }

        /// <summary>
        /// The issuer of the TakerPays amount from the offers in this directory.
        /// <para/>
        /// (Offer Directories only)
        /// </summary>
        public string? TakerPaysIssuer { get; set; }
    }
}
