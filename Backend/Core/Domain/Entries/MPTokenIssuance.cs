using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// An MPTokenIssuance entry represents a single <see cref="MPT"/> issuance and holds data associated with the issuance itself.
    /// </summary>
    public class MPTokenIssuance : LedgerEntry
    {
        private MPTokenIssuanceFlags flags;

        /// <summary>
        /// The address of the account that controls both the issuance amounts and characteristics of a particular fungible token.
        /// </summary>
        public required string Issuer { get; set; }

        /// <summary>
        /// Where to put the decimal place when displaying amounts of this MPT.
        /// More formally, the asset scale is a non-negative integer (0, 1, 2, …) such that one standard unit equals 10^(-scale) of a corresponding fractional unit.
        /// For example, if a US Dollar Stablecoin has an asset scale of 2, then 1 unit of that MPT would equal 0.01 US Dollars.
        /// This indicates to how many decimal places the MPT can be subdivided.
        /// The default is 0, meaning that the MPT cannot be divided into smaller than 1 unit.
        /// </summary>
        public required ushort AssetScale { get; set; }

        /// <summary>
        /// The maximum number of MPTs that can exist at one time.
        /// If omitted, the maximum is currently limited to 2^63-1.
        /// </summary>
        public string? MaximumAmount { get; set; }

        /// <summary>
        /// The total amount of MPTs of this issuance currently in circulation.
        /// This value increases when the issuer sends MPTs to a non-issuer, and decreases whenever the issuer receives MPTs.
        /// </summary>
        public required string OutstandingAmount { get; set; }

        /// <summary>
        /// The amount of tokens currently locked up (for example, in escrow).
        /// This amount is already included in the OutstandingAmount.
        /// </summary>
        public string? LockedAmount { get; set; }

        /// <summary>
        /// This value specifies the fee, in tenths of a basis point, charged by the issuer for secondary sales of the token, if such sales are allowed at all.
        /// Valid values for this field are between 0 and 50,000 inclusive.
        /// A value of 1 is equivalent to 1/10 of a basis point or 0.001%, allowing transfer rates between 0% and 50%.
        /// A TransferFee of 50,000 corresponds to 50%. The default value for this field is 0.
        /// Any decimals in the transfer fee are rounded down. The fee can be rounded down to zero if the payment is small.
        /// Issuers should make sure that their MPT's AssetScale is large enough.
        /// </summary>
        public required ushort TransferFee { get; set; }

        /// <summary>
        /// Arbitrary metadata about this issuance, in hex format.
        /// The limit for this field is 1024 bytes.
        /// </summary>
        public required string MPTokenMetadata { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The Sequence (or Ticket) number of the transaction that created this issuance.
        /// This helps to uniquely identify the issuance and distinguish it from any other later MPT issuances created by this account.
        /// </summary>
        public required uint Sequence { get; set; }

        /// <summary>
        /// Set of bit-flags for this ledger entry.
        /// </summary>
        public override required uint Flags { get => (uint)flags; set => flags = (MPTokenIssuanceFlags)value; }

        /// <summary>
        /// Initializes a new instance of the MPTokenIssuance class.
        /// </summary>
        public MPTokenIssuance() => LedgerEntryType = nameof(MPTokenIssuance);
    }

    /// <summary>
    /// Defines the flags that control the issuance and management of tokens in the XRP Ledger.
    /// </summary>
    /// <remarks>These flags allow issuers to specify various conditions and permissions related to token
    /// balances, including locking, authorization, escrow, trading, transferability, and clawback
    /// capabilities.</remarks>
    public enum MPTokenIssuanceFlags : uint
    {
        /// <summary>
        /// If set, indicates that all balances are locked.
        /// </summary>
        lsfMPTLocked = 0x00000001,

        /// <summary>
        /// If set, indicates that the issuer can lock an individual balance or all balances of this MPT. If not set, the MPT cannot be locked in any way.
        /// </summary>
        lsfMPTCanLock = 0x00000002,

        /// <summary>
        /// If set, indicates that individual holders must be authorized. This enables issuers to limit who can hold their assets.
        /// </summary>
        lsfMPTRequireAuth = 0x00000004,

        /// <summary>
        /// If set, indicates that individual holders can place their balances into an escrow
        /// </summary>
        lsfMPTCanEscrow = 0x00000008,

        /// <summary>
        /// If set, indicates that individual holders can trade their balances using the XRP Ledger DEX or AMM.
        /// </summary>
        lsfMPTCanTrade = 0x00000010,

        /// <summary>
        /// If set, indicates that tokens held by non-issuers can be transferred to other accounts.
        /// If not set, indicates that tokens held by non-issuers cannot be transferred except back to the
        /// issuer; this enables use cases such as store credit.
        /// </summary>
        lsfMPTCanTransfer = 0x00000020,

        /// <summary>
        /// If set, indicates that the issuer may use the Clawback transaction to claw back value from individual holders.
        /// </summary>
        lsfMPTCanClawback = 0x00000040
    }

    /// <summary>
    /// Represents metadata associated with an <see cref="MPTokenIssuance"/> ledger entry.
    /// </summary>
    public class MPTokenIssuanceMeta : LedgerEntryMeta
    {
        /// <summary>
        /// The address of the account that controls both the issuance amounts and characteristics of a particular fungible token.
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// Where to put the decimal place when displaying amounts of this MPT.
        /// More formally, the asset scale is a non-negative integer (0, 1, 2, …) such that one standard unit equals 10^(-scale) of a corresponding fractional unit.
        /// For example, if a US Dollar Stablecoin has an asset scale of 2, then 1 unit of that MPT would equal 0.01 US Dollars.
        /// This indicates to how many decimal places the MPT can be subdivided.
        /// The default is 0, meaning that the MPT cannot be divided into smaller than 1 unit.
        /// </summary>
        public ushort? AssetScale { get; set; }

        /// <summary>
        /// The maximum number of MPTs that can exist at one time.
        /// If omitted, the maximum is currently limited to 2^63-1.
        /// </summary>
        public string? MaximumAmount { get; set; }

        /// <summary>
        /// The total amount of MPTs of this issuance currently in circulation.
        /// This value increases when the issuer sends MPTs to a non-issuer, and decreases whenever the issuer receives MPTs.
        /// </summary>
        public string? OutstandingAmount { get; set; }

        /// <summary>
        /// The amount of tokens currently locked up (for example, in escrow).
        /// This amount is already included in the OutstandingAmount.
        /// </summary>
        public string? LockedAmount { get; set; }

        /// <summary>
        /// This value specifies the fee, in tenths of a basis point, charged by the issuer for secondary sales of the token, if such sales are allowed at all.
        /// Valid values for this field are between 0 and 50,000 inclusive.
        /// A value of 1 is equivalent to 1/10 of a basis point or 0.001%, allowing transfer rates between 0% and 50%.
        /// A TransferFee of 50,000 corresponds to 50%. The default value for this field is 0.
        /// Any decimals in the transfer fee are rounded down. The fee can be rounded down to zero if the payment is small.
        /// Issuers should make sure that their MPT's AssetScale is large enough.
        /// </summary>
        public ushort? TransferFee { get; set; }

        /// <summary>
        /// Arbitrary metadata about this issuance, in hex format.
        /// The limit for this field is 1024 bytes.
        /// </summary>
        public string? MPTokenMetadata { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// The Sequence (or Ticket) number of the transaction that created this issuance.
        /// This helps to uniquely identify the issuance and distinguish it from any other later MPT issuances created by this account.
        /// </summary>
        public uint? Sequence { get; set; }
    }
}