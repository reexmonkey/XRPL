using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a single cross-chain bridge that connects the XRP Ledger with another blockchain,
    /// such as its sidechain, and enables value in the form of XRP and other tokens (IOUs) to move efficiently between the two blockchains.
    /// </summary>
    public class Bridge : LedgerEntryBase
    {
        /// <summary>
        /// The account that submitted the XChainCreateBridge transaction on the blockchain
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// The minimum amount, in XRP, required for an XChainAccountCreateCommit transaction.
        /// <para/>If this isn't present, the XChainAccountCreateCommit transaction will fail. This field can only be present on XRP-XRP bridges.
        /// </summary>
        public string? MinAccountCreateAmount { get; set; }

        /// <summary>
        /// The total amount, in XRP, to be rewarded for providing a signature for cross-chain transfer or for signing for the cross-chain reward.
        /// <para/>This amount will be split among the signers.
        /// </summary>
        public required string SignatureReward { get; set; }

        /// <summary>
        /// A counter used to order the execution of account create transactions.
        /// <para/>It is incremented every time a XChainAccountCreateCommit transaction is "claimed" on the destination chain.
        /// When the "claim" transaction is run on the destination chain,
        /// the XChainAccountClaimCount must match the value that the XChainAccountCreateCount had at the time the XChainAccountClaimCount was run on the source chain.
        /// This orders the claims so that they run in the same order that the XChainAccountCreateCommit transactions ran on the source chain,
        /// to prevent transaction replay
        /// </summary>
        public required uint XChainAccountClaimCount { get; set; }

        /// <summary>
        /// A counter used to order the execution of account create transactions.
        /// <para/>It is incremented every time a successful XChainAccountCreateCommit transaction is run for the source chain.
        /// </summary>
        public required uint XChainAccountCreateCount { get; set; }

        /// <summary>
        /// The door accounts and assets of the bridge this object correlates to.
        /// </summary>
        public required XChainBridge XChainBridge { get; set; }

        /// <summary>
        /// The value of the next XChainClaimID to be created.
        /// </summary>
        public required uint XChainClaimID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bridge"/> class.
        /// </summary>
        public Bridge()
        {
            LedgerEntryType = "Bridge";
        }
    }

    /// <summary>
    /// Represents the door accounts and assets of a bridge that another bridge correlates to.
    /// </summary>
    public class XChainBridge
    {
        /// <summary>
        /// The door account on the issuing chain.
        /// <para/>For an XRP-XRP bridge, this must be the genesis account (the account that is created when the network is first started, which contains all of the XRP).
        /// </summary>
        public required string IssuingChainDoor { get; set; }

        /// <summary>
        /// The asset that is minted and burned on the issuing chain.
        /// <para/> For an IOU-IOU bridge, the issuer of the asset must be the door account on the issuing chain, to avoid supply issues.
        /// </summary>
        public required Issue IssuingChainIssue { get; set; }

        /// <summary>
        /// The door account on the locking chain.
        /// </summary>
        public required string LockingChainDoor { get; set; }

        /// <summary>
        /// The asset that is locked and unlocked on the locking chain.
        /// </summary>
        public required Issue LockingChainIssue { get; set; }
    }

    /// <summary>
    /// Represents an asset on an issuing chain.
    /// </summary>
    public class Issue : FungibleToken
    {

    }
}