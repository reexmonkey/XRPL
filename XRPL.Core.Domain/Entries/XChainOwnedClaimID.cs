﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Specifies one cross-chain transfer of value and includes information of the account on the source chain 
    /// that locks or burns the funds on the source chain.
    /// <para/>The XChainOwnedClaimID object must be acquired on the destination chain before submitting a XChainCommit on the source chain. 
    /// Its purpose is to prevent transaction replay attacks and is also used as a place to collect attestations from witness servers.
    /// <para/>An XChainCreateClaimID transaction is used to create a new XChainOwnedClaimID. 
    /// The ledger object is destroyed when the funds are successfully claimed on the destination chain.
    /// </summary>
    /// <typeparam name="TTokenAmount">The type of amount and token to claim in the XChainCommit transaction.</typeparam>
    public abstract class XChainOwnedClaimIDBase<TTokenAmount> : LedgerEntryBase
        where TTokenAmount : class
    {
        /// <summary>
        /// The account that owns this object.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// The ledger index is a hash of a unique prefix for XChainOwnedClaimIDs, the actual XChainClaimID value, and the fields in XChainBridge.
        /// </summary>
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// The account that must send the corresponding XChainCommit on the source chain. 
        /// <para/>The destination may be specified in the XChainCommit transaction, which means that if the OtherChainSource isn't specified, another account can try to specify a different destination and steal the funds. 
        /// This also allows tracking only a single set of signatures, since we know which account will send the XChainCommit transaction.
        /// </summary>
        public string? OtherChainSource { get; set; }

        /// <summary>
        /// The total amount to pay the witness servers for their signatures. 
        /// <para/>It must be at least the value of SignatureReward in the Bridge ledger object.
        /// </summary>
        public string? SignatureReward { get; set; }

        /// <summary>
        /// The door accounts and assets of the bridge this object correlates to.
        /// </summary>
        public XChainBridge? XChainBridge { get; set; }

        /// <summary>
        /// Attestations collected from the witness servers. This includes the parameters needed to recreate the message that was signed, including the amount, which chain (locking or issuing), optional destination, and reward account for that signature
        /// </summary>
        public XChainClaimAttestation<TTokenAmount>[]? XChainClaimAttestations { get; set; }

        /// <summary>
        /// The unique sequence number for a cross-chain transfer.
        /// </summary>
        public string? XChainClaimID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XChainOwnedClaimIDBase{TTokenAmount}"/> class.
        /// </summary>
        protected XChainOwnedClaimIDBase() 
        {
            LedgerEntryType = "XChainOwnedClaimID";
        }
    }

    /// <summary>
    /// Represents an attestation collected from a witness server.
    /// <para/>This includes the parameters needed to recreate the message that was signed, including the amount, which chain (locking or issuing), optional destination, and reward account for that signature.
    /// </summary>
    /// <typeparam name="TTokenAmount">The type of amount and token to claim in the XChainCommit transaction.</typeparam>
    public class XChainClaimAttestation<TTokenAmount> where TTokenAmount : class
    {
        /// <summary>
        /// An attestation from one witness server.
        /// </summary>
        public XChainClaimAttestation<TTokenAmount>? XChainClaimProofSig { get; set; }

        /// <summary>
        /// The amount to claim in the XChainCommit transaction on the destination chain.
        /// </summary>
        public TTokenAmount? Amount { get; set; }

        /// <summary>
        /// The account that should receive this signer's share of the <see cref="Bridge.SignatureReward"/>.
        /// </summary>
        public string? AttestationRewardAccount { get; set; }

        /// <summary>
        /// The account on the door account's signer list that is signing the transaction.
        /// </summary>
        public string? AttestationSignerAccount { get; set; }

        /// <summary>
        /// The destination account for the funds on the destination chain.
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// The public key used to verify the signature.
        /// </summary>
        public string? PublicKey { get; set; }

        /// <summary>
        /// A boolean representing the chain where the event occurred.
        /// </summary>
        public uint WasLockingChainSend { get; set; }

    }

    /// <summary>
    /// Represents one cross-chain transfer of XRP and includes information of the account on the source chain 
    /// that locks or burns the funds on the source chain.
    /// <para/>The XChainOwnedClaimID object must be acquired on the destination chain before submitting a XChainCommit on the source chain. 
    /// Its purpose is to prevent transaction replay attacks and is also used as a place to collect attestations from witness servers.
    /// <para/>An XChainCreateClaimID transaction is used to create a new XChainOwnedClaimID. 
    /// The ledger object is destroyed when the funds are successfully claimed on the destination chain.
    /// </summary>
    public sealed class XRPXChainOwnedClaimID: XChainOwnedClaimIDBase<string>
    {

    }

    /// <summary>
    /// Represents one cross-chain transfer of a token and includes information of the account on the source chain 
    /// that locks or burns the funds on the source chain.
    /// <para/>The XChainOwnedClaimID object must be acquired on the destination chain before submitting a XChainCommit on the source chain. 
    /// Its purpose is to prevent transaction replay attacks and is also used as a place to collect attestations from witness servers.
    /// <para/>An XChainCreateClaimID transaction is used to create a new XChainOwnedClaimID. 
    /// The ledger object is destroyed when the funds are successfully claimed on the destination chain.
    /// </summary>
    public sealed class TokenXChainOwnedClaimID: XChainOwnedClaimIDBase<TokenAmount>
    {

    }


}