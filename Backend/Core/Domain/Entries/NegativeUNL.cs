namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a ledger entry type contains the current status of the Negative UNL, a list of trusted validators currently believed to be offline.
    /// <para/> Each ledger version contains at most one NegativeUNL entry.
    /// If no validators are currently disabled or scheduled to be disabled, there is no NegativeUNL entry.
    /// </summary>
    public class NegativeUNL : LedgerEntry
    {
        /// <summary>
        /// A list of <see cref="DisabledValidator"/> objects (see below), each representing a trusted validator that is currently disabled.
        /// </summary>
        public DisabledValidator[]? DisabledValidators { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The public key of a trusted validator that is scheduled to be disabled in the next flag ledger.
        /// </summary>
        public string? ValidatorToDisable { get; set; }

        /// <summary>
        /// The public key of a trusted validator in the Negative UNL that is scheduled to be re-enabled in the next flag ledger.
        /// </summary>
        public string? ValidatorToReEnable { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeUNL"/> class.
        /// </summary>
        public NegativeUNL() => LedgerEntryType = nameof(NegativeUNL);
    }

    /// <summary>
    /// Represents a disabled validator.
    /// </summary>
    public record DisabledValidator
    {
        /// <summary>
        /// The ledger index when the validator was added to the Negative UNL.
        /// </summary>
        public required uint FirstLedgerSequence { get; init; }

        /// <summary>
        /// The master public key of the validator, in hexadecimal.
        /// </summary>
        public required string PublicKey { get; init; }
    }

    /// <summary>
    /// Represents metadata associated with a <see cref="NegativeUNL"/> ledger entry.
    /// </summary>
    public class NegativeUNLMeta : LedgerEntryMeta
    {
        /// <summary>
        /// A list of <see cref="DisabledValidator"/> objects, each representing a trusted validator that is currently disabled.
        /// </summary>
        public DisabledValidator[]? DisabledValidators { get; set; }

        /// <summary>
        /// The public key of a trusted validator that is scheduled to be disabled in the next flag ledger.
        /// </summary>
        public string? ValidatorToDisable { get; set; }

        /// <summary>
        /// The public key of a trusted validator in the Negative UNL that is scheduled to be re-enabled in the next flag ledger.
        /// </summary>
        public string? ValidatorToReEnable { get; set; }
    }
}
