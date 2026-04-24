using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Update a mutable property of a Multi-purpose Token (MPT) issuance, including locking (freezing) or unlocking the tokens globally or for an individual holder.
    /// </summary>
    public class MPTokenIssuanceSet : Transaction
    {
        private MPTokenIssuanceSetFlags? flags;

        /// <summary>
        /// The ledger entry ID of a permissioned domain that grants access to the MPT.
        /// An empty value or 0 removes the permissioned domain from the MPT issuance so that only users who are explicitly approved by the issuer can send and receive the MPT.
        /// You can only set a DomainID if the MPT issuance has Require Auth enabled.
        /// </summary>
        public string? DomainID { get; set; }

        /// <summary>
        /// The identifier of the <see cref="MPTokenIssuance"/> to update.
        /// </summary>
        public required string MPTokenIssuanceID { get; set; }

        /// <summary>
        /// An individual token holder. If provided, apply changes to the given holder's balance of the given MPT issuance.
        /// If omitted, apply to all accounts holding the given MPT issuance.
        /// </summary>
        public string? Holder { get; set; }

        public override uint? Flags { get => (uint?)flags; set => flags = (MPTokenIssuanceSetFlags?)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MPTokenIssuanceSet"/> class.
        /// </summary>
        public MPTokenIssuanceSet() : base(TransactionType.MPTokenIssuanceSet)
        {
        }
    }

    /// <summary>
    /// Specifies flags that control the locking and unlocking of balances for a Multi-Party Token (MPT) issuance
    /// operation.
    /// </summary>
    /// <remarks>These flags can be combined using a bitwise OR operation to apply multiple settings
    /// simultaneously. Use these flags to manage the state of MPT token balances during issuance operations.</remarks>
    public enum MPTokenIssuanceSetFlags : uint
    {
        /// <summary>
        /// Enable to lock balances of this MPT issuance.
        /// </summary>
        tfMPTLock = 0x00000001,

        /// <summary>
        /// Enable to unlock balances of this MPT issuance.
        /// </summary>
        tfMPTUnlock = 0x00000002,

        /// <summary>
        /// If the RequireFullyCanonicalSig amendment is not enabled, this flag enforces a fully-canonical signature
        /// </summary>
        [Obsolete("No effect")]
        tfFullyCanonicalSig = 0x80000000,

        /// <summary>
        /// This flag is only used if a transaction is an inner transaction in a Batch transaction.
        /// This signifies that the transaction isn't signed. Any normal transaction that includes this flag is rejected.
        /// </summary>
        tfInnerBatchTxn = 0x40000000
    }
}