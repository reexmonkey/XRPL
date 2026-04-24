namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a ledger entry that contains the current base transaction cost and reserve amounts as determined by fee voting.
    /// <para/>
    /// Each ledger version contains at most one FeeSettings entry.
    /// </summary>
    public class FeeSettings : LedgerEntry
    {
        /// <summary>
        /// The transaction cost of the "reference transaction" in drops of XRP.
        /// </summary>
        public required string BaseFeeDrops { get; set; }

        /// <summary>
        /// The base reserve for an account in the XRP Ledger, as drops of XRP.
        /// </summary>
        public required uint ReserveBaseDrops { get; set; }

        /// <summary>
        /// The BaseFee translated into "fee units".
        /// </summary>

        /// <summary>
        /// The incremental owner reserve for owning objects, as drops of XRP.
        /// </summary>
        public required uint ReserveIncrementDrops { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public string? PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this entry.
        /// </summary>
        public string? PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeSettings"/> class.
        /// </summary>
        public FeeSettings() => LedgerEntryType = nameof(FeeSettings);
    }

    /// <summary>
    /// Represents metadata associated with a <see cref="FeeSettings"/> ledger entry.
    /// </summary>
    public class FeeSettingsMeta : LedgerEntryMeta
    {
        /// <summary>
        /// The transaction cost of the "reference transaction" in drops of XRP.
        /// </summary>
        public string? BaseFeeDrops { get; set; }

        /// <summary>
        /// The base reserve for an account in the XRP Ledger, as drops of XRP.
        /// </summary>
        public uint? ReserveBaseDrops { get; set; }

        /// <summary>
        /// The incremental owner reserve for owning objects, as drops of XRP.
        /// </summary>
        public uint? ReserveIncrementDrops { get; set; }
    }
}
