using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that deposits funds into an Automated Market Maker (AMM) instance and receive the AMM's liquidity provider tokens (LP Tokens) in exchange. You can deposit one or both of the assets in the AMM's pool.
    /// <para/> If successful, this transaction creates a trust line to the AMM Account (limit 0) to hold the LP Tokens.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(AMMDeposit), typeDiscriminator: nameof(AMMDeposit))]
    [JsonDerivedType(typeof(XrpFungibleTokenAMMDeposit), typeDiscriminator: nameof(XrpFungibleTokenAMMDeposit))]
    [JsonDerivedType(typeof(FungibleTokenXrpAMMDeposit), typeDiscriminator: nameof(FungibleTokenXrpAMMDeposit))]
    [JsonDerivedType(typeof(FungibleTokenAMMDeposit), typeDiscriminator: nameof(FungibleTokenAMMDeposit))]
    public abstract class AMMDeposit : Transaction
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
        /// The amount of one asset to deposit to the AMM.
        /// <para/>If present, this must match the type of one of the assets (tokens or XRP) in the AMM's pool.
        /// </summary>
        public object? Amount { get; set; }

        /// <summary>
        /// The amount of another asset to add to the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool and cannot be the same asset as <see cref="Amount"/>.
        /// </summary>
        public object? Amount2 { get; set; }

        /// <summary>
        /// The maximum effective price, in the deposit asset, to pay for each LP Token received.
        /// </summary>
        public object? EPrice { get; set; }

        /// <summary>
        /// How many of the AMM's LP Tokens to buy.
        /// </summary>
        public LPTokenAmount? LPTokenOut { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMDeposit"/> class.
        /// </summary>
        protected AMMDeposit() : base(TransactionType.AMMDeposit)
        {
        }
    }

    /// <summary>
    /// Represents a transaction that deposits pairs of XRP/fungible token funds into an Automated Market Maker (AMM) instance
    /// and receive the AMM's liquidity provider tokens (LP Tokens) in exchange. You can deposit one or both of the assets in the AMM's pool.
    /// <para/> If successful, this transaction creates a trust line to the AMM Account (limit 0) to hold the LP Tokens.
    /// </summary>
    [JsonDerivedType(typeof(XrpFungibleTokenAMMDeposit), typeDiscriminator: nameof(XrpFungibleTokenAMMDeposit))]
    public sealed class XrpFungibleTokenAMMDeposit : AMMDeposit
    {
        /// <summary>
        /// The amount of one asset to deposit to the AMM.
        /// <para/>If present, this must match the type of one of the assets (tokens or XRP) in the AMM's pool.
        /// </summary>
        public new string? Amount { get => (string?)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// The amount of another asset to add to the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool.
        /// </summary>
        public new TokenAmount? Amount2 { get => (TokenAmount?)base.Amount2; set => base.Amount2 = value; }

        /// <summary>
        /// The maximum effective price, in the deposit asset, to pay for each LP Token received.
        /// </summary>
        public new string? EPrice { get => (string?)base.EPrice; set => base.EPrice = value; }
    }

    /// <summary>
    /// Represents a transaction that deposits pairs of XRP/fungible token funds into an Automated Market Maker (AMM) instance
    /// and receive the AMM's liquidity provider tokens (LP Tokens) in exchange. You can deposit one or both of the assets in the AMM's pool.
    /// <para/> If successful, this transaction creates a trust line to the AMM Account (limit 0) to hold the LP Tokens.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenXrpAMMDeposit), typeDiscriminator: nameof(FungibleTokenXrpAMMDeposit))]
    public sealed class FungibleTokenXrpAMMDeposit : AMMDeposit
    {
        /// <summary>
        /// The amount of one asset to deposit to the AMM.
        /// <para/>If present, this must match the type of one of the assets (tokens or XRP) in the AMM's pool.
        /// </summary>
        public new TokenAmount? Amount { get => (TokenAmount?)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// The amount of another asset to add to the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool.
        /// </summary>
        public new string? Amount2 { get => (string?)base.Amount2; set => base.Amount2 = value; }

        /// <summary>
        /// The maximum effective price, in the deposit asset, to pay for each LP Token received.
        /// </summary>
        public new TokenAmount? EPrice { get => (TokenAmount?)base.EPrice; set => base.EPrice = value; }
    }

    /// <summary>
    /// Represents a transaction that deposits pairs of fungible token funds into an Automated Market Maker (AMM) instance and receive the AMM's liquidity provider tokens (LP Tokens) in exchange. You can deposit one or both of the assets in the AMM's pool.
    /// <para/> If successful, this transaction creates a trust line to the AMM Account (limit 0) to hold the LP Tokens.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenAMMDeposit), typeDiscriminator: nameof(FungibleTokenAMMDeposit))]
    public sealed class FungibleTokenAMMDeposit : AMMDeposit
    {
        /// <summary>
        /// The amount of one asset to deposit to the AMM.
        /// <para/>If present, this must match the type of one of the assets (tokens or XRP) in the AMM's pool.
        /// </summary>
        public new TokenAmount? Amount { get => (TokenAmount?)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// The amount of another asset to add to the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool and cannot be the same asset as <see cref="Amount"/>.
        /// </summary>
        public new TokenAmount? Amount2 { get => (TokenAmount?)base.Amount2; set => base.Amount2 = value; }

        /// <summary>
        /// The maximum effective price, in the deposit asset, to pay for each LP Token received.
        /// </summary>
        public new TokenAmount? EPrice { get => (TokenAmount?)base.EPrice; set => base.EPrice = value; }
    }

    /// <summary>
    /// Represents the transaction mode for an <see cref="AMMDeposit"/>.
    /// </summary>
    [Flags]
    public enum AMMDepositFlags : uint
    {
        /// <summary>
        /// Deposit both of this AMM's assets, in amounts calculated so that you receive the specified amount of LP Tokens in return.
        /// The amounts deposited maintain the relative proportions of the two assets the AMM already holds.
        /// </summary>
        tfLPToken = 0x00010000,

        /// <summary>
        /// Deposit exactly the specified amount of one asset, and receive an amount of LP Tokens based on the resulting share of the pool (minus fees).
        /// </summary>
        tfSingleAsset = 0x00080000,

        /// <summary>
        /// Deposit both of this AMM's assets, up to the specified amounts. The actual amounts deposited must maintain the same balance of assets as the AMM already holds, so the amount of either one deposited MAY be less than specified. The amount of LP Tokens you get in return is based on the total value deposited.
        /// </summary>
        tfTwoAsset = 0x00100000,

        /// <summary>
        /// Deposit up to the specified amount of one asset, so that you receive exactly the specified amount of LP Tokens in return (after fees).
        /// </summary>
        tfOneAssetLPToken = 0x00200000,

        /// <summary>
        /// Deposit up to the specified amount of one asset, but pay no more than the specified effective price per LP Token (after fees).
        /// </summary>
        tfLimitLPToken = 0x00400000,

        /// <summary>
        /// Deposit both of this AMM's assets, in exactly the specified amounts, to an AMM with an empty asset pool. The amount of LP Tokens you get in return is based on the total value deposited.
        /// </summary>
        tfTwoAssetIfEmpty = 0x00800000
    }
}
