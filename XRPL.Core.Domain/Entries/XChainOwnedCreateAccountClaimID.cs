using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a ledger entry that is used to collect attestations for creating an account via a cross-chain transfer.
    /// <para/> It is created when an XChainAddAccountCreateAttestation transaction adds a signature attesting to a XChainAccountCreateCommit transaction and the XChainAccountCreateCount is greater than or equal to the current XChainAccountClaimCount on the Bridge ledger object.
    /// <para/>The ledger object is destroyed when all the attestations have been received and the funds have transferred to the new account.
    /// </summary>
    public class XChainOwnedCreateAccountClaimID : LedgerEntryBase
    {
        /// <summary>
        /// The account that owns this object.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// The ledger index is a hash of a unique prefix for XChainOwnedCreateAccountClaimIDs,
        /// the actual XChainAccountClaimCount value, and the fields in XChainBridge.
        /// </summary>
        public required string LedgerIndex { get; set; }

        /// <summary>
        /// An integer that determines the order that accounts created through cross-chain transfers must be performed.
        /// <para/>Smaller numbers must execute before larger numbers.
        /// </summary>
        public required ulong XChainAccountCreateCount { get; set; }

        /// <summary>
        /// The door accounts and assets of the bridge this object correlates to.
        /// </summary>
        public required XChainBridge XChainBridge { get; set; }

        /// <summary>
        /// Attestations collected from the witness servers.
        /// This includes the parameters needed to recreate the message that was signed, including the amount, destination, signature reward amount, and reward account for that signature.
        /// With the exception of the reward account, all signatures must sign the message created with common parameters.
        /// </summary>
        public required XChainCreateAccountAttestation[] XChainCreateAccountAttestations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XChainOwnedCreateAccountClaimID"/> class.
        /// </summary>
        protected XChainOwnedCreateAccountClaimID()
        {
            LedgerEntryType = "XChainOwnedCreateAccountClaimID";
        }
    }

    /// <summary>
    /// Represents an attestation collected from a witness server.
    /// <para/>This includes the parameters needed to recreate the message that was signed, including the amount, destination, signature reward amount, and reward account for that signature. With the exception of the reward account, all signatures must sign the message created with common parameters.
    /// </summary>
    public class XChainCreateAccountAttestation
    {
        /// <summary>
        /// An attestation from one witness server.
        /// </summary>
        public required XChainCreateAccountAttestation XChainCreateAccountProofSig { get; set; }

        /// <summary>
        /// The amount committed by the XChainAccountCreateCommit transaction on the source chain.
        /// </summary>
        public object Amount { get; set; } = null!;

        /// <summary>
        /// The account that should receive this signer's share of the SignatureReward.
        /// </summary>
        public required string AttestationRewardAccount { get; set; }

        /// <summary>
        /// The account on the door account's signer list that is signing the transaction.
        /// </summary>
        public required string AttestationSignerAccount { get; set; }

        /// <summary>
        /// The destination account for the funds on the destination chain.
        /// </summary>
        public required string Destination { get; set; }

        /// <summary>
        /// The public key used to verify the signature.
        /// </summary>
        public required string PublicKey { get; set; }

        /// <summary>
        /// A boolean representing the chain where the event occurred.
        /// </summary>
        public required byte WasLockingChainSend { get; set; }
    }

    /// <summary>
    /// Represents an attestation collected from a witness server.
    /// <para/>This includes the parameters needed to recreate the message that was signed, including the amount in XRP drops, destination, signature reward amount, and reward account for that signature. With the exception of the reward account, all signatures must sign the message created with common parameters.
    /// </summary>
    public sealed class XrpXChainCreateAccountAttestation : XChainCreateAccountAttestation
    {
        /// <summary>
        /// The amount in XRP drops committed by the XChainAccountCreateCommit transaction on the source chain.
        /// </summary>
        public new required string Amount { get => (string)base.Amount; set => base.Amount = value; }
    }

    /// <summary>
    /// Represents an attestation collected from a witness server.
    /// <para/>This includes the parameters needed to recreate the message that was signed, including the amount and currency type, destination, signature reward amount, and reward account for that signature. With the exception of the reward account, all signatures must sign the message created with common parameters.
    /// </summary>
    public class FungibleTokenXChainCreateAccountAttestation : XChainCreateAccountAttestation
    {
        /// <summary>
        /// The amount and currency type committed by the XChainAccountCreateCommit transaction on the source chain.
        /// </summary>
        public new required TokenAmount Amount { get => (TokenAmount)base.Amount; set => base.Amount = value; }
    }
}