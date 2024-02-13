using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a ledger entry that describes a single account.
    /// </summary>
    public class AccountRoot : LedgerEntryBase
    {
        protected AccountRootFlags flags;

        /// <summary>
        /// The identifying (classic) address of this account.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// The identifying hash of the transaction most recently sent by this account.
        /// <para/>This field must be enabled to use the <see cref="AccountTxnID"/> transaction field.
        /// To enable it, send an AccountSet transaction with the asfAccountTxnID flag enabled.
        /// </summary>
        public string? AccountTxnID { get; set; }

        /// <summary>
        /// The ledger entry ID of the corresponding AMM ledger entry.
        /// <para/> Set during account creation; cannot be modified.
        /// If present, indicates that this is a special AMM AccountRoot; always omitted on non-AMM accounts.
        /// </summary>
        public string? AMMID { get; set; }

        /// <summary>
        /// The account's current XRP balance in drops, represented as a string.
        /// </summary>
        public string? Balance { get; set; }

        /// <summary>
        /// How many total of this account's issued non-fungible tokens have been burned.
        /// <para/>This number is always equal or less than MintedNFTokens.
        /// </summary>
        public uint BurnedNFTokens { get; set; }

        /// <summary>
        /// A domain associated with this account.
        /// <para/>In JSON, this is the hexadecimal for the ASCII representation of the domain.
        /// Cannot be more than 256 bytes in length.
        /// </summary>
        public string? Domain { get; set; }

        /// <summary>
        /// The md5 hash of an email address.
        /// <para/>Clients can use this to look up an avatar through services such as Gravatar.
        /// </summary>
        public string? EmailHash { get; set; }

        /// <summary>
        /// The account's Sequence Number at the time it minted its first non-fungible-token.
        /// </summary>
        public uint FirstNFTokenSequence { get; set; }

        /// <summary>
        /// A public key that may be used to send encrypted messages to this account.
        /// <para/> In JSON, uses hexadecimal.
        /// Must be exactly 33 bytes, with the first byte indicating the key type: 0x02 or 0x03 for secp256k1 keys, 0xED for Ed25519 keys.
        /// </summary>
        public string? MessageKey { get; set; }

        /// <summary>
        /// How many total non-fungible tokens have been minted by and on behalf of this account.
        /// </summary>
        public uint MintedNFTokens { get; set; }

        /// <summary>
        /// Another account that can mint non-fungible tokens on behalf of this account.
        /// </summary>
        public string? NFTokenMinter { get; set; }

        /// <summary>
        /// The number of objects this account owns in the ledger, which contributes to its owner reserve.
        /// </summary>
        public uint OwnerCount { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this object.
        /// </summary>
        public string? PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The address of a key pair that can be used to sign transactions for this account instead of the master key. Use a SetRegularKey transaction to change this value.
        /// </summary>
        public string? RegularKey { get; set; }

        /// <summary>
        /// The sequence number of the next valid transaction for this account.
        /// </summary>
        public uint Sequence { get; set; }

        /// <summary>
        /// How many Tickets this account owns in the ledger.
        /// <para/>This is updated automatically to ensure that the account stays within the hard limit of 250 Tickets at a time.
        /// This field is omitted if the account has zero Tickets.
        /// </summary>
        public uint TicketCount { get; set; }

        /// <summary>
        /// How many significant digits to use for exchange rates of Offers involving currencies issued by this address. Valid values are 3 to 15, inclusive.
        /// </summary>
        public uint TickSize { get; set; }

        /// <summary>
        /// A transfer fee to charge other users for sending currency issued by this account to each other.
        /// </summary>
        public uint TransferRate { get; set; }

        /// <summary>
        /// An arbitrary 256-bit value that users can set.
        /// </summary>
        public string? WalletLocator { get; set; }

        /// <summary>
        /// Unused. (The code supports this field but there is no way to set it.)
        /// </summary>
        public uint WalletSize { get; set; }

        /// <summary>
        /// Set of bit-flags for this ledger entry.
        /// </summary>
        public uint Flags { get => (uint)flags; set => flags = (AccountRootFlags)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRoot"/> class.
        /// </summary>
        public AccountRoot()
        {
            LedgerEntryType = "AccountRoot";
        }
    }

    /// <summary>
    /// Represents an account root to be used with an Automated Market Maker (AMM).
    /// </summary>
    public sealed class SpecialAccountRoot : AccountRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialAccountRoot"/> class.
        /// </summary>
        public SpecialAccountRoot()
        {
            flags = AccountRootFlags.lsfDisableMaster
                | AccountRootFlags.lsfDepositAuth
                | AccountRootFlags.lsfDefaultRipple;
        }
    }

    /// <summary>
    /// Represents options you can change with an Account Set transaction.
    /// </summary>
    [Flags]
    public enum AccountRootFlags : uint
    {
        /// <summary>
        /// Enable Clawback for this account.
        /// </summary>
        lsfAllowTrustLineClawback = 0x80000000,

        /// <summary>
        /// Enable rippling on this addresses's trust lines by default. Required for issuing addresses; discouraged for others.
        /// </summary>
        lsfDefaultRipple = 0x00800000,

        /// <summary>
        /// This account has DepositAuth enabled, meaning it can only receive funds from transactions it sends, and from preauthorized accounts.
        /// </summary>
        lsfDepositAuth = 0x01000000,

        /// <summary>
        /// Disallows use of the master key to sign transactions for this account.
        /// </summary>
        lsfDisableMaster = 0x00100000,

        /// <summary>
        /// This account blocks incoming Checks.
        /// </summary>
        lsfDisallowIncomingCheck = 0x08000000,

        /// <summary>
        /// This account blocks incoming NFTokenOffers.
        /// </summary>
        lsfDisallowIncomingNFTokenOffer = 0x04000000,

        /// <summary>
        /// This account blocks incoming Payment Channels.
        /// </summary>
        lsfDisallowIncomingPayChan = 0x10000000,

        /// <summary>
        /// This account blocks incoming trust lines.
        /// </summary>
        lsfDisallowIncomingTrustline = 0x20000000,

        /// <summary>
        /// Client applications should not send XRP to this account.
        /// <para/>(Advisory; not enforced by the protocol.)
        /// </summary>
        lsfDisallowXRP = 0x00080000,

        /// <summary>
        /// All assets issued by this account are frozen.
        /// </summary>
        lsfGlobalFreeze = 0x00400000,

        /// <summary>
        /// This account cannot freeze trust lines connected to it. Once enabled, cannot be disabled.
        /// </summary>
        lsfNoFreeze = 0x00200000,

        /// <summary>
        /// This account has used its free SetRegularKey transaction.
        /// </summary>
        lsfPasswordSpent = 0x00010000,

        /// <summary>
        /// This account must individually approve other users for those users to hold this account's tokens.
        /// </summary>
        lsfRequireAuth = 0x00040000,

        /// <summary>
        /// Requires incoming payments to specify a Destination Tag.
        /// </summary>
        lsfRequireDestTag = 0x00020000
    }
}