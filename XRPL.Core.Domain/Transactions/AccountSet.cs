using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Responses;

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
        public uint? ClearFlag { get; set; }

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
        public uint? SetFlag { get; set; }

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
}