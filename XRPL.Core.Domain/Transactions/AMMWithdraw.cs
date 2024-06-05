using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that withdraws assets from an Automated Market Maker (AMM) instance by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(AMMWithdraw), typeDiscriminator: nameof(AMMWithdraw))]
    [JsonDerivedType(typeof(XrpFungibleTokenAMMWithdraw), typeDiscriminator: nameof(XrpFungibleTokenAMMWithdraw))]
    [JsonDerivedType(typeof(FungibleTokenXrpAMMWithdraw), typeDiscriminator: nameof(FungibleTokenXrpAMMWithdraw))]
    [JsonDerivedType(typeof(FungibleTokenAMMWithdraw), typeDiscriminator: nameof(FungibleTokenAMMWithdraw))]
    public abstract class AMMWithdraw : Transaction
    {
        /// <summary>
        /// The definition for one of the assets in the AMM's pool.
        /// <para/>In JSON, this is an object with currency and issuer fields (omit issuer for XRP).
        /// </summary>
        public required STIssue Asset { get; set; }

        /// <summary>
        /// The definition for the other asset in the AMM's pool.
        /// <para/>In JSON, this is an object with currency and issuer fields (omit issuer for XRP).
        /// </summary>
        public required STIssue Asset2 { get; set; }

        /// <summary>
        /// The amount of one asset to withdraw from the AMM.
        /// <para/>This must match the type of one of the assets (tokens or XRP) in the AMM's pool.
        /// </summary>
        public object? Amount { get; set; }

        /// <summary>
        /// The amount of another asset to withdraw from the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool and cannot be the same type as <see cref="Amount"/>.
        /// </summary>
        public object? Amount2 { get; set; }

        /// <summary>
        /// The minimum effective price, in LP Token returned, to pay per unit of the asset to withdraw.
        /// </summary>
        public LPTokenAmount? EPrice { get; set; }

        /// <summary>
        /// How many of the AMM's LP Tokens to redeem.
        /// </summary>
        public LPTokenAmount? LPTokenIn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMWithdraw"/> class.
        /// </summary>
        protected AMMWithdraw() : base(TransactionType.AMMWithdraw)
        {
        }
    }

    /// <summary>
    /// Represents a transaction that withdraws assets from an Automated Market Maker (AMM) instance (XRP/fungible token)
    /// by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    [JsonDerivedType(typeof(XrpFungibleTokenAMMWithdraw), typeDiscriminator: nameof(XrpFungibleTokenAMMWithdraw))]
    public sealed class XrpFungibleTokenAMMWithdraw : AMMWithdraw
    {
        /// <summary>
        /// The amount of XRP in drops to withdraw from the AMM.
        /// <para/>This must match the type of one of the assets (XRP) in the AMM's pool.
        /// </summary>
        public new string? Amount { get => (string?)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// The amount of another asset to withdraw from the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool and cannot be the same type as <see cref="Amount"/>.
        /// </summary>
        public new TokenAmount? Amount2 { get => (TokenAmount?)base.Amount2; set => base.Amount2 = value; }
    }

    /// <summary>
    /// Represents a transaction that withdraws assets from an Automated Market Maker (AMM) instance (fungible token/XRP)
    /// by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenXrpAMMWithdraw), typeDiscriminator: nameof(FungibleTokenXrpAMMWithdraw))]
    public sealed class FungibleTokenXrpAMMWithdraw : AMMWithdraw
    {
        /// <summary>
        /// The amount of fungible tokens to withdraw from the AMM.
        /// <para/>This must match the type of one of the assets (fungible token) in the AMM's pool.
        /// </summary>
        public new TokenAmount? Amount { get => (TokenAmount?)base.Amount2; set => base.Amount2 = value; }

        /// <summary>
        /// The amount of XRP in drops to withdraw from the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool and cannot be the same type as <see cref="Amount"/>.
        /// </summary>
        public new string? Amount2 { get => (string?)base.Amount2; set => base.Amount2 = value; }
    }

    /// <summary>
    /// Represents a transaction that withdraws fungible token assets from an Automated Market Maker (AMM) instance 
    /// by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenAMMWithdraw), typeDiscriminator: nameof(FungibleTokenAMMWithdraw))]
    public sealed class FungibleTokenAMMWithdraw : AMMWithdraw
    {
        /// <summary>
        /// The amount of fungible tokens to withdraw from the AMM.
        /// <para/>This must match the type of one of the assets (fungible token) in the AMM's pool.
        /// </summary>
        public new TokenAmount? Amount { get => (TokenAmount?)base.Amount2; set => base.Amount2 = value; }

        /// <summary>
        /// The amount of another asset to withdraw from the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool and cannot be the same type as <see cref="Amount"/>.
        /// </summary>
        public new TokenAmount? Amount2 { get => (TokenAmount?)base.Amount2; set => base.Amount2 = value; }
    }

    /// <summary>
    /// Represents the transaction mode for an <see cref="AMMWithdraw"/>.
    /// </summary>
    [Flags]
    public enum AMMWithdrawFlags
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
        tfLimitLPToken = 0x00400000
    }
}
