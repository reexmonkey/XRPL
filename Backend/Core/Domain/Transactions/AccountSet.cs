using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that modifies the properties of an account (<see cref="AccountRoot"/>) in the XRP Ledger.
    /// </summary>
    public class AccountSet : Transaction
    {
        /// <summary>
        /// (Optional) Unique identifier of a flag to disable for this account.
        /// </summary>
        public AccountSetFlags? ClearFlag { get; set; }

        /// <summary>
        /// (Optional) The domain that owns this account, as a string of hex representing the ASCII for the domain in lowercase.
        /// <para/>Cannot be more than 256 bytes in length.
        /// </summary>
        public string? Domain { get; set; }

        /// <summary>
        /// (Optional) An arbitrary 128-bit value.
        /// <para/>Conventionally, clients treat this as the md5 hash of an email address to use for displaying a Gravatar image.
        /// </summary>
        public string? EmailHash { get; set; }

        /// <summary>
        /// (Optional) Public key for sending encrypted messages to this account.
        /// <para/>To set the key, it must be exactly 33 bytes, with the first byte indicating the key type: 0x02 or 0x03 for secp256k1 keys, 0xED for Ed25519 keys.
        /// <para/>To remove the key, use an empty value.
        /// </summary>
        public string? MessageKey { get; set; }

        /// <summary>
        /// (Optional) Another account that can mint NFTokens for you. (Added by the NonFungibleTokensV1_1 amendment.)
        /// </summary>
        public string? NFTokenMinter { get; set; }

        /// <summary>
        /// (Optional) Integer flag to enable for this account.
        /// </summary>
        public AccountSetFlags? SetFlag { get; set; }

        /// <summary>
        /// (Optional) The fee to charge when users transfer this account's tokens, represented as billionths of a unit. Cannot be more than 2000000000 or less than 1000000000, except for the special case 0 meaning no fee.
        /// </summary>
        public uint? TransferRate { get; set; }

        /// <summary>
        /// (Optional) Tick size to use for offers involving a currency issued by this address. The exchange rates of those offers is rounded to this many significant digits. Valid values are 3 to 15 inclusive, or 0 to disable. (Added by the TickSize amendment)
        /// </summary>
        public uint? TickSize { get; set; }

        /// <summary>
        /// (Optional) An arbitrary 256-bit value. If specified, the value is stored as part of the account but has no inherent meaning or requirements.
        /// </summary>
        public string? WalletLocator { get; set; }

        /// <summary>
        /// (Optional) Not used. This field is valid in AccountSet transactions but does nothing.
        /// </summary>
        public uint? WalletSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountSet"/> class.
        /// </summary>
        public AccountSet() : base(TransactionType.AccountSet)
        {
        }
    }

    /// <summary>
    /// Represents the flags that can be enabled or disabled on an account using an AccountSet transaction.
    /// These flags are stored in the Flags field of the AccountRoot ledger entry for the account,
    /// and can be modified by sending an AccountSet transaction with the appropriate SetFlag or ClearFlag value.
    /// </summary>
    [Flags]
    public enum AccountSetFlags : uint
    {
        /// <summary>
        /// Track the ID of this account's most recent transaction. Required for AccountTxnID
        /// </summary>
        asfAccountTxnID = 5,

        /// <summary>
        /// Allow account to claw back tokens it has issued.
        /// (Requires the Clawback amendment.) Can only be set if the account has an empty owner directory (no trust lines, offers, escrows, payment channels, checks, or signer lists).
        /// After you set this flag, it cannot be reverted.
        /// The account permanently gains the ability to claw back issued assets on trust lines.
        /// </summary>
        asfAllowTrustLineClawback = 16,

        /// <summary>
        /// Allow Trust Line tokens issued by this account to be held in escrow. If not enabled, tokens issued by this account can't be escrowed. After you enable this flag, it cannot be disabled.
        /// </summary>
        asfAllowTrustLineLocking = 17,

        /// <summary>
        /// Enable to allow another account to mint non-fungible tokens (NFTokens) on this account's behalf.
        /// Specify the authorized account in the NFTokenMinter field of the AccountRoot object.
        /// To remove an authorized minter, enable this flag and omit the NFTokenMinter field.
        /// </summary>
        asfAuthorizedNFTokenMinter = 10,

        /// <summary>
        /// Enable rippling on this account's trust lines by default.
        /// </summary>
        asfDefaultRipple = 8,

        /// <summary>
        /// Enable Deposit Authorization on this account.
        /// </summary>
        asfDepositAuth = 9,

        /// <summary>
        /// Disallow use of the master key pair.
        /// Can only be enabled if the account has configured another way to sign transactions, such as a Regular Key or a Signer List.
        /// </summary>
        asfDisableMaster = 4,

        /// <summary>
        /// Block incoming Checks.
        /// </summary>
        asfDisallowIncomingCheck = 13,

        /// <summary>
        /// Block incoming NFTokenOffers.
        /// </summary>
        asfDisallowIncomingNFTokenOffer = 12,

        /// <summary>
        /// Block incoming Payment Channels.
        /// </summary>
        asfDisallowIncomingPayChan = 14,

        /// <summary>
        /// Block incoming trust lines.
        /// </summary>
        asfDisallowIncomingTrustline = 15,

        /// <summary>
        /// XRP should not be sent to this account. (Advisory; not enforced by the XRP Ledger protocol.)
        /// </summary>
        asfDisallowXRP = 3,

        /// <summary>
        /// Freeze all assets issued by this account.
        /// </summary>
        asfGlobalFreeze = 7,

        /// <summary>
        /// Permanently give up the ability to freeze individual trust lines or disable Global Freeze.
        /// This flag can never be disabled after being enabled.
        /// </summary>
        asfNoFreeze,

        /// <summary>
        /// Require authorization for users to hold balances issued by this address.
        /// Can only be enabled if the address has no trust lines connected to it.
        /// </summary>
        asfRequireAuth = 2,

        /// <summary>
        /// Require a destination tag to send transactions to this account.
        /// </summary>
        asfRequireDest = 1,

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