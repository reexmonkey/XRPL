using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Specifies a ledger entry that is used to collect attestations for creating an account via a cross-chain transfer.
    /// <para/> It is created when an XChainAddAccountCreateAttestation transaction adds a signature attesting to a XChainAccountCreateCommit transaction and the XChainAccountCreateCount is greater than or equal to the current XChainAccountClaimCount on the Bridge ledger object.
    /// <para/>The ledger object is destroyed when all the attestations have been received and the funds have transferred to the new account.
    /// </summary>
    public abstract class XChainOwnedCreateAccountClaimIDBase : LedgerEntryBase
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
        public required uint XChainAccountCreateCount { get; set; }

        /// <summary>
        /// The door accounts and assets of the bridge this object correlates to.
        /// </summary>
        public required XChainBridge XChainBridge { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XChainOwnedCreateAccountClaimIDBase"/> class.
        /// </summary>
        protected XChainOwnedCreateAccountClaimIDBase()
        {
            LedgerEntryType = "XChainOwnedCreateAccountClaimID";
        }
    }

    /// <summary>
    /// Specifies a ledger entry that is used to collect attestations for creating an account via a cross-chain transfer.
    /// <para/> It is created when an XChainAddAccountCreateAttestation transaction adds a signature attesting to a XChainAccountCreateCommit transaction and the XChainAccountCreateCount is greater than or equal to the current XChainAccountClaimCount on the Bridge ledger object.
    /// <para/>The ledger object is destroyed when all the attestations have been received and the funds have transferred to the new account.
    /// </summary>
    /// <typeparam name="TAmount">The type of amount and token to claim in the transaction.</typeparam>
    public abstract class XChainOwnedCreateAccountClaimIDBase<TAmount> : XChainOwnedCreateAccountClaimIDBase
        where TAmount : class
    {
        /// <summary>
        /// Attestations collected from the witness servers.
        /// This includes the parameters needed to recreate the message that was signed, including the amount, destination, signature reward amount, and reward account for that signature.
        /// With the exception of the reward account, all signatures must sign the message created with common parameters.
        /// </summary>
        public required XChainCreateAccountAttestation<TAmount>[] XChainCreateAccountAttestations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XChainOwnedCreateAccountClaimIDBase{TAmount}"/> class.
        /// </summary>
        protected XChainOwnedCreateAccountClaimIDBase()
        {
            LedgerEntryType = "XChainOwnedCreateAccountClaimID";
        }
    }

    /// <summary>
    /// Represents an attestation collected from a witness server.
    /// <para/>This includes the parameters needed to recreate the message that was signed, including the amount, destination, signature reward amount, and reward account for that signature. With the exception of the reward account, all signatures must sign the message created with common parameters.
    /// </summary>
    /// <typeparam name="TAmount"></typeparam>
    public class XChainCreateAccountAttestation<TAmount>
        where TAmount : class
    {
        /// <summary>
        /// An attestation from one witness server.
        /// </summary>
        public required XChainCreateAccountAttestation<TAmount> XChainCreateAccountProofSig { get; set; }

        /// <summary>
        /// The amount committed by the XChainAccountCreateCommit transaction on the source chain.
        /// </summary>
        public required TAmount Amount { get; set; }

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
    /// Represents a ledger entry that is used to collect attestations for creating an account via a cross-chain XRP transfer.
    /// <para/> It is created when an XChainAddAccountCreateAttestation transaction adds a signature attesting to a XChainAccountCreateCommit transaction and the XChainAccountCreateCount is greater than or equal to the current XChainAccountClaimCount on the Bridge ledger object.
    /// <para/>The ledger object is destroyed when all the attestations have been received and the funds have transferred to the new account.
    /// </summary>
    public sealed class XrpXChainOwnedCreateAccountClaimID : XChainOwnedCreateAccountClaimIDBase<string>
    {
    }

    /// <summary>
    /// Represents a ledger entry that is used to collect attestations for creating an account via a cross-chain token transfer.
    /// <para/> It is created when an XChainAddAccountCreateAttestation transaction adds a signature attesting to a XChainAccountCreateCommit transaction and the XChainAccountCreateCount is greater than or equal to the current XChainAccountClaimCount on the Bridge ledger object.
    /// <para/>The ledger object is destroyed when all the attestations have been received and the funds have transferred to the new account.
    /// </summary>
    public sealed class FungibleTokenXChainOwnedCreateAccountClaimID : XChainOwnedCreateAccountClaimIDBase<TokenAmount>
    {
    }
}