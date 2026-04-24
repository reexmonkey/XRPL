using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Methods.JsonRpc.AccountMethods;
using XRPL.Core.Domain.Methods.JsonRpc.PathAndOrderBookMethods;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    /// <summary>
    /// Represents a request to return a single ledger entry from the XRP Ledger in its raw format.
    /// </summary>
    public record LedgerEntryRequest : Request, IExpect<LedgerEntryResponse>
    {
        /// <summary>
        /// Gets the collection of ledger parameters associated with the current object.
        /// </summary>
        [JsonPropertyName("params")]
        public LedgerEntryParameters[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the LedgerEntryRequest class with the request type set to "ledger_entry".
        /// </summary>
        public LedgerEntryRequest() : base("ledger_entry")
        {
        }
    }

    public abstract record LedgerEntryParameters : Parameter
    {
        /// <summary>
        /// If true, return the requested ledger entry's contents as a hex string in the XRP Ledger's binary format.
        /// Otherwise, return data in JSON format.
        /// <para/>The default is false.
        /// </summary>
        public bool? Binary { get; init; }

        /// <summary>
        /// The unique hash of the ledger version to use.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string (e.g. "validated" or "closed" or "current") to choose a ledger automatically.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; init; }

        /// <summary>
        /// (Clio servers only) If set to true and the queried object has been deleted, return its complete data as it was prior to its deletion.
        /// If set to false or not provided, and the queried object has been deleted, return objectNotFound (current behavior).
        /// </summary>
        public bool? IncludeDeleted { get; init; }
    }

    /// <summary>
    /// Retrieve any type of ledger entry by its unique ID.
    /// </summary>
    public record GetLedgerEntryByIdParameters : LedgerEntryParameters
    {
        /// <summary>
        /// The ledger entry ID of a single entry to retrieve from the ledger, as a 64-character (256-bit) hexadecimal string.
        /// </summary>
        [JsonPropertyName("index")]
        public required string Index { get; init; }
    }

    /// <summary>
    /// Retrieve an AccountRoot entry by its address. This is roughly equivalent to the <see cref="AccountInfoRequest"/> method.
    /// </summary>
    public record GetAccountRootEntryParameters : LedgerEntryParameters
    {
        /// <summary>
        /// The classic address of the AccountRoot entry to retrieve.
        /// </summary>
        [JsonPropertyName("account_root")]
        public required string AccountRoot { get; init; }
    }

    /// <summary>
    /// Retrieve the Amendments entry, which contains a list of all enabled amendments on the network.
    /// </summary>
    public record GetAmendmentsEntryParameters : LedgerEntryParameters
    {
        /// <summary>
        /// The Amendments entry.
        /// <para/>This value must be 7DB0788C020F02780A673DC74757F23823FA3014C1866E72CC4CD8B226CD6EF4
        /// </summary>
        [JsonPropertyName("amendments")]
        public required string Amendments { get; init; }
    }

    /// <summary>
    /// Retrieve an Automated Market-Maker (AMM) object from the ledger.
    /// <para/>This is similar to <see cref="AMMInfoRequest"/> method, but the <see cref="LedgerEntry"/> version returns only the ledger entry as stored.
    /// </summary>
    public record GetAMMEntryParameters : LedgerEntryParameters
    {
        /// <summary>
        /// The AMM entry to retrieve. If you specify a string, it must be the ledger entry ID of the AMM, as hexadecimal.
        /// If you specify an object, it must contain asset and asset2 sub-fields.
        /// </summary>
        [JsonPropertyName("amm")]
        public required object Amm { get; init; }
    }

    /// <summary>
    /// Represents an Automated Market Maker (AMM) trading pair object, containing the two assets involved in the pair.
    /// </summary>
    public record AMMEntryObject
    {
        /// <summary>
        /// The first asset in the AMM's trading pair, specified as an object with currency and issuer sub-fields.
        /// </summary>
        public required Issue Asset { get; init; }
        /// <summary>
        /// The second asset in the AMM's trading pair, specified as an object with currency and issuer sub-fields.
        /// </summary>
        public required Issue Asset2 { get; init; }
    }

    [JsonSerializable(typeof(GetAMMEntryParameters))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(AMMEntryObject))]
    public partial class GetAMMEntryParametersContext : JsonSerializerContext;

    [JsonSerializable(typeof(AMMEntryObject))]
    [JsonSerializable(typeof(XRPIssue))]
    [JsonSerializable(typeof(TokenIssue))]
    [JsonSerializable(typeof(MPTIssue))]
    public partial class AMMEntryObjectContext : JsonSerializerContext;

    /// <summary>
    /// Retrieve a Check entry, which is a potential payment that can be cashed by its recipient.
    /// </summary>
    public record GetCheckEntryParameters : LedgerEntryParameters
    {
        /// <summary>
        /// The ledger entry ID of a Check entry to retrieve.
        /// </summary>
        [JsonPropertyName("check")]
        public required string Check { get; init; }
    }

    [JsonSerializable(typeof(LedgerEntryRequest))]
    [JsonSerializable(typeof(GetLedgerEntryByIdParameters))]
    [JsonSerializable(typeof(GetAccountRootEntryParameters))]
    [JsonSerializable(typeof(GetAmendmentsEntryParameters))]
    [JsonSerializable(typeof(GetAMMEntryParameters))]
    public partial class LedgerEntryRequestContext : JsonSerializerContext;
}
