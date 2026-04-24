using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that creates a new Multi-purpose Token (MPT) issuance, which defines the properties of those MPTs. This is a prerequisite to actually issuing the tokens.
    /// <para/>If the transaction is successful, it creates an <see cref="MPTokenIssuance"/> entry where the sender of the transaction is the MPT's issuer.
    /// </summary>
    public class MPTokenIssuanceCreate : Transaction
    {
        private MPTokenIssuanceCreateFlags? flags;

        /// <summary>
        /// Where to put the decimal place when displaying amounts of this MPT.
        /// More formally, the asset scale is a non-negative integer (0, 1, 2, …) such that one standard unit equals 10^(-scale) of a corresponding fractional unit.
        /// For example, if a US Dollar Stablecoin has an asset scale of 2, then 1 unit of that MPT would equal 0.01 US Dollars.
        /// This indicates to how many decimal places the MPT can be subdivided.
        /// If omitted, the default is 0, meaning that the MPT cannot be divided into smaller than 1 unit.
        /// </summary>
        public byte? AssetScale { get; set; }

        /// <summary>
        /// The ledger entry ID of a permissioned domain that grants access to the MPT. You must enable the tfMPTRequireAuth flag to use permissioned domains.
        /// </summary>
        public string? DomainID { get; set; }

        /// <summary>
        /// The value specifies the fee to charged by the issuer for secondary sales of the Token,
        /// if such sales are allowed. Valid values for this field are between 0 and 50,000 inclusive,
        /// allowing transfer rates of between 0.000% and 50.000% in increments of 0.001.
        /// The field must not be present if the tfMPTCanTransfer flag is not set. If it is, the transaction should fail and a fee should be claimed.
        /// </summary>
        public ushort? TransferFee { get; set; }

        /// <summary>
        /// The maximum asset amount of this token that can ever be issued, as a base-10 number encoded as a string. The current default maximum limit is 9,223,372,036,854,775,807 (2^63-1).
        /// <para/>This limit may increase in the future. If an upper limit is required, you must specify this field.
        /// </summary>
        public string? MaximumAmount { get; set; }

        /// <summary>
        /// Arbitrary metadata about this issuance. The limit for this field is 1024 bytes.
        /// By convention, the metadata should decode to JSON data describing what the MPT represents.
        /// The XLS-89 specification defines a recommended format for metadata.
        /// </summary>
        public string? MPTokenMetadata { get; set; }

        public override uint? Flags { get => (uint?)flags; set => flags = (MPTokenIssuanceCreateFlags?)value; }

        /// <summary>
        /// Initializes a new instance of the MPTokenIssuanceCreate class.
        /// </summary>
        public MPTokenIssuanceCreate() : base(TransactionType.MPTokenIssuanceCreate)
        {
        }
    }

    public enum MPTokenIssuanceCreateFlags : uint
    {
        /// <summary>
        /// If set, indicates that the MPT can be locked both individually and globally. If not set, the MPT cannot be locked in any way.
        /// </summary>
        tfMPTCanLock = 0x00000002,

        /// <summary>
        /// If set, indicates that individual holders must be authorized. This enables issuers to limit who can hold their assets.
        /// </summary>
        tfMPTRequireAuth = 0x00000004,

        /// <summary>
        /// If set, indicates that individual holders can place their balances into an escrow.
        /// </summary>
        tfMPTCanEscrow = 0x00000008,

        /// <summary>
        /// If set, indicates that individual holders can trade their balances using the XRP Ledger DEX.
        /// </summary>
        tfMPTCanTrade = 0x00000010,

        /// <summary>
        /// If set, indicates that tokens can be transferred to other accounts that are not the issuer.
        /// </summary>
        tfMPTCanTransfer = 0x00000020,

        /// <summary>
        /// If set, indicates that the issuer can use the Clawback transaction to claw back value from individual holders.
        /// </summary>
        tfMPTCanClawback = 0x00000040,

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