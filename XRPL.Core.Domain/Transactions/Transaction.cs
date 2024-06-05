using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction, which is the only way to cause changes in the XRPL ledeger.
    /// <para/>Transactions' outcomes are only final if signed, submitted, and accepted into a validated ledger version following the consensus process.
    /// <para/>Some ledger rules also generate pseudo-transactions, which aren't signed or submitted, but still must be accepted by consensus. <para/>Transactions that fail are also included in ledgers because they modify balances of XRP to pay for the anti-spam transaction cost.
    /// </summary>
    public abstract class Transaction(TransactionType transactionType)
    {
        /// <summary>
        /// (Required) The unique address of the account that initiated the transaction.
        /// </summary>
        public virtual required string Account { get; set; }

        /// <summary>
        /// (Required) The type of transaction.
        /// </summary>
        public required TransactionType TransactionType { get; set; } = transactionType;

        /// <summary>
        /// (Required; auto-fillable) Integer amount of XRP, in drops,
        /// to be destroyed as a cost for distributing this transaction to the network.
        /// <para/>Some transaction types have different minimum requirements.
        /// </summary>
        public required string Fee { get; set; }

        /// <summary>
        /// (Required; auto-fillable) The sequence number of the account sending the transaction.
        /// <para/>A transaction is only valid if the Sequence number is exactly 1 greater than the previous transaction from the same account. The special case 0 means the transaction is using a Ticket instead (Added by the TicketBatch amendment.).
        /// </summary>
        public required uint Sequence { get; set; }

        /// <summary>
        /// (Optional) Hash value identifying another transaction.
        /// <para/>If provided, this transaction is only valid if the sending account's previously-sent transaction matches the provided hash.
        /// <para/>The AccountTxnID field lets you chain your transactions together, so that a current transaction is not valid unless the previous transaction sent from the same account has a specific transaction hash.
        /// <para/>Unlike the PreviousTxnID field, which tracks the last transaction to modify an account (regardless of sender), the AccountTxnID tracks the last transaction sent by an account. To use AccountTxnID, you must first enable the asfAccountTxnID flag, so that the ledger keeps track of the ID for the account's previous transaction. (PreviousTxnID, by comparison, is always tracked.)
        /// <para/>One situation in which this is useful is if you have a primary system for submitting transactions and a passive backup system. If the passive backup system becomes disconnected from the primary, but the primary is not fully dead, and they both begin operating at the same time, you could potentially have serious problems like some transactions sending twice and others not at all. Chaining your transactions together with AccountTxnID ensures that, even if both systems are active, only one of them can submit valid transactions at a time.
        /// <para/>The AccountTxnID field cannot be used on transactions that use Tickets. 
        /// Transactions that use AccountTxnID cannot be placed in the transaction queue.
        /// </summary>
        public string? AccountTxnID { get; set; }

        /// <summary>
        /// (Optional) Set of bit-flags for this transaction.
        /// </summary>
        public uint? Flags { get; set; }

        /// <summary>
        /// (Optional; strongly recommended) Highest ledger index this transaction can appear in.
        /// <para/>Specifying this field places a strict upper limit on how long the transaction can wait to be validated or rejected.
        /// See Reliable Transaction Submission for more details.
        /// </summary>
        public uint LastLedgerSequence { get; set; }

        /// <summary>
        /// (Optional) Additional arbitrary information used to identify this transaction.
        /// </summary>
        public Memo[]? Memos { get; set; }

        /// <summary>
        /// (Network-specific) The network ID of the chain this transaction is intended for.
        /// <para/>MUST BE OMITTED for Mainnet and some test networks. REQUIRED on chains whose network ID is 1025 or high
        /// </summary>
        public uint NetworkID { get; set; }

        /// <summary>
        /// (Optional) Array of objects that represent a multi-signature which authorizes this transaction.
        /// </summary>
        public Signer[]? Signers { get; set; }

        /// <summary>
        /// (Optional) Arbitrary integer used to identify the reason for this payment, or a sender on whose behalf this transaction is made.
        /// <para/>Conventionally, a refund should specify the initial payment's SourceTag as the refund payment's DestinationTag.
        /// </summary>
        public uint? SourceTag { get; set; }

        /// <summary>
        /// (Automatically added when signing) Hex representation of the public key that corresponds to the private key used to sign this transaction.
        /// <para/>If an empty string, indicates a multi-signature is present in the Signers field instead.
        /// </summary>
        public string? SigningPubKey { get; set; }

        /// <summary>
        /// (Optional) The sequence number of the ticket to use in place of a Sequence number.
        /// <para/>If this is provided, Sequence must be 0. Cannot be used with AccountTxnID.
        /// </summary>
        public uint? TicketSequence { get; set; }

        /// <summary>
        /// (Automatically added when signing) The signature that verifies this transaction as originating from the account it says it is from.
        /// </summary>
        public string? TxnSignature { get; set; }
    }

    /// <summary>
    /// Represents a signer that should authorize a transaction.
    /// </summary>
    public class Signer
    {
        /// <summary>
        /// The address associated with this signature, as it appears in the signer list.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// A signature for this transaction, verifiable using the SigningPubKey.
        /// </summary>
        public string? TxnSignature { get; set; }

        /// <summary>
        /// The public key used to create this signature.The key must be associated with the <see cref="Account"/> address
        /// </summary>
        public string? SigningPubKey { get; set; }
    }

    /// <summary>
    /// Represents an arbitrary messaging data within a transaction.
    /// </summary>
    public class Memo
    {
        /// <summary>
        /// Arbitrary hex value, conventionally containing the content of the memo.
        /// </summary>
        public required string MemoData { get; set; }

        /// <summary>
        /// Hex value representing characters allowed in URLs.
        /// <para/>Conventionally containing information on how the memo is encoded, for example as a MIME type.
        /// </summary>
        public required string MemoFormat { get; set; }

        /// <summary>
        /// Hex value representing characters allowed in URLs.
        /// <para/>Conventionally, a unique relation (according to RFC 5988) that defines the format of this memo.
        /// </summary>
        public required string MemoType { get; set; }
    }

    /// <summary>
    /// Represents a known Network ID (status and value)
    /// </summary>
    public enum KnownNetworkID
    {
        /// <summary>
        /// Network ID of Mainnet. Field disallowed.
        /// </summary>
        Mainnet = 0,

        /// <summary>
        /// Network ID of Testnet. Field disallowed.
        /// </summary>
        Testnet = 1,

        /// <summary>
        /// Network ID of Devnet. Field disallowed.
        /// </summary>
        Devnet = 2,

        /// <summary>
        /// Network ID of AMM Devnet. Field disallowed.
        /// </summary>
        AMMDevnet = 25,

        /// <summary>
        /// Network ID of Sidechains Devnet Locking Chain. Field disallowed, but will become required after an update.
        /// </summary>
        SidechainsDevnetLockingChain = 2551,

        /// <summary>
        /// Network ID of Sidechains Devnet Issuing Chain. Field disallowed, but will become required after an update.
        /// </summary>
        SidechainsDevnetIssuingChain = 2552,

        /// <summary>
        /// Network ID of Hooks V3 Testnet. Required.
        /// </summary>
        HooksV3Testnet = 21338
    }

    /// <summary>
    /// Represents the type of operation a transaction is supposed to do.
    /// </summary>
    public enum TransactionType : uint
    {
        /// <summary>
        /// An AccountSet transaction modifies the properties of an account in the XRP Ledger.
        /// </summary>
        AccountSet,

        /// <summary>
        /// An AccountDelete transaction deletes an account and any objects it owns in the XRP Ledger.
        /// </summary>
        AccountDelete,

        /// <summary>
        /// Bid on an Automated Market Maker's (AMM's) auction slot. 
        /// <para/>If you win, you can trade against the AMM at a discounted fee until you are outbid or 24 hours have passed. 
        /// If you are outbid before 24 hours have passed, you are refunded part of the cost of your bid based on how much time remains.
        /// </summary>
        AMMBid,

        /// <summary>
        /// Create a new Automated Market Maker (AMM) instance for trading a pair of assets (fungible tokens or XRP).
        /// Creates both an AMM entry and a special <see cref="AccountRoot"/> entry to represent the AMM. Also transfers ownership of the starting balance of both assets from the sender to the created <see cref="AccountRoot"/> and issues an initial balance of liquidity provider tokens (LP Tokens) from the AMM account to the sender.
        /// </summary>
        AMMCreate,

        /// <summary>
        /// Delete an empty Automated Market Maker (AMM) instance that could not be fully deleted automatically.
        /// <para/>Normally, an AMMWithdraw transaction automatically deletes an AMM and all associated ledger entries when it withdraws all the assets from the AMM's pool. 
        /// <para/>However, if there are too many trust lines to the AMM account to remove in one transaction, it may stop before fully removing the AMM.
        /// Similarly, an AMMDelete transaction removes up to a maximum of 512 trust lines; it may take several AMMDelete transactions to delete all the trust lines and the associated AMM. In all cases, only the last such transaction deletes the AMM and AccountRoot ledger entries.
        /// </summary>
        AMMDelete,

        /// <summary>
        /// Deposit funds into an Automated Market Maker (AMM) instance and receive the AMM's liquidity provider tokens (LP Tokens) in exchange. You can deposit one or both of the assets in the AMM's pool.
        /// <para/>If successful, this transaction creates a trust line to the AMM Account (limit 0) to hold the LP Tokens.
        /// </summary>
        AMMDeposit,

        /// <summary>
        /// Vote on the trading fee for an Automated Market Maker instance. 
        /// <para/>Up to 8 accounts can vote in proportion to the amount of the AMM's LP Tokens they hold. Each new vote re-calculates the AMM's trading fee based on a weighted average of the votes.
        /// </summary>
        AMMVote,

        /// <summary>
        /// Withdraw assets from an Automated Market Maker (AMM) instance by returning the AMM's liquidity provider tokens (LP Tokens).
        /// </summary>
        AMMWithdraw,

        /// <summary>
        /// Cancels an unredeemed Check, removing it from the ledger without sending any money. 
        /// <para/>The source or the destination of the check can cancel a Check at any time using this transaction type. If the Check has expired, any address can cancel it.
        /// </summary>
        CheckCancel,

        /// <summary>
        /// Attempts to redeem a <see cref="Check"/> object in the ledger to receive up to the amount authorized by the corresponding CheckCreate transaction. 
        /// <para/>Only the Destination address of a <see cref="Check"/> can cash it with a CheckCash transaction. Cashing a check this way is similar to executing a Payment initiated by the destination.
        /// </summary>
        CheckCash,

        /// <summary>
        /// Create a Check object in the ledger, which is a deferred payment that can be cashed by its intended destination. 
        /// <para/>The sender of this transaction is the sender of the Check.
        /// </summary>
        CheckCreate,

        /// <summary>
        /// Claw back tokens issued by your account.
        /// </summary>
        Clawback,

        /// <summary>
        /// A DepositPreauth transaction gives another account pre-approval to deliver payments to the sender of this transaction. 
        /// <para/>This is only useful if the sender of this transaction is using (or plans to use) Deposit Authorization.
        /// </summary>
        DepositPreauth,

        /// <summary>
        /// Delete the DID ledger entry associated with the specified Account field.
        /// </summary>
        DIDDelete,

        /// <summary>
        /// Creates a new DID ledger entry or updates the fields of an existing one.
        /// </summary>
        DIDSet,

        /// <summary>
        /// Return escrowed XRP to the sender.
        /// </summary>
        EscrowCancel,

        /// <summary>
        /// Sequester XRP until the escrow process either finishes or is canceled.
        /// </summary>
        EscrowCreate,

        /// <summary>
        /// Deliver XRP from a held payment to the recipient.
        /// </summary>
        EscrowFinish,

        /// <summary>
        /// The NFTokenAcceptOffer transaction is used to accept offers to buy or sell an NFToken. 
        /// <para/>It can either:
        /// <para/>- Allow one offer to be accepted. This is called direct mode. 
        /// <para/>- Allow two distinct offers, one offering to buy a given NFToken and the other offering to sell the same NFToken, to be accepted in an atomic fashion. This is called brokered mode.
        /// </summary>
        NFTokenAcceptOffer,

        /// <summary>
        /// The NFTokenBurn transaction is used to remove a NFToken object from the NFTokenPage in which it is being held, effectively removing the token from the ledger (burning it).
        /// </summary>
        NFTokenBurn,

        /// <summary>
        /// The NFTokenCancelOffer transaction can be used to cancel existing token offers created using NFTokenCreateOffer.
        /// </summary>
        NFTokenCancelOffer,

        /// <summary>
        /// Creates either a new Sell offer for an NFToken owned by the account executing the transaction, or a new Buy offer for an NFToken owned by another account.
        /// </summary>
        NFTokenCreateOffer,

        /// <summary>
        /// The NFTokenMint transaction creates a non-fungible token and adds it to the relevant NFTokenPage object of the NFTokenMinter as an NFToken object. This transaction is the only opportunity the NFTokenMinter has to specify any token fields that are defined as immutable (for example, the TokenFlags).
        /// </summary>
        NFTokenMint,

        /// <summary>
        /// An OfferCancel transaction removes an Offer object from the XRP Ledger.
        /// </summary>
        OfferCancel,

        /// <summary>
        /// An OfferCreate transaction places an Offer in the decentralized exchange.
        /// </summary>
        OfferCreate,

        /// <summary>
        /// A Payment transaction represents a transfer of value from one account to another. (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.) This transaction type can be used for several types of payments.
        /// </summary>
        Payment,

        /// <summary>
        /// Claim XRP from a payment channel, adjust the payment channel's expiration, or both. 
        /// <para/> This transaction can be used differently depending on the transaction sender's role in the specified channel.
        /// </summary>
        PaymentChannelClaim,

        /// <summary>
        /// Create a payment channel and fund it with XRP. 
        /// <para/>The address sending this transaction becomes the "source address" of the payment channel.
        /// </summary>
        PaymentChannelCreate,

        /// <summary>
        /// Add additional XRP to an open payment channel, and optionally update the expiration time of the channel. 
        /// <para/>Only the source address of the channel can use this transaction.
        /// </summary>
        PaymentChannelFund,

        /// <summary>
        /// A SetRegularKey transaction assigns, changes, or removes the regular key pair associated with an account.
        /// </summary>
        SetRegularKey,

        /// <summary>
        /// The SignerListSet transaction creates, replaces, or removes a list of signers that can be used to multi-sign a transaction. 
        /// <para/>This transaction type was introduced by the MultiSign amendment.
        /// </summary>
        SignerListSet,

        /// <summary>
        /// A TicketCreate transaction sets aside one or more sequence numbers as Tickets.
        /// </summary>
        TicketCreate,

        /// <summary>
        /// Create or modify a trust line linking two accounts.
        /// </summary>
        TrustSet,

        /// <summary>
        /// This transaction can only be used for XRP-XRP bridges.
        /// <para/>The XChainAccountCreateCommit transaction creates a new account for a witness server to submit transactions on an issuing chain.
        /// </summary>
        XChainAccountCreateCommit,

        /// <summary>
        /// The XChainAddAccountCreateAttestation transaction provides an attestation from a witness server that an XChainAccountCreateCommit transaction occurred on the other chain.
        /// </summary>
        XChainAddAccountCreateAttestation,

        /// <summary>
        /// The XChainAddClaimAttestation transaction provides proof from a witness server, attesting to an XChainCommit transaction.
        /// </summary>
        XChainAddClaimAttestation,

        /// <summary>
        ///The XChainClaim transaction completes a cross-chain transfer of value. 
        ///<para/>It allows a user to claim the value on the destination chain - the equivalent of the value locked on the source chain. A user can only claim the value if they own the cross-chain claim ID associated with the value locked on the source chain (the Account field). The user can send the funds to anyone (the Destination field). This transaction is only needed if an OtherChainDestination isn't specified in the XChainCommit transaction, or if something goes wrong with the automatic transfer of funds.
        /// </summary>
        XChainClaim,

        /// <summary>
        /// The XChainCommit is the second step in a cross-chain transfer. It puts assets into trust on the locking chain so that they can be wrapped on the issuing chain, or burns wrapped assets on the issuing chain so that they can be returned on the locking chain.
        /// </summary>
        XChainCommit,

        /// <summary>
        /// The XChainCreateBridge transaction creates a new Bridge ledger object and defines a new cross-chain bridge entrance on the chain that the transaction is submitted on. It includes information about door accounts and assets for the bridge.
        /// </summary>
        XChainCreateBridge,

        /// <summary>
        /// The XChainCreateClaimID transaction creates a new cross-chain claim ID that is used for a cross-chain transfer. A cross-chain claim ID represents one cross-chain transfer of value.
        /// </summary>
        XChainCreateClaimID,

        /// <summary>
        /// The XChainModifyBridge transaction allows bridge managers to modify the parameters of the bridge. They can only change the SignatureReward and the MinAccountCreateAmount.
        /// </summary>
        XChainModifyBridge
    }
}