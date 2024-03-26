using System.Runtime.Serialization;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents the amount and currency of a fungible token.
    /// </summary>
    public class CurrencyAmount
    {
        /// <summary>
        /// Arbitrary currency code for the token. Cannot be XRP.
        /// </summary>
        [DataMember(Name = "currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Quoted decimal representation of the amount of the token.
        /// <para/>This can include scientific notation, such as 1.23e11 meaning 123,000,000,000. Both e and E may be used.
        /// This can be negative when displaying balances, but negative values are disallowed in other contexts such as specifying how much to send.
        /// <para/> In fact, the value must have the following properties:
        /// <para/> - Base-10.
        /// <para/> - Non-zero-prefaced.
        /// <para/> - May contain . as a decimal point. For example, ½ is represented as 0.5. (American style, not European)
        /// <para/> - Negative amounts start with the character -.
        /// <para/> - May contain E or e to indicate being raised to a power of 10 (scientific notation). For example, 1.2E5 is equivalent to 1.2×105, or 120000. Negative exponents are also possible.
        /// <para/> - No comma (,) characters are used.
        /// <para/>In some cases, you need to define an asset (which could be XRP or a token) without a specific amount, such as when defining an order book in the decentralized exchange.
        /// To describe a token without an amount, specify it as a token object, but omit the value field.
        /// </summary>
        [DataMember(Name = "value")]
        public string? Value { get; set; }

        /// <summary>
        /// Generally, the account that issues this token.
        /// <para/>In special cases, this can refer to the account that holds the token instead (for example, in a Clawback transaction).
        /// </summary>
        [DataMember(Name = "issuer")]
        public string? Issuer { get; set; }
    }
}