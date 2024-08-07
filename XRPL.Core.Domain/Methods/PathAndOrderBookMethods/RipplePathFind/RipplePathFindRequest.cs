using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.RipplePathFind
{
    /// <summary>
    /// Represents a request, which is a simplified version of the path_find method to provide a single response with a payment path you can use right away.
    /// It is available in both the WebSocket and JSON-RPC APIs.
    /// However, the results tend to become outdated as time passes.
    /// Instead of making multiple calls to stay updated, you should instead use the path_find method to subscribe to continued updates where possible.
    /// <para/>Although the rippled server tries to find the cheapest path or combination of paths for making a payment, it is not guaranteed that the paths returned by this method are, in fact, the best paths.
    /// <para/>Caution: Be careful with the pathfinding results from untrusted servers. A server could be modified to return less-than-optimal paths to earn money for its operators. A server may also return poor results when under heavy load. If you do not have your own server that you can trust with pathfinding, you should compare the results of pathfinding from multiple servers run by different parties, to minimize the risk of a single server returning poor results.
    /// </summary>
    public class RipplePathFindRequest : RequestBase<RipplePathFindParameters>, IExpect<RipplePathFindResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RipplePathFindRequest"/> class.
        /// </summary>
        public RipplePathFindRequest() : base("ripple_path_find")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="RipplePathFindRequest"/> object.
    /// </summary>
    public abstract class RipplePathFindParameters : ParameterBase
    {
        /// <summary>
        /// Unique address of the account that would send funds in a transaction.
        /// </summary>
        [JsonPropertyName("source_account")]
        public required string SourceAccount { get; set; }

        /// <summary>
        /// Unique address of the account that would receive funds in a transaction.
        /// </summary>
        [JsonPropertyName("destination_account")]
        public required string DestinationAccount { get; set; }

        /// <summary>
        /// Currency Amount that the destination account would receive in a transaction.
        /// <para/>Special case: You can specify "-1" (for XRP) or provide -1 as the contents of the value field (for non-XRP currencies).
        /// This requests a path to deliver as much as possible, while spending no more than the amount specified in send_max (if provided).
        /// </summary>
        [JsonPropertyName("destination_amount")]
        public object DestinationAmount { get; set; } = null!;

        /// <summary>
        /// (Optional) Currency Amount that would be spent in the transaction.
        /// <para/>Cannot be used with <see cref="SourceCurrencies"/>.
        /// </summary>
        [JsonPropertyName("send_max")]
        public object? SendMax { get; set; }

        /// <summary>
        /// (Optional) Array of currencies that the source account might want to spend.
        /// <para/>Each entry in the array should be a JSON object with a mandatory currency field and optional issuer field,
        /// like how currency amounts are specified. Cannot contain more than 18 source currencies.
        /// By default, uses all source currencies available up to a maximum of 88 different currency/issuer pairs.
        /// </summary>
        [JsonPropertyName("source_currencies")]
        public OrderBookAsset[]? SourceCurrencies { get; set; }

        ///<summary>
        ///(Optional) A 20-byte hex string for the ledger version to use.
        ///</summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        ///<summary>
        ///(Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        ///</summary>
        [JsonPropertyName("ledger_index")]
        public uint? LedgerIndex { get; set; }
    }

    /// <summary>
    /// Represents a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    public class XrpRipplePathFindParameters : RipplePathFindParameters
    {
        /// <summary>
        /// XRP drops that the destination account would receive in a transaction.
        /// <para/>Special case: You can specify "-1" (for XRP) or provide -1 as the contents of the value field (for non-XRP currencies).
        /// This requests a path to deliver as much as possible, while spending no more than the amount specified in send_max (if provided).
        /// </summary>
        [JsonPropertyName("destination_amount")]
        public new required string DestinationAmount { get => (string)base.DestinationAmount; set => base.DestinationAmount = value; }

        /// <summary>
        /// (Optional) XRP drops that would be spent in the transaction.
        /// <para/>Cannot be used with <see cref="RipplePathFindParameters.SourceCurrencies"/>.
        /// </summary>
        [JsonPropertyName("send_max")]
        public new string? SendMax { get => (string?)base.SendMax; set => base.SendMax = value; }
    }

    /// <summary>
    /// Represents a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    public class FungibleTokenRipplePathFindParameters : RipplePathFindParameters
    {
        /// <summary>
        /// Currency amount that the destination account would receive in a transaction.
        /// <para/>Special case: You can specify "-1" (for XRP) or provide -1 as the contents of the value field (for non-XRP currencies).
        /// This requests a path to deliver as much as possible, while spending no more than the amount specified in send_max (if provided).
        /// </summary>
        [JsonPropertyName("destination_amount")]
        public new required TokenAmount DestinationAmount { get => (TokenAmount)base.DestinationAmount; set => base.DestinationAmount = value; }

        /// <summary>
        /// (Optional) Currency amount that would be spent in the transaction.
        /// <para/>Cannot be used with <see cref="RipplePathFindParameters.SourceCurrencies"/>.
        /// </summary>
        [JsonPropertyName("send_max")]
        public new TokenAmount? SendMax { get => (TokenAmount?)base.SendMax; set => base.SendMax = value; }
    }
}
