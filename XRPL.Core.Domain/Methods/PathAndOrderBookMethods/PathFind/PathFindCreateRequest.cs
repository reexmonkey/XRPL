using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.PathFind
{
    /// <summary>
    /// The create sub-command of path_find creates an ongoing request to find possible paths along
    /// which a payment transaction could be made from one specified account such that another account
    /// receives a desired amount of some currency. The initial response contains a suggested path
    /// between the two addresses that would result in the desired amount being received.
    /// After that, the server sends additional messages, with "type": "path_find", with updates to the potential paths.
    /// The frequency of updates is left to the discretion of the server,
    /// but it usually means once every few seconds when there is a new ledger version.
    /// <para/>- A client can only have one pathfinding request open at a time. If another pathfinding request is already open on the same connection, the old request is automatically closed and replaced with the new request.
    /// </summary>
    public class PathFindCreateRequest : RequestBase<PathFindCreateParameters>, IExpect<PathFindCreateResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PathFindCreateRequest"/> class.
        /// </summary>
        public PathFindCreateRequest() : base("submit")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="PathFindCreateRequest"/> object.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(PathFindCreateParameters), typeDiscriminator: nameof(PathFindCreateParameters))]
    [JsonDerivedType(typeof(FungibleTokenPathFindCreateParameters), typeDiscriminator: nameof(FungibleTokenPathFindCreateParameters))]
    public abstract class PathFindCreateParameters : ParameterBase
    {
        /// <summary>
        /// Use "create" to send the create sub-command
        /// </summary>
        [JsonPropertyName("subcommand")]
        public required string Subcommand { get; set; }

        /// <summary>
        /// Unique address of the account to find a path from. (In other words, the account that would be sending a payment.)
        /// </summary>
        [JsonPropertyName("source_account")]
        public required string SourceAccount { get; set; }

        /// <summary>
        /// Unique address of the account to find a path to. (In other words, the account that would receive a payment.)
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
        /// <para/>Cannot be used with source_urrencies.
        /// </summary>
        [JsonPropertyName("send_max")]
        public object? SendMax { get; set; }

        /// <summary>
        /// (Optional) Array of arrays of objects, representing <see cref = "PaymentPath"/> to check.
        /// You can use this to keep updated on changes to particular paths you already know about,
        /// or to check the overall cost to make a payment along a certain path.
        /// </summary>
        [JsonPropertyName("paths")]
        public PaymentPath[]? Paths { get; set; }

    }

    /// <summary>
    /// Represents a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    [JsonDerivedType(typeof(PathFindCreateParameters), typeDiscriminator: nameof(PathFindCreateParameters))]
    public class XRPPathFindCreateParameters : PathFindCreateParameters
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
        /// <para/>Cannot be used with source_currencies.
        /// </summary>
        [JsonPropertyName("send_max")]
        public new string? SendMax { get => (string?)base.SendMax; set => base.SendMax = value; }
    }

    /// <summary>
    /// Represents a path from one possible source currency (held by the initiating account) to the destination account and currency.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenPathFindCreateParameters), typeDiscriminator: nameof(FungibleTokenPathFindCreateParameters))]
    public class FungibleTokenPathFindCreateParameters : PathFindCreateParameters
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
        /// <para/>Cannot be used with source_currencies.
        /// </summary>
        [JsonPropertyName("send_max")]
        public new TokenAmount? SendMax { get => (TokenAmount?)base.SendMax; set => base.SendMax = value; }
    }
}
