using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.PathFind
{
    /// <summary>
    /// Represents a response to a path find request.
    /// </summary>
    public class PathFindCreateResponse : ResponseBase<PathFindCreateResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="PathFindCreateResponse"/> object.
    /// </summary>
    public class PathFindCreateResult : ResultBase
    {
        /// <summary>
        /// Array of objects with suggested <see cref="Path"/> to take, as described below.
        /// If empty, then there are no paths connecting the source and destination accounts.
        /// </summary>
        [JsonPropertyName("alternatives")]
        public required AlternativePath[]? Alternatives { get; set; }

        /// <summary>
        /// Unique address of the account that would receive a payment transaction.
        /// </summary>
        [JsonPropertyName("destination_account")]
        public required string DestinationAccount { get; set; }

        ///<summary>
        ///Currency Amount that the destination would receive in a transaction.
        ///</summary>
        [JsonPropertyName("destination_amount")]
        public required string DestinationAmount { get; set; }

        ///<summary>
        ///Unique address that would send a transaction.
        ///</summary>
        [JsonPropertyName("source_account")]
        public required string SourceAccount { get; set; }

        ///<summary>
        ///If false, this is the result of an incomplete search. A later reply may have a better path.
        ///If true, then this is the best path found. (It is still theoretically possible that a better path could exist,
        ///but rippled won't find it.) Until you close the pathfinding request,
        ///rippled continues to send updates each time a new ledger closes.
        ///</summary>
        [JsonPropertyName("full_reply")]
        public required bool FullReply { get; set; }

    }

    /// <summary>
    /// Specifies a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(XrpAlternativePathSource), typeDiscriminator: nameof(XrpAlternativePathSource))]
    [JsonDerivedType(typeof(FungibleTokenAlternativePathSource), typeDiscriminator: nameof(FungibleTokenAlternativePathSource))]
    [JsonDerivedType(typeof(XrpAlternativePathDestination), typeDiscriminator: nameof(XrpAlternativePathDestination))]
    [JsonDerivedType(typeof(FungibleTokenAlternativePathDestination), typeDiscriminator: nameof(FungibleTokenAlternativePathDestination))]
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

        /// <summary>
        ///(May be omitted) Currency Amount that the destination would receive along this path. Only included if the destination_amount from the request was the "-1" special case.
        /// </summary>
        [JsonPropertyName("destination_amount")]
        public object? DestinationAmount { get; set; }
    }

    /// <summary>
    /// Represents a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    [JsonDerivedType(typeof(XrpAlternativePathSource), typeDiscriminator: nameof(XrpAlternativePathSource))]
    public class XrpAlternativePathSource : AlternativePath
    {
        /// <summary>
        /// Currency Amount in XRP drops that the source would have to send along this path for the destination to receive the desired amount.
        /// </summary>
        [JsonPropertyName("source_amount")]
        public new required string SourceAmount { get => (string)base.SourceAmount; set => base.SourceAmount = value; }
    }

    /// <summary>
    /// Represents a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenAlternativePathSource), typeDiscriminator: nameof(FungibleTokenAlternativePathSource))]
    public class FungibleTokenAlternativePathSource : AlternativePath
    {
        /// <summary>
        /// Currency Amount in XRP drops that the source would have to send along this path for the destination to receive the desired amount.
        /// </summary>
        [JsonPropertyName("source_amount")]
        public new required TokenAmount SourceAmount { get => (TokenAmount)base.SourceAmount; set => base.SourceAmount = value; }
    }

    /// <summary>
    /// Represents a path to one possible destination currency (held by the initiating account) from the source account and currency.
    /// </summary>
    [JsonDerivedType(typeof(XrpAlternativePathDestination), typeDiscriminator: nameof(XrpAlternativePathDestination))]
    public class XrpAlternativePathDestination : AlternativePath
    {
        /// <summary>
        /// Currency Amount in XRP drops that the destination would have to receive along this path from the source.
        /// </summary>
        [JsonPropertyName("destination_amount")]
        public new string? DestinationAmount { get => (string?)base.DestinationAmount; set => base.DestinationAmount = value; }
    }

    /// <summary>
    /// Represents a path to one possible destination currency (held by the initiating account) from the source account and currency.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenAlternativePathDestination), typeDiscriminator: nameof(FungibleTokenAlternativePathDestination))]
    public class FungibleTokenAlternativePathDestination : AlternativePath
    {
        /// <summary>
        /// Currency Amount in currency that the destination would have to receive along this path from the source.
        /// </summary>
        [JsonPropertyName("destination_amount")]
        public new TokenAmount SourceAmount { get => (TokenAmount)base.SourceAmount; set => base.SourceAmount = value; }
    }
}
