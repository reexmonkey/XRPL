using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a trust line between two accounts.
    /// <para/> Each account can change its own limit and other settings, but the balance is a single shared value.
    /// A trust line that is entirely in its default state is considered the same as a trust line that does not exist and is automatically deleted.
    /// </summary>
    public class RippleState : LedgerEntryBase
    {
        protected RippleStateFlags flags;

        /// <summary>
        /// The balance of the trust line, from the perspective of the low account.
        /// <para/>A negative balance indicates that the high account holds tokens issued by the low account.
        /// The issuer in this is always set to the neutral value ACCOUNT_ONE.
        /// </summary>
        public Token? Balance { get; set; }

        /// <summary>
        /// A bit-map of boolean options enabled for this entry.
        /// </summary>
        public override uint Flags { get => (uint)flags; set => flags = (RippleStateFlags)value; }

        /// <summary>
        /// The limit that the high account has set on the trust line.
        /// <para/>The issuer is the address of the high account that set this limit.
        /// </summary>
        public Token? HighLimit { get; set; }

        /// <summary>
        /// (Omitted in some historical ledgers) A hint indicating which page of the high account's owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? HighNode { get; set; }

        /// <summary>
        /// The inbound quality set by the high account, as an integer in the implied ratio HighQualityIn:1,000,000,000.
        /// <para/>As a special case, the value 0 is equivalent to 1 billion, or face value.
        /// </summary>
        public uint? HighQualityIn { get; set; }

        /// <summary>
        /// The outbound quality set by the high account, as an integer in the implied ratio HighQualityOut:1,000,000,000.
        /// As a special case, the value 0 is equivalent to 1 billion, or face value.
        /// </summary>
        public uint? HighQualityOut { get; set; }

        /// <summary>
        /// The limit that the low account has set on the trust line.
        /// <para/>The issuer is the address of the low account that set this limit.
        /// </summary>
        public Token? LowLimit { get; set; }

        /// <summary>
        /// (Omitted in some historical ledgers) A hint indicating which page of the low account's owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? LowNode { get; set; }

        /// <summary>
        /// The inbound quality set by the low account, as an integer in the implied ratio LowQualityIn:1,000,000,000.
        /// <para/>As a special case, the value 0 is equivalent to 1 billion, or face value.
        /// </summary>
        public uint? LowQualityIn { get; set; }

        /// <summary>
        /// The outbound quality set by the low account, as an integer in the implied ratio LowQualityOut:1,000,000,000.
        /// <para/> As a special case, the value 0 is equivalent to 1 billion, or face value.
        /// </summary>
        public uint? LowQualityOut { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public string? PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this entry.
        /// </summary>
        public uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// Initialize a new instance of the <see cref="RippleState"/> class.
        /// </summary>
        public RippleState()
        {
            LedgerEntryType = "RippleState";
        }
    }

    /// <summary>
    /// Represents flags of a <see cref="RippleState"/>.
    /// </summary>
    [Flags]
    public enum RippleStateFlags : uint
    {
        /// <summary>
        /// This entry contributes to the low account's owner reserve.
        /// </summary>
        lsfLowReserve = 0x00010000,

        /// <summary>
        /// This entry contributes to the high account's owner reserve.
        /// </summary>
        lsfHighReserve = 0x00020000,

        /// <summary>
        /// The low account has authorized the high account to hold tokens issued by the low account.
        /// </summary>
        lsfLowAuth = 0x00040000,

        /// <summary>
        /// The high account has authorized the low account to hold tokens issued by the high account.
        /// </summary>
        lsfHighAuth = 0x00080000,

        /// <summary>
        /// The low account has disabled rippling from this trust line.
        /// </summary>
        lsfLowNoRipple = 0x00100000,

        /// <summary>
        /// The high account has disabled rippling from this trust line.
        /// </summary>
        lsfHighNoRipple = 0x00200000,

        /// <summary>
        /// The low account has frozen the trust line, preventing the high account from transferring the asset.
        /// </summary>
        lsfLowFreeze = 0x00400000,

        /// <summary>
        /// The high account has frozen the trust line, preventing the low account from transferring the asset.
        /// </summary>
        lsfHighFreeze = 0x00800000
    }
}