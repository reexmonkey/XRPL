namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a list of parties that, as a group, are authorized to sign a transaction in place of an individual account by multi-signing.
    /// </summary>
    public class SignerList : LedgerEntry
    {
        private SignerListFlags flags;

        /// <summary>
        /// A hint indicating which page of the owner directory links to this object, in case the directory consists of multiple pages.
        /// </summary>
        public required string OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this object.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required string PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// An array of Signer Entry objects representing the parties who are part of this signer list.
        /// </summary>
        public required SignerEntry[] SignerEntries { get; set; }

        /// <summary>
        /// An ID for this signer list.
        /// <para/>Currently always set to 0. If a future amendment allows multiple signer lists for an account, this may change.
        /// </summary>
        public required uint SignerListID { get; set; }

        /// <summary>
        /// A target number for signer weights. To produce a valid signature for the owner of this SignerList, the signers must provide valid signatures whose weights sum to this value or more.
        /// </summary>
        public required uint SignerQuorum { get; set; }

        /// <summary>
        /// A bit-map of boolean options enabled for this entry.
        /// </summary>
        public required override uint Flags { get => (uint)flags; set => flags = (SignerListFlags)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignerList"/> class.
        /// </summary>
        public SignerList() => LedgerEntryType = nameof(SignerList);
    }

    /// <summary>
    /// Represents an entry that describes a signer in the list.
    /// </summary>
    public record SignerEntry
    {
        /// <summary>
        /// An XRP Ledger address whose signature contributes to the multi-signature. It does not need to be a funded address in the ledger.
        /// </summary>
        public required string Account { get; init; }

        /// <summary>
        /// The weight of a signature from this signer.
        /// <para/>A multi-signature is only valid if the sum weight of the signatures provided meets or exceeds the signer list's SignerQuorum value.
        /// </summary>
        public required uint SignerWeight { get; init; }

        /// <summary>
        /// (Optional) Arbitrary hexadecimal data.
        /// <para/>This can be used to identify the signer or for other, related purposes. (Added by the ExpandedSignerList amendment.)
        /// </summary>
        public string? WalletLocator { get; init; }
    }

    /// <summary>
    /// Represents flags of a <see cref="SignerList"/>.
    /// </summary>
    public enum SignerListFlags : uint
    {
        /// <summary>
        /// If this flag is enabled, this SignerList counts as one item for purposes of the owner reserve.
        /// Otherwise, this list counts as N+2 items, where N is the number of signers it contains.
        /// This flag is automatically enabled if you add or update a signer list after the MultiSignReserve amendment is enabled
        /// </summary>
        lsfOneOwnerCount = 0x00010000
    }

    /// <summary>
    /// Represents metadata associated with a <see cref="SignerList"/> ledger entry.
    /// </summary>
    public class SignerListMeta : LedgerEntryMeta
    {
        /// <summary>
        /// A hint indicating which page of the owner directory links to this object, in case the directory consists of multiple pages.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// An array of Signer Entry objects representing the parties who are part of this signer list.
        /// </summary>
        public SignerEntry[]? SignerEntries { get; set; }

        /// <summary>
        /// An ID for this signer list.
        /// <para/>Currently always set to 0. If a future amendment allows multiple signer lists for an account, this may change.
        /// </summary>
        public uint? SignerListID { get; set; }

        /// <summary>
        /// A target number for signer weights. To produce a valid signature for the owner of this SignerList, the signers must provide valid signatures whose weights sum to this value or more.
        /// </summary>
        public uint? SignerQuorum { get; set; }
    }
}
