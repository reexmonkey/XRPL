using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that withdraws assets from an Automated Market Maker (AMM) instance by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    public class AMMWithdraw : Transaction
    {
        private AMMWithdrawFlags? flags;

        /// <summary>
        /// The definition for one of the assets in the AMM's pool.
        /// <para/>In JSON, this is an object with currency and issuer fields (omit issuer for XRP).
        /// </summary>
        public required Issue Asset { get; set; }

        /// <summary>
        /// The definition for the other asset in the AMM's pool.
        /// <para/>In JSON, this is an object with currency and issuer fields (omit issuer for XRP).
        /// </summary>
        public required Issue Asset2 { get; set; }

        /// <summary>
        /// The amount of one asset to withdraw from the AMM.
        /// <para/>This must match the type of one of the assets (tokens or XRP) in the AMM's pool.
        /// </summary>
        public CurrencyAmount? Amount { get; set; }

        /// <summary>
        /// The amount of another asset to withdraw from the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool and cannot be the same type as <see cref="Amount"/>.
        /// </summary>
        public CurrencyAmount? Amount2 { get; set; }

        /// <summary>
        /// The minimum effective price, in LP Token returned, to pay per unit of the asset to withdraw.
        /// </summary>
        public CurrencyAmount? EPrice { get; set; }

        /// <summary>
        /// How many of the AMM's LP Tokens to redeem.
        /// </summary>
        public CurrencyAmount? LPTokenIn { get; set; }

        public override uint? Flags { get => (uint?)flags; set => flags = (AMMWithdrawFlags?)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMWithdraw"/> class.
        /// </summary>
        public AMMWithdraw() : base(TransactionType.AMMWithdraw)
        {
        }
    }

    /// <summary>
    /// Represents the transaction mode for an <see cref="AMMWithdraw"/>.
    /// </summary>
    [Flags]
    public enum AMMWithdrawFlags : uint
    {
        /// <summary>
        /// Return the specified amount of LP Tokens and receive both assets from the AMM's pool in amounts based on the returned LP Tokens' share of the total LP Tokens issued.
        /// </summary>
        tfLPToken = 0x00010000,

        /// <summary>
        /// Return all of your LP Tokens and receive as much as you can of both assets in the AMM's pool.
        /// </summary>
        tfWithdrawAll = 0x00020000,

        /// <summary>
        /// Withdraw at least the specified amount of one asset, by returning all of your LP Tokens.
        /// Fails if you can't receive at least the specified amount.
        /// The specified amount can be 0, meaning the transaction succeeds if it withdraws any positive amount.
        /// </summary>
        tfOneAssetWithdrawAll = 0x00040000,

        /// <summary>
        /// Withdraw exactly the specified amount of one asset, by returning as many LP Tokens as necessary.
        /// </summary>
        tfSingleAsset = 0x00080000,

        /// <summary>
        /// Withdraw both of this AMM's assets, in up to the specified amounts. The actual amounts received maintains the balance of assets in the AMM's pool.
        /// </summary>
        tfTwoAsset = 0x00100000,

        /// <summary>
        /// Withdraw up to the specified amount of one asset, by returning up to the specified amount of LP Tokens.
        /// </summary>
        tfOneAssetLPToken = 0x00200000,

        /// <summary>
        /// Withdraw up to the specified amount of one asset, but pay no more than the specified effective price in LP Tokens per unit of the asset received.
        /// </summary>
        tfLimitLPToken = 0x00400000,

        /// <summary>
        /// If the RequireFullyCanonicalSig amendment is not enabled, this flag enforces a fully-canonical signature
        /// </summary>
        [Obsolete("No effect")]
        tfFullyCanonicalSig = 0x80000000,

        /// <summary>
        /// This flag is only used if a transaction is an inner transaction in a Batch transaction.
        /// This signifies that the transaction isn't signed. Any normal transaction that includes this flag is rejected.
        /// </summary>
        tfInnerBatchTxn = 0x40000000
    }

    [JsonSerializable(typeof(AMMWithdraw))]
    [JsonSerializable(typeof(XRPIssue))]
    [JsonSerializable(typeof(TokenIssue))]
    [JsonSerializable(typeof(MPTIssue))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class AMMWithdrawContext : JsonSerializerContext;
}