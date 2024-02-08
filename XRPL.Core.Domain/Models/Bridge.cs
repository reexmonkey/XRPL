using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents a single cross-chain bridge that connects the XRP Ledger with another blockchain, 
    /// such as its sidechain, and enables value in the form of XRP and other tokens (IOUs) to move efficiently between the two blockchains.
    /// </summary>
    public class Bridge: LedgerEntryBase
    {
        /// <summary>
        /// The account that submitted the XChainCreateBridge transaction on the blockchain
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// The minimum amount, in XRP, required for an XChainAccountCreateCommit transaction. 
        /// <para/>If this isn't present, the XChainAccountCreateCommit transaction will fail. This field can only be present on XRP-XRP bridges.
        /// </summary>
        public XrpCurrencyAmount? MinAccountCreateAmount { get; set; }

        /// <summary>
        /// The total amount, in XRP, to be rewarded for providing a signature for cross-chain transfer or for signing for the cross-chain reward. 
        /// <para/>This amount will be split among the signers.
        /// </summary>
        public XrpCurrencyAmount? SignatureReward { get; set; }

        /// <summary>
        /// A counter used to order the execution of account create transactions. 
        /// <para/>It is incremented every time a XChainAccountCreateCommit transaction is "claimed" on the destination chain. 
        /// When the "claim" transaction is run on the destination chain, 
        /// the XChainAccountClaimCount must match the value that the XChainAccountCreateCount had at the time the XChainAccountClaimCount was run on the source chain. 
        /// This orders the claims so that they run in the same order that the XChainAccountCreateCommit transactions ran on the source chain, 
        /// to prevent transaction replay
        /// </summary>
        public uint XChainAccountClaimCount { get; set; }

        /// <summary>
        /// A counter used to order the execution of account create transactions. 
        /// <para/>It is incremented every time a successful XChainAccountCreateCommit transaction is run for the source chain.
        /// </summary>
        public uint XChainAccountCreateCount { get; set; }

        /// <summary>
        /// The door accounts and assets of the bridge this object correlates to.
        /// </summary>
        public XChainBridge? XChainBridge { get; set; }

        /// <summary>
        /// The value of the next XChainClaimID to be created.
        /// </summary>
        public uint XChainClaimID { get; set; }
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
        public string? IssuingChainDoor { get; set; }

        /// <summary>
        /// The asset that is minted and burned on the issuing chain. 
        /// <para/> For an IOU-IOU bridge, the issuer of the asset must be the door account on the issuing chain, to avoid supply issues.
        /// </summary>
        public Issue? IssuingChainIssue { get; set; }

        /// <summary>
        /// The door account on the locking chain.
        /// </summary>
        public string? LockingChainDoor { get; set; }

        /// <summary>
        /// The asset that is locked and unlocked on the locking chain.
        /// </summary>
        public Issue? LockingChainIssue { get;set; }
    }

    /// <summary>
    /// Represents an asset on an issuing chain.
    /// </summary>
    public class Issue
    {
        /// <summary>
        /// The currency of the issue.
        /// </summary>
        public string? Currency { get; set; }
    }
}
