using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.NftSellOffers
{
    /// <summary>
    /// Represents a response to a ripple path find request.
    /// </summary>
    public class RipplePathFindResponse : ResponseBase<RiplePathFindResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="RipplePathFindResponse"/> object.
    /// </summary>
    public class RiplePathFindResult : ResultBase
    {
        /// <summary>
        /// Array of objects with possible paths to take, as described below.
        /// If empty, then there are no paths connecting the source and destination accounts.
        /// </summary>
        [JsonPropertyName("alternatives")]
        public required AlternativePath[]? Alternatives { get; set; }

        /// <summary>
        /// Unique address of the account that would receive a payment transaction.
        /// </summary>
        [JsonPropertyName("destination_account")]
        public required string DestinationAccount { get; set; }

        /// <summary>
        /// Array of strings representing the currencies that the destination accepts, as 3-letter codes like "USD" or as 40-character hex like "015841551A748AD2C1F76FF6ECB0CCCD00000000"
        /// </summary>
        [JsonPropertyName("destination_currencies")]
        public required string[] DestinationCurrencies { get; set; }
    }

    /// <summary>
    /// Specifies a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(XrpAlternativePath), typeDiscriminator: nameof(XrpAlternativePath))]
    [JsonDerivedType(typeof(FungibleTokenAlternativePath), typeDiscriminator: nameof(FungibleTokenAlternativePath))]
    public abstract class AlternativePath
    {
        /// <summary>
        /// Array of arrays of objects defining payment paths.
        /// </summary>
        [JsonPropertyName("paths_computed")]
        public required PaymentPath[] PathsComputed { get; set; }

        /// <summary>
        /// Currency Amount that the source would have to send along this path for the destination to receive the desired amount.
        /// </summary>
        [JsonPropertyName("source_amount")]
        public object SourceAmount { get; set; } = null!;
    }

    /// <summary>
    /// Represents a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    [JsonDerivedType(typeof(XrpAlternativePath), typeDiscriminator: nameof(XrpAlternativePath))]
    public class XrpAlternativePath : AlternativePath
    {
        /// <summary>
        /// Currency Amount in XRP drops that the source would have to send along this path for the destination to receive the desired amount.
        /// </summary>
        [JsonPropertyName("source_amount")]
        public new required string SourceAmount { get; set; }
    }

    /// <summary>
    /// Represents a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenAlternativePath), typeDiscriminator: nameof(FungibleTokenAlternativePath))]
    public class FungibleTokenAlternativePath : AlternativePath
    {
        /// <summary>
        /// Currency Amount in XRP drops that the source would have to send along this path for the destination to receive the desired amount.
        /// </summary>
        [JsonPropertyName("source_amount")]
        public new required TokenAmount SourceAmount { get; set; }
    }
}
