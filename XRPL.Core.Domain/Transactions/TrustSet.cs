using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that creates or modifies a trust line linking two accounts.
    /// </summary>
    public class TrustSet : Transaction
    {
        /// <summary>
        /// (Optional) Value incoming balances on this trust line at the ratio of this number per 1,000,000,000 units.
        /// <para/>A value of 0 is shorthand for treating balances at face value.
        /// For example, if you set the value to 10,000,000, 1% of incoming funds remain with the sender.
        /// If an account sends 100 currency, the sender retains 1 currency unit and the destination receives 99 units.
        /// This option is included for parity: in practice, you are much more likely to set a QualityOut value.
        /// Note that this fee is separate and independent from token transfer fees.
        /// </summary>
        public uint? QualityIn { get; set; }

        /// <summary>
        /// (Optional) Value outgoing balances on this trust line at the ratio of this number per 1,000,000,000 units.
        /// <para/>A value of 0 is shorthand for treating balances at face value.
        /// For example, if you set the value to 10,000,000, 1% of outgoing funds would remain with the issuer.
        /// If the sender sends 100 currency units, the issuer retains 1 currency unit and the destination receives 99 units.
        /// Note that this fee is separate and independent from token transfer fees.
        /// </summary>
        public uint? QualityOut { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrustSet"/> class.
        /// </summary>
        public TrustSet() : base(TransactionType.TrustSet)
        {
        }
    }

    /// <summary>
    /// Represents the trust line to create or modify, in the format of a Currency Amount.
    /// </summary>
    public class LimitAmount
    {
        /// <summary>
        /// The currency to this trust line applies to, as a three-letter ISO 4217 Currency Code or a 160-bit hex value according to currency format.
        /// <para/>"XRP" is invalid.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; set; }

        /// <summary>
        /// Quoted decimal representation of the limit to set on this trust line.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }

        /// <summary>
        /// The address of the account to extend trust to.
        /// </summary>
        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }
    }

    /// <summary>
    /// Represents the flags of a <see cref="TrustSet"/> transaction.
    /// </summary>
    public enum TrustSetFlags
    {
        /// <summary>
        /// Authorize the other party to hold currency issued by this account.
        /// <para/>(No effect unless using the asfRequireAuth AccountSet flag.) Cannot be unset.
        /// </summary>
        tfSetfAuth = 0x00010000,

        /// <summary>
        /// Enable the No Ripple flag, which blocks rippling between two trust lines of the same currency if this flag is enabled on both.
        /// </summary>
        tfSetNoRipple = 0x00020000,

        /// <summary>
        /// Disable the No Ripple flag, allowing rippling on this trust line.
        /// </summary>
        tfClearNoRipple = 0x00040000,

        /// <summary>
        /// Freeze the trust line.
        /// </summary>
        tfSetFreeze = 0x00100000,

        /// <summary>
        /// Unfreeze the trust line
        /// </summary>
        tfClearFreeze = 0x00200000
    }
}
