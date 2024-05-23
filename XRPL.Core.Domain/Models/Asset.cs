
using System.Runtime.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Specifies an asset.
    /// </summary>
    public abstract class Asset
    {
        /// <summary>
        /// </summary>
        [DataMember(Name = "currency")]
        public required string Currency { get; set; }
    }

    /// <summary>
        /// <para/>This can include scientific notation, such as 1.23e11 meaning 123,000,000,000. Both e and E may be used.
        /// This can be negative when displaying balances, but negative values are disallowed in other contexts such as specifying how much to send.
        /// <para/> In fact, the value must have the following properties:
        /// <para/> - Base-10.
        /// <para/> - Non-zero-prefaced.
        /// <para/> - May contain . as a decimal point. For example, ½ is represented as 0.5. (American style, not European)
        /// <para/> - Negative amounts start with the character -.
        /// <para/> - No comma (,) characters are used.
        /// <para/>In some cases, you need to define an asset (which could be XRP or a token) without a specific amount, such as when defining an order book in the decentralized exchange.
        /// To describe a token without an amount, specify it as a token object, but omit the value field.
        /// </summary>
        [DataMember(Name = "value")]
        public string? Value { get; set; }
    }

    /// <summary>
    /// </summary>
    {
    }

    /// <summary>
    /// Represents the asset of a fungible token without amounts.
    /// </summary>
    public class OrderBookAsset : Asset
    {
        /// <summary>
        /// Generally, the account that issues this token.
        /// <para/>In special cases, this can refer to the account that holds the token instead (for example, in a Clawback transaction).
        /// </summary>
        [DataMember(Name = "issuer")]
    }

    /// <summary>
    /// </summary>
    {
    }

    /// <summary>
    /// </summary>
    {
        /// <summary>
        /// </summary>
    }
}
