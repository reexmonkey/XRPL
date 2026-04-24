using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents the section of data that gets added to a transaction after it is processed.
    /// <para/>Any transaction that gets included in a ledger has metadata, regardless of whether it is successful.
    /// The transaction metadata describes the outcome of the transaction in detail.
    /// <para/> The changes described in transaction metadata are only final if the transaction is in a validated ledger version.
    /// </summary>
    public class TransactionMetadata
    {
        /// <summary>
        /// List of ledger entries that were created, deleted, or modified by this transaction, and specific changes to each.
        /// </summary>
        public required AffectedNode[] AffectedNodes { get; set; }

        /// <summary>
        /// For a partial payment, this field records the amount of currency actually delivered to the destination.
        /// <para/>To avoid errors when reading transactions, instead use the <see cref="PaymentDeliveredAmount"/> field, which is provided for all Payment transactions, partial or not.
        /// </summary>
        [JsonPropertyName("DeliveredAmount")]
        public CurrencyAmount[]? DeliveredAmount { get; set; }

        /// <summary>
        /// The transaction's position within the ledger that included it.
        /// This is zero-indexed. (For example, the value 2 means it was the 3rd transaction in that ledger.)
        /// </summary>
        public uint TransactionIndex { get; set; }

        /// <summary>
        /// A result code indicating whether the transaction succeeded or how it failed.
        /// </summary>
        public required string TransactionResult { get; set; }

        /// <summary>
        /// The amount of currency actually received by the Destination account.
        /// <para/>Use this field to determine how much was delivered, regardless of whether the transaction is a partial payment
        /// </summary>
        [JsonPropertyName("delivered_amount")]
        public CurrencyAmount? PaymentDeliveredAmount { get; set; }

    }

    /// <summary>
    /// Specifies a node that indicates whether a ledger entry that was created, modified, or deleted by a transaction, and the specific changes to that ledger entry.
    /// </summary>
    public abstract class AffectedNode;

    /// <summary>
    /// Represents a node that indicates that the transaction created a new ledger entry.
    /// </summary>
    public sealed class CreatedNode : AffectedNode
    {
        /// <summary>
        /// The type of ledger entry that was created.
        /// </summary>
        public required string LedgerEntryType { get; set; }

        /// <summary>
        /// The ID of this ledger entry in the ledger's state tree. Note: This is not the same as a ledger index, even though the field name is very similar.
        /// </summary>
        public required string LedgerIndex { get; set; }

        /// <summary>
        /// The content fields of the newly created ledger entry. Which fields are present depends on what type of ledger entry was created.
        /// </summary>
        public required LedgerEntryMeta NewFields { get; set; }
    }

    /// <summary>
    /// Represents a node that indicates that the transaction modified an existing ledger entry.
    /// </summary>
    public sealed class ModifiedNode : AffectedNode
    {
        /// <summary>
        /// The type of ledger entry that was modified.
        /// </summary>
        public required string LedgerEntryType { get; set; }

        /// <summary>
        /// The ID of this ledger entry in the ledger's state tree. Note: This is not the same as a ledger index, even though the field name is very similar.
        /// </summary>
        public required string LedgerIndex { get; set; }

        /// <summary>
        /// The content fields of the ledger entry after applying any changes from this transaction. Which fields are present depends on what type of ledger entry was created.
        /// This omits the PreviousTxnID and PreviousTxnLgrSeq fields, even though most types of ledger entries have them.
        /// </summary>
        public required LedgerEntryMeta FinalFields { get; set; }

        /// <summary>
        /// The previous values for all fields of the object that were changed as a result of this transaction.
        /// If the transaction only added fields to the object, this field is an empty object.
        /// </summary>
        public required LedgerEntryMeta PreviousFields { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// <para/>Omitted for ledger entry types that do not have a PreviousTxnID field
        /// </summary>
        public string? PreviousTxnID { get; set; }

        /// <summary>
        /// The Ledger Index of the ledger version containing the previous transaction to modify this ledger entry.
        /// <para/> Omitted for ledger entry types that do not have a PreviousTxnLgrSeq field
        /// </summary>
        public uint? PreviousTxnLgrSeq { get; set; }
    }

    /// <summary>
    /// Represents a node that indicates that the transaction removed a ledger entry.
    /// </summary>
    public sealed class DeletedNode : AffectedNode
    {
        /// <summary>
        /// The type of ledger entry that was deleted.
        /// </summary>
        public required string LedgerEntryType { get; set; }

        /// <summary>
        /// The ID of this ledger entry in the ledger's state tree. Note: This is not the same as a ledger index, even though the field name is very similar.
        /// </summary>
        public required string LedgerIndex { get; set; }

        /// <summary>
        /// The content fields of the ledger entry immediately before it was deleted. Which fields are present depends on what type of ledger entry was created.
        /// </summary>
        public required LedgerEntryMeta FinalFields { get; set; }

        /// <summary>
        /// (May be omitted) Selected fields of the ledger entry before it was deleted. Which fields are present depends on what type of ledger entry was created.
        /// </summary>
        public LedgerEntryMeta? PreviousFields { get; set; }
    }

    [JsonSerializable(typeof(TransactionMetadata))]
    [JsonSerializable(typeof(CreatedNode))]
    [JsonSerializable(typeof(ModifiedNode))]
    [JsonSerializable(typeof(DeletedNode))]
    public partial class TransactionMetadataContext : JsonSerializerContext;

    [JsonSerializable(typeof(CreatedNode))]
    [JsonSerializable(typeof(AccountRootMeta))]
    [JsonSerializable(typeof(AMMMeta))]
    [JsonSerializable(typeof(AmmendmentsMeta))]
    [JsonSerializable(typeof(CheckMeta))]
    [JsonSerializable(typeof(CredentialMeta))]
    [JsonSerializable(typeof(DepositPreauthMeta))]
    [JsonSerializable(typeof(DIDMeta))]
    [JsonSerializable(typeof(DirectoryNodeMeta))]
    [JsonSerializable(typeof(EscrowMeta))]
    [JsonSerializable(typeof(FeeSettingsMeta))]
    [JsonSerializable(typeof(LedgerHashesMeta))]
    [JsonSerializable(typeof(MPTokenMeta))]
    [JsonSerializable(typeof(MPTokenIssuanceMeta))]
    [JsonSerializable(typeof(NegativeUNLMeta))]
    [JsonSerializable(typeof(NFTokenOfferMeta))]
    [JsonSerializable(typeof(NFTokenPageMeta))]
    [JsonSerializable(typeof(OfferMeta))]
    [JsonSerializable(typeof(OracleMeta))]
    [JsonSerializable(typeof(PayChannelMeta))]
    [JsonSerializable(typeof(PermissionedDomainMeta))]
    [JsonSerializable(typeof(RippleStateMeta))]
    [JsonSerializable(typeof(SignerListMeta))]
    [JsonSerializable(typeof(TicketMeta))]
    public partial class CreatedNodeContext : JsonSerializerContext;

    [JsonSerializable(typeof(ModifiedNode))]
    [JsonSerializable(typeof(AccountRootMeta))]
    [JsonSerializable(typeof(AMMMeta))]
    [JsonSerializable(typeof(AmmendmentsMeta))]
    [JsonSerializable(typeof(CheckMeta))]
    [JsonSerializable(typeof(CredentialMeta))]
    [JsonSerializable(typeof(DepositPreauthMeta))]
    [JsonSerializable(typeof(DIDMeta))]
    [JsonSerializable(typeof(DirectoryNodeMeta))]
    [JsonSerializable(typeof(EscrowMeta))]
    [JsonSerializable(typeof(FeeSettingsMeta))]
    [JsonSerializable(typeof(LedgerHashesMeta))]
    [JsonSerializable(typeof(MPTokenMeta))]
    [JsonSerializable(typeof(MPTokenIssuanceMeta))]
    [JsonSerializable(typeof(NegativeUNLMeta))]
    [JsonSerializable(typeof(NFTokenOfferMeta))]
    [JsonSerializable(typeof(NFTokenPageMeta))]
    [JsonSerializable(typeof(OfferMeta))]
    [JsonSerializable(typeof(OracleMeta))]
    [JsonSerializable(typeof(PayChannelMeta))]
    [JsonSerializable(typeof(PermissionedDomainMeta))]
    [JsonSerializable(typeof(RippleStateMeta))]
    [JsonSerializable(typeof(SignerListMeta))]
    [JsonSerializable(typeof(TicketMeta))]
    public partial class ModifiedNodeContext : JsonSerializerContext;

    [JsonSerializable(typeof(DeletedNode))]
    [JsonSerializable(typeof(AccountRootMeta))]
    [JsonSerializable(typeof(AMMMeta))]
    [JsonSerializable(typeof(AmmendmentsMeta))]
    [JsonSerializable(typeof(CheckMeta))]
    [JsonSerializable(typeof(CredentialMeta))]
    [JsonSerializable(typeof(DepositPreauthMeta))]
    [JsonSerializable(typeof(DIDMeta))]
    [JsonSerializable(typeof(DirectoryNodeMeta))]
    [JsonSerializable(typeof(EscrowMeta))]
    [JsonSerializable(typeof(FeeSettingsMeta))]
    [JsonSerializable(typeof(LedgerHashesMeta))]
    [JsonSerializable(typeof(MPTokenMeta))]
    [JsonSerializable(typeof(MPTokenIssuanceMeta))]
    [JsonSerializable(typeof(NegativeUNLMeta))]
    [JsonSerializable(typeof(NFTokenOfferMeta))]
    [JsonSerializable(typeof(NFTokenPageMeta))]
    [JsonSerializable(typeof(OfferMeta))]
    [JsonSerializable(typeof(OracleMeta))]
    [JsonSerializable(typeof(PayChannelMeta))]
    [JsonSerializable(typeof(PermissionedDomainMeta))]
    [JsonSerializable(typeof(RippleStateMeta))]
    [JsonSerializable(typeof(SignerListMeta))]
    [JsonSerializable(typeof(TicketMeta))]
    public partial class DeletedNodeContext : JsonSerializerContext;
}
