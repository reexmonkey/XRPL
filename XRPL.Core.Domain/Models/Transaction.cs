using System.Runtime.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a transaction, which is the only way to cause changes in the XRPL ledeger.
    /// <para/>Transactions' outcomes are only final if signed, submitted, and accepted into a validated ledger version following the consensus process.
    /// <para/>Some ledger rules also generate pseudo-transactions, which aren't signed or submitted, but still must be accepted by consensus. <para/>Transactions that fail are also included in ledgers because they modify balances of XRP to pay for the anti-spam transaction cost.
    /// </summary>
    [KnownType(typeof(AccountRoot))]
    [KnownType(typeof(AMM))]
    [KnownType(typeof(Ammendments))]
    [KnownType(typeof(Bridge))]
    [KnownType(typeof(CurrencyAmountCheck))]
    [KnownType(typeof(XRPCheck))]
    [KnownType(typeof(DepositPreauth))]
    [KnownType(typeof(DID))]
    [KnownType(typeof(DirectoryNode))]
    [KnownType(typeof(Escrow))]
    [KnownType(typeof(FeeSettings))]
    [KnownType(typeof(LedgerHashes))]
    [KnownType(typeof(NegativeUNL))]
    [KnownType(typeof(XrpForNFTokenOffer))]
    [KnownType(typeof(CurrencyAmountForNFTokenOffer))]
    [KnownType(typeof(NFTokenPage))]
    [KnownType(typeof(XrpForCurrencyAmountOffer))]
    [KnownType(typeof(CurrencyAmountForXrpOffer))]
    [KnownType(typeof(CurrencyAmountForCurrencyAmountOffer))]
    [KnownType(typeof(PayChannel))]
    [KnownType(typeof(RippleState))]
    [KnownType(typeof(SignerList))]
    [KnownType(typeof(Ticket))]
    [KnownType(typeof(XRPXChainOwnedClaimID))]
    [KnownType(typeof(CurrencyAmountXChainOwnedClaimID))]
    [KnownType(typeof(XrpXChainOwnedCreateAccountClaimID))]
    [KnownType(typeof(CurrencyAmountXChainOwnedCreateAccountClaimID))]
    public class Transaction
    {
        /// <summary>
        /// (Required) The unique address of the account that initiated the transaction.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// (Required) The type of transaction.
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// (Required; auto-fillable) Integer amount of XRP, in drops,
        /// to be destroyed as a cost for distributing this transaction to the network.
        /// <para/>Some transaction types have different minimum requirements.
        /// </summary>
        public string? Fee { get; set; }

        /// <summary>
        /// (Required; auto-fillable) The sequence number of the account sending the transaction.
        /// <para/>A transaction is only valid if the Sequence number is exactly 1 greater than the previous transaction from the same account. The special case 0 means the transaction is using a Ticket instead (Added by the TicketBatch amendment.).
        /// </summary>
        public uint Sequence { get; set; }

        /// <summary>
        /// (Optional) Hash value identifying another transaction.
        /// <para/>If provided, this transaction is only valid if the sending account's previously-sent transaction matches the provided hash.
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

        /// <summary>
        /// List of ledger entries that were created, deleted, or modified by this transaction, and specific changes to each.
        /// </summary>
        public LedgerEntryBase[]? AffectedNodes { get; set; }

        /// <summary>
        /// (May be omitted) For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the delivered_amount field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        [DataMember(Name = "DeliveredAmount")]
        public CurrencyAmount[]? PartialPaymentDeliveredAmount { get; set; }

        /// <summary>
        /// The transaction's position within the ledger that included it. This is zero-indexed. (For example, the value 2 means it was the 3rd transaction in that ledger.)
        /// </summary>
        public uint TransactionIndex { get; set; }

        /// <summary>
        /// A result code indicating whether the transaction succeeded or how it failed.
        /// </summary>
        public string? TransactionResult { get; set; }

        /// <summary>
        /// (Omitted for non-Payment transactions) The [Currency Amount][] actually received by the Destination account. Use this field to determine how much was delivered, regardless of whether the transaction is a partial payment. See this description for details.
        /// </summary>
        [DataMember(Name = "delivered_amount")]
        public CurrencyAmount? DeliveredAmount { get; set; }
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
        public string? MemoData { get; set; }

        /// <summary>
        /// Hex value representing characters allowed in URLs.
        /// <para/>Conventionally containing information on how the memo is encoded, for example as a MIME type.
        /// </summary>
        public string? MemoFormat { get; set; }

        /// <summary>
        /// Hex value representing characters allowed in URLs.
        /// <para/>Conventionally, a unique relation (according to RFC 5988) that defines the format of this memo.
        /// </summary>
        public string? MemoType { get; set; }
    }

    /// <summary>
    /// Represents the most fundamental information about a transaction.
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

        AMMBid,
        AMMCreate,
        AMMDelete,
        AMMDeposit,
        AMMVote,
        AMMWithdraw,
        CheckCancel,
        CheckCash,
        CheckCreate,
        Clawback,
        DepositPreauth,
        DIDDelete,
        DIDSet,
        EscrowCancel,
        EscrowCreate,
        EscrowFinish,
        NFTokenAcceptOffer,
        NFTokenBurn,
        NFTokenCancelOffer,
        NFTokenCreateOffer,
        NFTokenMint,
        OfferCancel,
        OfferCreate,
        Payment,
        PaymentChannelClaim,
        PaymentChannelCreate,
        PaymentChannelFund,
        SetRegularKey,
        SignerListSet,
        TicketCreate,
        TrustSet,
        XChainAccountCreateCommit,
        XChainAddAccountCreateAttestation,
        XChainAddClaimAttestation,
        XChainClaim,
        XChainCommit,
        XChainCreateBridge,
        XChainCreateClaimID,
        XChainModifyBridge
    }
}